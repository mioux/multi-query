/*
 * Crée par SharpDevelop.
 * Utilisateur: SRUMEU
 * Date: 09/04/2015
 * Heure: 17:03
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
namespace MultiQuery.Config
{
	partial class frm_MsSqlServer_ConnectionDialog
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
			this.lbl_pw = new System.Windows.Forms.Label();
			this.lbl_username = new System.Windows.Forms.Label();
			this.lbl_authent = new System.Windows.Forms.Label();
			this.chx_rememberMe = new System.Windows.Forms.CheckBox();
			this.txt_pw = new System.Windows.Forms.TextBox();
			this.cbx_authent = new System.Windows.Forms.ComboBox();
			this.txt_username = new System.Windows.Forms.TextBox();
			this.btn_annuler = new System.Windows.Forms.Button();
			this.btn_ok = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lbl_pw
			// 
			this.lbl_pw.Location = new System.Drawing.Point(32, 68);
			this.lbl_pw.Name = "lbl_pw";
			this.lbl_pw.Size = new System.Drawing.Size(90, 17);
			this.lbl_pw.TabIndex = 18;
			this.lbl_pw.Text = "Mot de passe";
			// 
			// lbl_username
			// 
			this.lbl_username.Location = new System.Drawing.Point(32, 42);
			this.lbl_username.Name = "lbl_username";
			this.lbl_username.Size = new System.Drawing.Size(77, 17);
			this.lbl_username.TabIndex = 17;
			this.lbl_username.Text = "Utilisateur";
			// 
			// lbl_authent
			// 
			this.lbl_authent.Location = new System.Drawing.Point(9, 15);
			this.lbl_authent.Name = "lbl_authent";
			this.lbl_authent.Size = new System.Drawing.Size(100, 18);
			this.lbl_authent.TabIndex = 16;
			this.lbl_authent.Text = "Authentification";
			// 
			// chx_rememberMe
			// 
			this.chx_rememberMe.Enabled = false;
			this.chx_rememberMe.Location = new System.Drawing.Point(145, 91);
			this.chx_rememberMe.Name = "chx_rememberMe";
			this.chx_rememberMe.Size = new System.Drawing.Size(143, 20);
			this.chx_rememberMe.TabIndex = 15;
			this.chx_rememberMe.Text = "Se souvenir de moi.";
			this.chx_rememberMe.UseVisualStyleBackColor = true;
			// 
			// txt_pw
			// 
			this.txt_pw.Enabled = false;
			this.txt_pw.Location = new System.Drawing.Point(145, 65);
			this.txt_pw.Name = "txt_pw";
			this.txt_pw.Size = new System.Drawing.Size(205, 20);
			this.txt_pw.TabIndex = 14;
			this.txt_pw.UseSystemPasswordChar = true;
			// 
			// cbx_authent
			// 
			this.cbx_authent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbx_authent.FormattingEnabled = true;
			this.cbx_authent.Items.AddRange(new object[] {
									"Authentification Windows",
									"Authentification par login/mot de passe."});
			this.cbx_authent.Location = new System.Drawing.Point(128, 12);
			this.cbx_authent.Name = "cbx_authent";
			this.cbx_authent.Size = new System.Drawing.Size(222, 21);
			this.cbx_authent.TabIndex = 12;
			this.cbx_authent.SelectedIndexChanged += new System.EventHandler(this.Cbx_authentSelectedIndexChanged);
			// 
			// txt_username
			// 
			this.txt_username.Enabled = false;
			this.txt_username.Location = new System.Drawing.Point(145, 39);
			this.txt_username.Name = "txt_username";
			this.txt_username.Size = new System.Drawing.Size(205, 20);
			this.txt_username.TabIndex = 13;
			// 
			// btn_annuler
			// 
			this.btn_annuler.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_annuler.Location = new System.Drawing.Point(194, 117);
			this.btn_annuler.Name = "btn_annuler";
			this.btn_annuler.Size = new System.Drawing.Size(75, 23);
			this.btn_annuler.TabIndex = 20;
			this.btn_annuler.Text = "Annuler";
			this.btn_annuler.UseVisualStyleBackColor = true;
			this.btn_annuler.Click += new System.EventHandler(this.Btn_annulerClick);
			// 
			// btn_ok
			// 
			this.btn_ok.Location = new System.Drawing.Point(275, 117);
			this.btn_ok.Name = "btn_ok";
			this.btn_ok.Size = new System.Drawing.Size(75, 23);
			this.btn_ok.TabIndex = 19;
			this.btn_ok.Text = "OK";
			this.btn_ok.UseVisualStyleBackColor = true;
			this.btn_ok.Click += new System.EventHandler(this.Btn_okClick);
			// 
			// frm_MsSqlServer_ConnectionDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(365, 148);
			this.Controls.Add(this.btn_annuler);
			this.Controls.Add(this.btn_ok);
			this.Controls.Add(this.lbl_pw);
			this.Controls.Add(this.lbl_username);
			this.Controls.Add(this.lbl_authent);
			this.Controls.Add(this.chx_rememberMe);
			this.Controls.Add(this.txt_pw);
			this.Controls.Add(this.cbx_authent);
			this.Controls.Add(this.txt_username);
			this.Name = "frm_MsSqlServer_ConnectionDialog";
			this.Text = "frm_MsSqlServer_ConnectionDialog";
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Button btn_ok;
		private System.Windows.Forms.Button btn_annuler;
		private System.Windows.Forms.TextBox txt_username;
		private System.Windows.Forms.ComboBox cbx_authent;
		private System.Windows.Forms.TextBox txt_pw;
		private System.Windows.Forms.CheckBox chx_rememberMe;
		private System.Windows.Forms.Label lbl_authent;
		private System.Windows.Forms.Label lbl_username;
		private System.Windows.Forms.Label lbl_pw;
	}
}
