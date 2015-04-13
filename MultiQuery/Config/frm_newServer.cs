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
		/// Ajout d'un serveur.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		
		void Btn_okClick(object sender, EventArgs e)
		{
			if (txt_server.Text == string.Empty)
			{
				MessageBox.Show("Renseignez un serveur auquel se connecter.", "Erreur de serveur", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (txt_serverName.Text == string.Empty)
			{
				MessageBox.Show("Renseignez un nom au serveur.", "Erreur de serveur", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			
			NewServer = MsSqlServer.New(
				txt_server.Text,
				txt_username.Text,
				chx_rememberMe.Checked,
				txt_pw.Text,
				cbx_authent.SelectedIndex == 0,
				txt_serverName.Text,
				pan_color.BackColor,
				txt_defaultDatabase.Text);
			
			this.DialogResult = DialogResult.OK;
			
			this.Close();
		}
		
		/// <summary>
		/// Annuler
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		
		void Btn_annulerClick(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
		
		/// <summary>
		/// Tester la connexion au serveur.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		
		void Btn_testClick(object sender, EventArgs e)
		{
			try
			{
				MsSqlServer.TestConnection(txt_server.Text, txt_username.Text, txt_pw.Text, cbx_authent.SelectedIndex == 0, txt_defaultDatabase.Text);
				MessageBox.Show("Connexion réussie", "Connexion réussie", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (Exception exp)
			{
				MessageBox.Show("Connexion échouée\n" + exp.Message, "Connexion échouée", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		
		/// <summary>
		/// Chargement de la fenêtre.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		
		void Frm_newServerLoad(object sender, EventArgs e)
		{
			cbx_authent.SelectedIndex = 0;
			cbx_type.SelectedIndex = 0;
		}
		
		/// <summary>
		/// Changement du type de connexion.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		
		void Cbx_authentSelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbx_authent.SelectedIndex == 0)
			{
				txt_username.Text = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
				txt_username.Enabled = false;
				txt_pw.Text = string.Empty;
				txt_pw.Enabled = false;
				chx_rememberMe.CheckState = CheckState.Unchecked;
				chx_rememberMe.Enabled = false;
			}
			else
			{
				if (txt_username.Text == System.Security.Principal.WindowsIdentity.GetCurrent().Name)
					txt_username.Text = string.Empty;
				txt_username.Enabled = true;
				txt_pw.Enabled = true;
				chx_rememberMe.Enabled = true;
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		
		void Txt_serverLeave(object sender, EventArgs e)
		{
			if (txt_serverName.Text == string.Empty)
				txt_serverName.Text = txt_server.Text;
		}
	}
}
