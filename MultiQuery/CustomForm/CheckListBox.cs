/*
 * Crée par SharpDevelop.
 * Utilisateur: SRUMEU
 * Date: 31/03/2015
 * Heure: 09:41
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using MultiQuery.Config;

namespace MultiQuery.CustomForm
{
	/// <summary>
	/// Description of CheckListBox.
	/// </summary>
	public partial class CheckListBox : UserControl
	{
		/// <summary>
		/// Serveur cliqué par clic droit.
		/// </summary>
		
		private int ClickedServer { get; set; }
		
		/// <summary>
		/// Source de données. Ne peut utiliser le DataSource de la ListBox
		/// pour avoir le contrôle sur la checkbox.
		/// </summary>
		private DataTable SourceTable { get; set; }
		
		/// <summary>
		/// Liste des serveurs sélectionnés.
		/// </summary>
		private List<Server.Server> Selected { get; set; }
		
		/// <summary>
		/// Tableau de serveurs sélectionnés.
		/// </summary>
		/// <returns></returns>
		
		public Server.Server[] GetSelected()
		{
			return Selected.ToArray();
		}
		
		/// <summary>
		/// Ajoute un nouveau serveur à la liste.
		/// </summary>
		/// <param name="newServer">Nouveau serveur à ajouter.</param>
		
		public DataRow AddServer(Server.Server newServer)
		{
			DataRow dr = SourceTable.Rows.Add(newServer, new CheckBox(), newServer.ServerName, newServer.ServerColor);
			CheckBox chx = (CheckBox)dr["Checked"];
			
			chx.Text = "";
			chx.Checked = false;
			chx.Height = this.lbx_main.ItemHeight;
			chx.Width = this.lbx_main.ItemHeight + 2;
			chx.Location = new Point(0, this.lbx_main.ItemHeight * (SourceTable.Rows.Count - 1));
			chx.CheckedChanged += new EventHandler(ListBoxUpdate_CheckedChanged);
			this.lbx_main.Controls.Add(chx);
			this.lbx_main.Items.Add(dr["Server"]);
			this.lbx_main.DrawMode = DrawMode.OwnerDrawFixed;
			
			return dr;
		}
		
		/// <summary>
		/// Constructeur.
		/// </summary>
		
		public CheckListBox()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			this.SourceTable = new DataTable();
			this.SourceTable.Columns.Add("Server", typeof(Server.Server));
			this.SourceTable.Columns.Add("Checked", typeof(CheckBox));
			this.SourceTable.Columns.Add("ServerName", typeof(string));
			this.SourceTable.Columns.Add("ServerColor", typeof(System.Drawing.Color));
			
			this.lbx_main.DrawItem += new DrawItemEventHandler(lbx_main_DrawItem);
			this.lbx_main.DisplayMember = "ServerName";
			
			this.Selected = new List<MultiQuery.Server.Server>();
		}
		
		/// <summary>
		/// Dessin d'un nouvel item.
		/// </summary>
		/// <param name="sender">Objet appelant.</param>
		/// <param name="e">Arguments d'appel.</param>
		
		void lbx_main_DrawItem(object sender, DrawItemEventArgs e)
        {
			if (e.Index > lbx_main.Items.Count || e.Index < 0)
				return;
			
            e.DrawBackground();
            Rectangle contentRect = e.Bounds;
            contentRect.X = 16;
            e.Graphics.DrawString(this.lbx_main.Items[e.Index].ToString(),
                e.Font,
                //new SolidBrush(colors[e.Index]),
                new SolidBrush((Color)SourceTable.Rows[e.Index]["ServerColor"]),
                contentRect);
        }
		
		/// <summary>
		/// Clic sur une check box. Ajoute ou retire le serveur à la liste des sélectionnés.
		/// </summary>
		/// <param name="sender">Objet appelant.</param>
		/// <param name="e">Arguments d'appel.</param>
		
		void ListBoxUpdate_CheckedChanged(object sender, EventArgs e)
		{
			CheckBox chx = (CheckBox)sender;
			
			Server.Server srv = null;
			
			for (int i = 0; i < SourceTable.Rows.Count; ++i)
				if (SourceTable.Rows[i]["Checked"] == chx)
					srv = (Server.Server)SourceTable.Rows[i]["Server"];
			
			if (srv != null)
			{
				if (chx.Checked == true)
					Selected.Add(srv);
				else if (Selected.Contains(srv))
					Selected.Remove(srv);
			}
		}
		
		/// <summary>
		/// Liste des indices sélectionnés.
		/// Passé en ReadOnly pour ne pas interférer avec la gestion de la checkbox.
		/// </summary>
		
		public ListBox.SelectedIndexCollection SelectedIndices
		{
			get 
			{ 
				return lbx_main.SelectedIndices; 
			} 
			private set { }
		}
		
		/// <summary>
		/// Efface un serveur de la liste.
		/// </summary>
		/// <param name="index">Index du serveur à supprimer.</param>
		
		public void DeleteServer(int index)
		{
			if (index < SourceTable.Rows.Count)
			{
				for (int i = index + 1; i < SourceTable.Rows.Count; ++i)
				{
					CheckBox chxMove = (CheckBox)SourceTable.Rows[i]["Checked"];
					chxMove.Location = new Point(0, chxMove.Location.Y - lbx_main.ItemHeight);
				}
			}
			
			CheckBox chxDelete = (CheckBox)SourceTable.Rows[index]["Checked"];
			chxDelete.Dispose();
			lbx_main.Items.RemoveAt(index);
			SourceTable.Rows[index].Delete();
		}
		
		/// <summary>
		/// Renvoie la liste complète des serveurs.
		/// </summary>
		/// <returns>Tous les serveurs de la liste.</returns>
		
		public Server.Server[] GetAll()
		{
			List<Server.Server> data = new List<Server.Server>();
			for (int i = 0; i < SourceTable.Rows.Count; ++i)
			{
				data.Add((Server.Server)SourceTable.Rows[i]["Server"]);
			}
			
			return data.ToArray();
		}
		
		/// <summary>
		/// Raffraichir la liste des serveurs.
		/// </summary>
		
		public override void Refresh()
		{
			foreach (DataRow row in SourceTable.Rows)
			{
				row["ServerColor"] = ((Server.Server)row["Server"]).ServerColor;
			}
			
			base.Refresh();
		}
		
		/// <summary>
		/// Renvoie le serveur à l'index idx.
		/// </summary>
		/// <param name="idx">Index du serveur.</param>
		/// <returns></returns>
		
		public Server.Server GetServer(int idx)
		{
			return (Server.Server)SourceTable.Rows[idx]["Server"];
		}
		
		/// <summary>
		/// Editer le serveur par clic droit.
		/// </summary>
		/// <param name="sender">Objet appelant.</param>
		/// <param name="e">Arguments d'appel.</param>
		
		void EditerToolStripMenuItemClick(object sender, EventArgs e)
		{
			Server.Server server = (Server.Server)SourceTable.Rows[ClickedServer]["Server"];
			
			frm_newServer editDialog = new frm_newServer(server);
			if (editDialog.ShowDialog() == DialogResult.OK)
			{
				((frm_main)ParentForm).SaveServerList();
				this.Refresh();
			}
		}
		
		/// <summary>
		/// Supprimer le serveur par clic droit.
		/// </summary>
		/// <param name="sender">Objet appelant.</param>
		/// <param name="e">Arguments d'appel.</param>
		
		void SupprimerToolStripMenuItemClick(object sender, EventArgs e)
		{
			DeleteServer(ClickedServer);
			((frm_main)ParentForm).SaveServerList();
		}
				
		/// <summary>
		/// Gestion du clic droit.
		/// </summary>
		/// <param name="sender">Objet appelant.</param>
		/// <param name="e">Arguments d'appel.</param>
		
		void Lbx_mainMouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Right)
				return;
			
			ClickedServer = lbx_main.IndexFromPoint(e.Location);
			
			if (ClickedServer != -1)
			{
	            lbx_main.SelectedIndices.Clear();
	            lbx_main.SelectedIndices.Add(ClickedServer);
				ctx_menuEditDelete.Show();
			}
		}
		
		/// <summary>
		/// Exécuter une requête sur un serveur seul.
		/// </summary>
		/// <param name="sender">Objet appelant.</param>
		/// <param name="e">Arguments d'appel.</param>
		
		void ExecuterSurCeServeurToolStripMenuItemClick(object sender, EventArgs e)
		{
			Server.Server server = (Server.Server)SourceTable.Rows[ClickedServer]["Server"];
			frm_main parent = (frm_main)this.ParentForm;
			parent.ExecuteOnServers(new MultiQuery.Server.Server[] { server });
		}
	}
}
