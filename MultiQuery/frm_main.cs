/*
 * Crée par SharpDevelop.
 * Utilisateur: SRUMEU
 * Date: 25/03/2015
 * Heure: 16:57
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using MultiQuery.Config;
using System.Collections.Generic;

namespace MultiQuery
{
	/// <summary>
	/// Description of frm_main.
	/// </summary>
	public partial class frm_main : Form
	{
		Dictionary<string, Server.Server> srvList = new Dictionary<string, Server.Server>();
		
		private frm_newServer newServer = new frm_newServer();
		
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
			
			clb_serverList.DataSource = srvList;
		}
		
		/// <summary>
		/// Ajouter un serveur.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void AjouterToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (newServer.ShowDialog() == DialogResult.OK)
			{
				srvList.Add(newServer.NewServer.ServerName, newServer.NewServer);
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void SupprimerToolStripMenuItemClick(object sender, EventArgs e)
		{
			
		}
		
		void ExécuterSurLesServeursSélectionnésToolStripMenuItemClick(object sender, EventArgs e)
		{
			
		}
		
		void ExécuterSurTousLesServeursToolStripMenuItemClick(object sender, EventArgs e)
		{
			
		}
		
		void QuitterToolStripMenuItemClick(object sender, EventArgs e)
		{
			
		}
	}
}
