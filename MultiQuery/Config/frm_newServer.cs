﻿/*
 * Crée par SharpDevelop.
 * Utilisateur: SRUMEU
 * Date: 26/03/2015
 * Heure: 13:52
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
		/// <summary>
		/// Valeur du serveur.
		/// </summary>
		
		public Server.Server NewServer { get; set; }
		
		/// <summary>
		/// Création d'un nouveau serveur.
		/// </summary>
		
		public frm_newServer()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			cbx_type.SelectedIndex = 0;
			cbx_authent.SelectedIndex = 0;
		}
		
		/// <summary>
		/// Modification d'un serveur existant.
		/// </summary>
		/// <param name="srv">Serveur à éditer.</param>
		
		public frm_newServer(Server.Server srv)
		{
			InitializeComponent();
			
			NewServer = srv;
			
			txt_serverName.Text = srv.ServerName;
			pan_color.BackColor = srv.ServerColor;
			
			if (srv is Server.MsSqlServer)
			{
				Server.MsSqlServer server = (Server.MsSqlServer)srv;
				
				cbx_type.SelectedIndex = 0;
				
				if (server.UseTrusted == true)
				{
					cbx_authent.SelectedIndex = 0;
				}
				else
				{
					cbx_authent.SelectedIndex = 1;
				}
				txt_username.Text = server.UserName;
				txt_pw.Text = server.Password;
				txt_defaultDatabase.Text = server.DefaultDatabase;
				txt_server.Text = server.Dns;
				chx_rememberMe.Checked = server.RememberMe;
			}
			else if (srv is SqLiteFile)
			{
				Server.SqLiteFile server = (Server.SqLiteFile)srv;
				
				cbx_type.SelectedIndex = 1;
				
				txt_pw.Text = server.Password;
				txt_server.Text = server.FileName;
				chx_rememberMe.Checked = server.RememberMe;
			}
		}
		
		/// <summary>
		/// Changement de couleur.
		/// </summary>
		/// <param name="sender">Objet appelant.</param>
		/// <param name="e">Arguments d'appel.</param>
		
		private void Pan_colorClick(object sender, EventArgs e)
		{
			if (cld.ShowDialog() == DialogResult.OK)
			{
				pan_color.BackColor = cld.Color;
			}
		}
		
		/// <summary>
		/// Ajout d'un serveur.
		/// </summary>
		/// <param name="sender">Objet appelant.</param>
		/// <param name="e">Arguments d'appel.</param>
		
		private void Btn_okClick(object sender, EventArgs e)
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
			
			if (NewServer == null)
			{
				if (cbx_type.SelectedIndex == 0)
				{
					NewServer = MsSqlServer.New(
								txt_server.Text,
								txt_username.Text,
								chx_rememberMe.Checked,
								txt_pw.Text,
								cbx_authent.SelectedIndex == 0,
								txt_serverName.Text,
								pan_color.BackColor,
								txt_defaultDatabase.Text);
				}
				else if (cbx_type.SelectedIndex == 1)
				{
					NewServer = SqLiteFile.New(txt_server.Text,
					                           chx_rememberMe.Checked,
					                           txt_pw.Text,
					                           txt_serverName.Text,
					                           pan_color.BackColor);
				}
			}
			else
			{
				if (cbx_type.SelectedIndex == 0)
				{
					((Server.MsSqlServer)NewServer).SetNewValues(
						txt_server.Text,
						txt_username.Text,
						chx_rememberMe.Checked,
						txt_pw.Text,
						cbx_authent.SelectedIndex == 0,
						txt_serverName.Text,
						pan_color.BackColor,
						txt_defaultDatabase.Text);
				}
				else if (cbx_type.SelectedIndex == 1)
				{
					((Server.SqLiteFile)NewServer).SetNewValues(
						txt_server.Text,
						chx_rememberMe.Checked,
						txt_pw.Text,
						txt_serverName.Text,
						pan_color.BackColor);
				}
			}
			this.DialogResult = DialogResult.OK;
			
			this.Close();
		}
		
		/// <summary>
		/// Annuler.
		/// </summary>
		/// <param name="sender">Objet appelant.</param>
		/// <param name="e">Arguments d'appel.</param>
		
		private void Btn_annulerClick(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
		
		/// <summary>
		/// Tester la connexion au serveur.
		/// </summary>
		/// <param name="sender">Objet appelant.</param>
		/// <param name="e">Arguments d'appel.</param>
		
		private void Btn_testClick(object sender, EventArgs e)
		{
			if (cbx_type.SelectedIndex == 0)
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
			else if (cbx_type.SelectedIndex == 1)
			{
				try
				{
					SqLiteFile.TestConnection(txt_server.Text, txt_pw.Text);
					MessageBox.Show("Connexion réussie", "Connexion réussie", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				catch (Exception exp)
				{
					MessageBox.Show("Connexion échouée\n" + exp.Message, "Connexion échouée", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}
		
		/// <summary>
		/// Changement du type de connexion.
		/// </summary>
		/// <param name="sender">Objet appelant.</param>
		/// <param name="e">Arguments d'appel.</param>
		
		private void Cbx_authentSelectedIndexChanged(object sender, EventArgs e)
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
		/// Change le nom du serveur en mettant par défaut le host ou l'IP renseignée.
		/// </summary>
		/// <param name="sender">Objet appelant.</param>
		/// <param name="e">Arguments d'appel.</param>
		
		private void Txt_serverLeave(object sender, EventArgs e)
		{
			if (txt_serverName.Text == string.Empty)
				txt_serverName.Text = txt_server.Text;
		}
		
		/// <summary>
		/// Choix du type de serveur.
		/// </summary>
		/// <param name="sender">Objet appelant.</param>
		/// <param name="e">Arguments d'appel.</param>
		
		void Cbx_typeSelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbx_type.SelectedIndex == 1)
			{
				cbx_authent.Enabled = false;
				cbx_authent.SelectedIndex = 1;
				
				txt_username.Enabled = false;
				txt_username.Text = string.Empty;
				
				txt_defaultDatabase.Enabled = false;
				txt_defaultDatabase.Text = string.Empty;
			}
			else
			{
				cbx_authent.Enabled = true;
				
				txt_username.Enabled = true;
				
				txt_defaultDatabase.Enabled = true;
			}
		}
	}
}
