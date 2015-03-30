/*
 * Crée par SharpDevelop.
 * Utilisateur: SRUMEU
 * Date: 26/03/2015
 * Heure: 13:52
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using MultiQuery.Server;

namespace MultiQuery.Config
{
	/// <summary>
	/// Description of frm_newServer.
	/// </summary>
	public partial class frm_newServer : Form
	{
		public Server.Server NewServer { get; set; }
		
		public frm_newServer()
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
		/// Changement de couleur.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		
		void Pan_colorClick(object sender, EventArgs e)
		{
			if (cld.ShowDialog() == DialogResult.OK)
			{
				pan_color.BackColor = cld.Color;
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		
		void Btn_okClick(object sender, EventArgs e)
		{
			string conString = MsSqlServer.CreateConnectionString(
				txt_server.Text,
				txt_username.Text,
				chx_rememberMe.Checked,
				txt_pw.Text,
				cbx_authent.SelectedIndex == 0);
			
			NewServer = new MsSqlServer(conString, txt_serverName.Text, pan_color.BackColor);
			
			this.DialogResult = DialogResult.OK;
			
			this.Close();
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		
		void Btn_annulerClick(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		
		void Btn_testClick(object sender, EventArgs e)
		{
			if (MsSqlServer.TestConnection(txt_server.Text, txt_username.Text, txt_pw.Text, cbx_authent.SelectedIndex == 0))
			    MessageBox.Show("Connexion réussie", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
			else
				MessageBox.Show("Connexion échouée", "Echec", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}
}
