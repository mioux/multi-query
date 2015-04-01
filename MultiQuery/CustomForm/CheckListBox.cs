/*
 * Crée par SharpDevelop.
 * Utilisateur: SRUMEU
 * Date: 31/03/2015
 * Heure: 09:41
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;

namespace MultiQuery.CustomForm
{
	/// <summary>
	/// Description of CheckListBox.
	/// </summary>
	public partial class CheckListBox : UserControl
	{
		/// <summary>
		/// 
		/// </summary>
		private DataTable SourceTable { get; set; }
		
		/// <summary>
		/// 
		/// </summary>
		private List<Server.Server> Selected { get; set; }
		
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		
		public Server.Server[] GetSelected()
		{
			return Selected.ToArray();
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="newServer"></param>
		
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
		/// 
		/// </summary>
		
		public CheckListBox()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
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
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		
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
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		
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
		/// 
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
		/// 
		/// </summary>
		/// <param name="index"></param>
		
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
		/// 
		/// </summary>
		/// <returns></returns>
		
		public Server.Server[] GetAll()
		{
			List<Server.Server> data = new List<Server.Server>();
			for (int i = 0; i < SourceTable.Rows.Count; ++i)
			{
				data.Add((Server.Server)SourceTable.Rows[i]["Server"]);
			}
			
			return data.ToArray();
		}
	}
}
