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
			
			/*CheckBox[] cks = new CheckBox[SourceTable.Rows.Count];
            for (int j = 0; j < SourceTable.Rows.Count; j++)
            {
                cks[j] = new CheckBox();
                cks[j].Text = "";
                cks[j].Checked = (bool)SourceTable.Rows[j]["Checked"];
                cks[j].Height = this.lbx_main.ItemHeight;
                cks[j].Width = 15;
                cks[j].Location = new Point(0, this.lbx_main.ItemHeight * j);
                //cks[j].CheckedChanged += new EventHandler(ListBoxUpdate_CheckedChanged);
                this.lbx_main.Controls.Add(cks[j]);
                this.lbx_main.Items.Add(SourceTable.Rows[j]["ServerName"].ToString());
            }
            this.lbx_main.DrawMode = DrawMode.OwnerDrawFixed;
            //this.lbx_main.DrawItem += new DrawItemEventHandler(Lbx_mainDrawItem);*/
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
	}
}
