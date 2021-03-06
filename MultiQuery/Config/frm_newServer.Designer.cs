﻿/*
 * Crée par SharpDevelop.
 * Utilisateur: SRUMEU
 * Date: 26/03/2015
 * Heure: 13:52
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
namespace MultiQuery.Config
{
	partial class frm_newServer
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.txt_server = new System.Windows.Forms.TextBox();
			this.lbl_title = new System.Windows.Forms.Label();
			this.cbx_type = new System.Windows.Forms.ComboBox();
			this.cbx_authent = new System.Windows.Forms.ComboBox();
			this.txt_username = new System.Windows.Forms.TextBox();
			this.txt_pw = new System.Windows.Forms.TextBox();
			this.chx_rememberMe = new System.Windows.Forms.CheckBox();
			this.grp_login = new System.Windows.Forms.GroupBox();
			this.btn_browse = new System.Windows.Forms.Button();
			this.lbl_defaultDb = new System.Windows.Forms.Label();
			this.txt_defaultDatabase = new System.Windows.Forms.TextBox();
			this.lbl_pw = new System.Windows.Forms.Label();
			this.lbl_username = new System.Windows.Forms.Label();
			this.lbl_authent = new System.Windows.Forms.Label();
			this.lbl_server = new System.Windows.Forms.Label();
			this.lbl_type = new System.Windows.Forms.Label();
			this.grp_register = new System.Windows.Forms.GroupBox();
			this.lbl_serverColor = new System.Windows.Forms.Label();
			this.lbl_serverName = new System.Windows.Forms.Label();
			this.pan_color = new System.Windows.Forms.Panel();
			this.txt_serverName = new System.Windows.Forms.TextBox();
			this.btn_ok = new System.Windows.Forms.Button();
			this.btn_annuler = new System.Windows.Forms.Button();
			this.btn_test = new System.Windows.Forms.Button();
			this.cld = new System.Windows.Forms.ColorDialog();
			this.mnu_MsSqlServers = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.bgw_populateMsSqlServerMenu = new System.ComponentModel.BackgroundWorker();
			this.ofd_sqlite = new System.Windows.Forms.OpenFileDialog();
			this.bgw_populateMySqlServerMenu = new System.ComponentModel.BackgroundWorker();
			this.mnu_MySqlServers = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.notYetImplementedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.grp_login.SuspendLayout();
			this.grp_register.SuspendLayout();
			this.mnu_MySqlServers.SuspendLayout();
			this.SuspendLayout();
			// 
			// txt_server
			// 
			this.txt_server.Location = new System.Drawing.Point(125, 46);
			this.txt_server.Name = "txt_server";
			this.txt_server.Size = new System.Drawing.Size(184, 20);
			this.txt_server.TabIndex = 2;
			this.txt_server.Leave += new System.EventHandler(this.Txt_serverLeave);
			// 
			// lbl_title
			// 
			this.lbl_title.Location = new System.Drawing.Point(12, 9);
			this.lbl_title.Name = "lbl_title";
			this.lbl_title.Size = new System.Drawing.Size(353, 18);
			this.lbl_title.TabIndex = 0;
			this.lbl_title.Text = "Ajouter un serveur";
			this.lbl_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// cbx_type
			// 
			this.cbx_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbx_type.FormattingEnabled = true;
			this.cbx_type.Items.AddRange(new object[] {
									"Microsoft Sql Server",
									"SqLite",
									"MySql"});
			this.cbx_type.Location = new System.Drawing.Point(125, 19);
			this.cbx_type.Name = "cbx_type";
			this.cbx_type.Size = new System.Drawing.Size(222, 21);
			this.cbx_type.TabIndex = 1;
			this.cbx_type.SelectedIndexChanged += new System.EventHandler(this.Cbx_typeSelectedIndexChanged);
			// 
			// cbx_authent
			// 
			this.cbx_authent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbx_authent.FormattingEnabled = true;
			this.cbx_authent.Items.AddRange(new object[] {
									"Authentification Windows",
									"Authentification par login/mot de passe."});
			this.cbx_authent.Location = new System.Drawing.Point(125, 72);
			this.cbx_authent.Name = "cbx_authent";
			this.cbx_authent.Size = new System.Drawing.Size(222, 21);
			this.cbx_authent.TabIndex = 3;
			this.cbx_authent.SelectedIndexChanged += new System.EventHandler(this.Cbx_authentSelectedIndexChanged);
			// 
			// txt_username
			// 
			this.txt_username.Enabled = false;
			this.txt_username.Location = new System.Drawing.Point(142, 99);
			this.txt_username.Name = "txt_username";
			this.txt_username.Size = new System.Drawing.Size(205, 20);
			this.txt_username.TabIndex = 4;
			// 
			// txt_pw
			// 
			this.txt_pw.Enabled = false;
			this.txt_pw.Location = new System.Drawing.Point(142, 125);
			this.txt_pw.Name = "txt_pw";
			this.txt_pw.Size = new System.Drawing.Size(205, 20);
			this.txt_pw.TabIndex = 5;
			this.txt_pw.UseSystemPasswordChar = true;
			// 
			// chx_rememberMe
			// 
			this.chx_rememberMe.Enabled = false;
			this.chx_rememberMe.Location = new System.Drawing.Point(142, 151);
			this.chx_rememberMe.Name = "chx_rememberMe";
			this.chx_rememberMe.Size = new System.Drawing.Size(143, 20);
			this.chx_rememberMe.TabIndex = 6;
			this.chx_rememberMe.Text = "Se souvenir de moi.";
			this.chx_rememberMe.UseVisualStyleBackColor = true;
			// 
			// grp_login
			// 
			this.grp_login.Controls.Add(this.btn_browse);
			this.grp_login.Controls.Add(this.lbl_defaultDb);
			this.grp_login.Controls.Add(this.txt_defaultDatabase);
			this.grp_login.Controls.Add(this.lbl_pw);
			this.grp_login.Controls.Add(this.lbl_username);
			this.grp_login.Controls.Add(this.lbl_authent);
			this.grp_login.Controls.Add(this.lbl_server);
			this.grp_login.Controls.Add(this.lbl_type);
			this.grp_login.Controls.Add(this.cbx_type);
			this.grp_login.Controls.Add(this.chx_rememberMe);
			this.grp_login.Controls.Add(this.txt_server);
			this.grp_login.Controls.Add(this.txt_pw);
			this.grp_login.Controls.Add(this.cbx_authent);
			this.grp_login.Controls.Add(this.txt_username);
			this.grp_login.Location = new System.Drawing.Point(12, 30);
			this.grp_login.Name = "grp_login";
			this.grp_login.Size = new System.Drawing.Size(353, 208);
			this.grp_login.TabIndex = 8;
			this.grp_login.TabStop = false;
			this.grp_login.Text = "Login";
			// 
			// btn_browse
			// 
			this.btn_browse.Location = new System.Drawing.Point(315, 46);
			this.btn_browse.Name = "btn_browse";
			this.btn_browse.Size = new System.Drawing.Size(32, 20);
			this.btn_browse.TabIndex = 14;
			this.btn_browse.Text = "...";
			this.btn_browse.UseVisualStyleBackColor = true;
			this.btn_browse.Click += new System.EventHandler(this.Btn_browseClick);
			// 
			// lbl_defaultDb
			// 
			this.lbl_defaultDb.Location = new System.Drawing.Point(6, 180);
			this.lbl_defaultDb.Name = "lbl_defaultDb";
			this.lbl_defaultDb.Size = new System.Drawing.Size(100, 17);
			this.lbl_defaultDb.TabIndex = 13;
			this.lbl_defaultDb.Text = "Base par défaut";
			// 
			// txt_defaultDatabase
			// 
			this.txt_defaultDatabase.Location = new System.Drawing.Point(125, 177);
			this.txt_defaultDatabase.Name = "txt_defaultDatabase";
			this.txt_defaultDatabase.Size = new System.Drawing.Size(222, 20);
			this.txt_defaultDatabase.TabIndex = 7;
			// 
			// lbl_pw
			// 
			this.lbl_pw.Location = new System.Drawing.Point(29, 128);
			this.lbl_pw.Name = "lbl_pw";
			this.lbl_pw.Size = new System.Drawing.Size(90, 17);
			this.lbl_pw.TabIndex = 11;
			this.lbl_pw.Text = "Mot de passe";
			// 
			// lbl_username
			// 
			this.lbl_username.Location = new System.Drawing.Point(29, 102);
			this.lbl_username.Name = "lbl_username";
			this.lbl_username.Size = new System.Drawing.Size(77, 17);
			this.lbl_username.TabIndex = 10;
			this.lbl_username.Text = "Utilisateur";
			// 
			// lbl_authent
			// 
			this.lbl_authent.Location = new System.Drawing.Point(6, 75);
			this.lbl_authent.Name = "lbl_authent";
			this.lbl_authent.Size = new System.Drawing.Size(100, 18);
			this.lbl_authent.TabIndex = 9;
			this.lbl_authent.Text = "Authentification";
			// 
			// lbl_server
			// 
			this.lbl_server.Location = new System.Drawing.Point(6, 49);
			this.lbl_server.Name = "lbl_server";
			this.lbl_server.Size = new System.Drawing.Size(100, 17);
			this.lbl_server.TabIndex = 8;
			this.lbl_server.Text = "Adresse du serveur";
			// 
			// lbl_type
			// 
			this.lbl_type.Location = new System.Drawing.Point(6, 22);
			this.lbl_type.Name = "lbl_type";
			this.lbl_type.Size = new System.Drawing.Size(100, 18);
			this.lbl_type.TabIndex = 7;
			this.lbl_type.Text = "Type de connexion";
			// 
			// grp_register
			// 
			this.grp_register.Controls.Add(this.lbl_serverColor);
			this.grp_register.Controls.Add(this.lbl_serverName);
			this.grp_register.Controls.Add(this.pan_color);
			this.grp_register.Controls.Add(this.txt_serverName);
			this.grp_register.Location = new System.Drawing.Point(12, 244);
			this.grp_register.Name = "grp_register";
			this.grp_register.Size = new System.Drawing.Size(353, 71);
			this.grp_register.TabIndex = 9;
			this.grp_register.TabStop = false;
			this.grp_register.Text = "Paramètres du serveur";
			// 
			// lbl_serverColor
			// 
			this.lbl_serverColor.Location = new System.Drawing.Point(6, 45);
			this.lbl_serverColor.Name = "lbl_serverColor";
			this.lbl_serverColor.Size = new System.Drawing.Size(100, 16);
			this.lbl_serverColor.TabIndex = 3;
			this.lbl_serverColor.Text = "Couleur du serveur";
			// 
			// lbl_serverName
			// 
			this.lbl_serverName.Location = new System.Drawing.Point(6, 22);
			this.lbl_serverName.Name = "lbl_serverName";
			this.lbl_serverName.Size = new System.Drawing.Size(100, 23);
			this.lbl_serverName.TabIndex = 2;
			this.lbl_serverName.Text = "Nom du serveur";
			// 
			// pan_color
			// 
			this.pan_color.BackColor = System.Drawing.SystemColors.WindowText;
			this.pan_color.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pan_color.Location = new System.Drawing.Point(125, 45);
			this.pan_color.Name = "pan_color";
			this.pan_color.Size = new System.Drawing.Size(16, 16);
			this.pan_color.TabIndex = 9;
			this.pan_color.Click += new System.EventHandler(this.Pan_colorClick);
			// 
			// txt_serverName
			// 
			this.txt_serverName.Location = new System.Drawing.Point(125, 19);
			this.txt_serverName.Name = "txt_serverName";
			this.txt_serverName.Size = new System.Drawing.Size(222, 20);
			this.txt_serverName.TabIndex = 8;
			// 
			// btn_ok
			// 
			this.btn_ok.Location = new System.Drawing.Point(290, 321);
			this.btn_ok.Name = "btn_ok";
			this.btn_ok.Size = new System.Drawing.Size(75, 23);
			this.btn_ok.TabIndex = 10;
			this.btn_ok.Text = "OK";
			this.btn_ok.UseVisualStyleBackColor = true;
			this.btn_ok.Click += new System.EventHandler(this.Btn_okClick);
			// 
			// btn_annuler
			// 
			this.btn_annuler.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_annuler.Location = new System.Drawing.Point(209, 321);
			this.btn_annuler.Name = "btn_annuler";
			this.btn_annuler.Size = new System.Drawing.Size(75, 23);
			this.btn_annuler.TabIndex = 11;
			this.btn_annuler.Text = "Annuler";
			this.btn_annuler.UseVisualStyleBackColor = true;
			this.btn_annuler.Click += new System.EventHandler(this.Btn_annulerClick);
			// 
			// btn_test
			// 
			this.btn_test.Location = new System.Drawing.Point(128, 321);
			this.btn_test.Name = "btn_test";
			this.btn_test.Size = new System.Drawing.Size(75, 23);
			this.btn_test.TabIndex = 12;
			this.btn_test.Text = "Tester";
			this.btn_test.UseVisualStyleBackColor = true;
			this.btn_test.Click += new System.EventHandler(this.Btn_testClick);
			// 
			// mnu_MsSqlServers
			// 
			this.mnu_MsSqlServers.Name = "mnu_servers";
			this.mnu_MsSqlServers.ShowImageMargin = false;
			this.mnu_MsSqlServers.Size = new System.Drawing.Size(36, 4);
			// 
			// bgw_populateMsSqlServerMenu
			// 
			this.bgw_populateMsSqlServerMenu.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Bgw_populateMsSqlServerMenuDoWork);
			this.bgw_populateMsSqlServerMenu.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.Bgw_populateMenuRunWorkerCompleted);
			// 
			// ofd_sqlite
			// 
			this.ofd_sqlite.DefaultExt = "sqlite";
			this.ofd_sqlite.Filter = "Fichiers SQLite|*.sqlite|Tous les fichiers|*.*";
			this.ofd_sqlite.RestoreDirectory = true;
			// 
			// bgw_populateMySqlServerMenu
			// 
			this.bgw_populateMySqlServerMenu.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Bgw_populateMySqlServerMenuDoWork);
			// 
			// mnu_MySqlServers
			// 
			this.mnu_MySqlServers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.notYetImplementedToolStripMenuItem});
			this.mnu_MySqlServers.Name = "contextMenuStrip1";
			this.mnu_MySqlServers.ShowImageMargin = false;
			this.mnu_MySqlServers.Size = new System.Drawing.Size(163, 48);
			// 
			// notYetImplementedToolStripMenuItem
			// 
			this.notYetImplementedToolStripMenuItem.Enabled = false;
			this.notYetImplementedToolStripMenuItem.Name = "notYetImplementedToolStripMenuItem";
			this.notYetImplementedToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
			this.notYetImplementedToolStripMenuItem.Text = "Not yet implemented";
			// 
			// frm_newServer
			// 
			this.AcceptButton = this.btn_ok;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btn_annuler;
			this.ClientSize = new System.Drawing.Size(377, 353);
			this.ControlBox = false;
			this.Controls.Add(this.btn_test);
			this.Controls.Add(this.btn_annuler);
			this.Controls.Add(this.btn_ok);
			this.Controls.Add(this.grp_register);
			this.Controls.Add(this.grp_login);
			this.Controls.Add(this.lbl_title);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "frm_newServer";
			this.Text = "Ajouter une serveur";
			this.grp_login.ResumeLayout(false);
			this.grp_login.PerformLayout();
			this.grp_register.ResumeLayout(false);
			this.grp_register.PerformLayout();
			this.mnu_MySqlServers.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.ToolStripMenuItem notYetImplementedToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip mnu_MySqlServers;
		private System.ComponentModel.BackgroundWorker bgw_populateMySqlServerMenu;
		private System.Windows.Forms.OpenFileDialog ofd_sqlite;
		private System.ComponentModel.BackgroundWorker bgw_populateMsSqlServerMenu;
		private System.Windows.Forms.ContextMenuStrip mnu_MsSqlServers;
		private System.Windows.Forms.Button btn_browse;
		private System.Windows.Forms.Label lbl_defaultDb;
		private System.Windows.Forms.Label lbl_title;
		private System.Windows.Forms.TextBox txt_defaultDatabase;
		private System.Windows.Forms.ColorDialog cld;
		private System.Windows.Forms.Button btn_test;
		private System.Windows.Forms.Button btn_annuler;
		private System.Windows.Forms.Button btn_ok;
		private System.Windows.Forms.Label lbl_serverColor;
		private System.Windows.Forms.Label lbl_serverName;
		private System.Windows.Forms.Panel pan_color;
		private System.Windows.Forms.TextBox txt_serverName;
		private System.Windows.Forms.CheckBox chx_rememberMe;
		private System.Windows.Forms.TextBox txt_pw;
		private System.Windows.Forms.TextBox txt_username;
		private System.Windows.Forms.ComboBox cbx_authent;
		private System.Windows.Forms.TextBox txt_server;
		private System.Windows.Forms.ComboBox cbx_type;
		private System.Windows.Forms.Label lbl_pw;
		private System.Windows.Forms.Label lbl_username;
		private System.Windows.Forms.Label lbl_authent;
		private System.Windows.Forms.Label lbl_server;
		private System.Windows.Forms.Label lbl_type;
		private System.Windows.Forms.GroupBox grp_register;
		private System.Windows.Forms.GroupBox grp_login;
	}
}
