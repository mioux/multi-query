/*
 * Crée par SharpDevelop.
 * Utilisateur: SRUMEU
 * Date: 25/03/2015
 * Heure: 16:57
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using MultiQuery.Config;
using MultiQuery.CustomForm;

namespace MultiQuery
{
	/// <summary>
	/// Description of frm_main.
	/// </summary>
	public partial class frm_main : Form
	{		
		/// <summary>
		/// Constructeur.
		/// </summary>
		public frm_main()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		/// <summary>
		/// Ajouter un serveur.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void AjouterToolStripMenuItemClick(object sender, EventArgs e)
		{
			frm_newServer newServer = new frm_newServer();
			
			if (newServer.ShowDialog() == DialogResult.OK)
			{
				clb_serverList.AddServer(newServer.NewServer);
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void SupprimerToolStripMenuItemClick(object sender, EventArgs e)
		{
			List<int> liste = new List<int>();
			
			if (clb_serverList.SelectedIndices.Count > 0)
			{
				foreach (int index in clb_serverList.SelectedIndices)
				{
					liste.Add(index);
				}
			}
			
			liste.Sort();
			liste.Reverse();
			
			foreach (int index in liste)
			{
				clb_serverList.DeleteServer(index);
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		
		void ExécuterSurLesServeursSélectionnésToolStripMenuItemClick(object sender, EventArgs e)
		{
			tbc_result.TabPages.Clear();
			foreach(Server.Server srv in clb_serverList.GetSelected())
			{
				AddNewResult(srv, "Select 1 select 2");
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		
		void ExécuterSurTousLesServeursToolStripMenuItemClick(object sender, EventArgs e)
		{
			tbc_result.TabPages.Clear();
			foreach(Server.Server srv in clb_serverList.GetAll())
			{
				AddNewResult(srv, "Select 1 select 2");
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		
		void QuitterToolStripMenuItemClick(object sender, EventArgs e)
		{
			Environment.Exit(0);
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="srv"></param>
		/// <param name="SQL"></param>
		
		void AddNewResult(Server.Server srv, string SQL)
		{
			TabPage newTab = new TabPage();
			newTab.Text = srv.ServerName;
			
			tbc_result.TabPages.Add(newTab);
			
			try
			{
				DataSet data = srv.Execute(SQL);
				if (data.Tables.Count > 0)
				{
					TabControl tbc = new TabControl();
					tbc.Dock = DockStyle.Fill;
					
					for (int i = 0; i < data.Tables.Count; ++i)
					{
						TabData tbd = new TabData();
						tbd.DataSource = data.Tables[i];
						tbd.Text = string.Format("Résultat {0}", i + 1);
						tbc.TabPages.Add(tbd);
					}
				}
				else
				{
					Label lbl = new Label();
					lbl.Text = "Pas de résultats";
					lbl.Location = new Point(5, 5);
					newTab.Controls.Add(lbl);
				}
			}
			catch (Exception exp)
			{
				TextBox txt = new TextBox();
				txt.Multiline = true;
				txt.Text = exp.Message + "\n\n" + exp.StackTrace;
				
				newTab.Controls.Add(txt);
			}
		}
	}
}
