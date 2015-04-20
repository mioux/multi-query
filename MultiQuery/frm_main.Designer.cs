/*
 * Crée par SharpDevelop.
 * Utilisateur: SRUMEU
 * Date: 25/03/2015
 * Heure: 16:57
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
namespace MultiQuery
{
	partial class frm_main
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_main));
			this.mnu_main = new System.Windows.Forms.MenuStrip();
			this.fichierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.quitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.serveurToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ajouterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.supprimerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editerLesServeursToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.exécuterSurLesServeursSélectionnésToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exécuterSurTousLesServeursToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.spc_main = new System.Windows.Forms.SplitContainer();
			this.clb_serverList = new MultiQuery.CustomForm.CheckListBox();
			this.tbc_result = new System.Windows.Forms.TabControl();
			this.bgw_executeQuery = new System.ComponentModel.BackgroundWorker();
			this.mnu_main.SuspendLayout();
			this.spc_main.Panel1.SuspendLayout();
			this.spc_main.Panel2.SuspendLayout();
			this.spc_main.SuspendLayout();
			this.SuspendLayout();
			// 
			// mnu_main
			// 
			this.mnu_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.fichierToolStripMenuItem,
									this.serveurToolStripMenuItem});
			this.mnu_main.Location = new System.Drawing.Point(0, 0);
			this.mnu_main.Name = "mnu_main";
			this.mnu_main.Size = new System.Drawing.Size(632, 24);
			this.mnu_main.TabIndex = 0;
			this.mnu_main.Text = "menuStrip1";
			// 
			// fichierToolStripMenuItem
			// 
			this.fichierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.quitterToolStripMenuItem});
			this.fichierToolStripMenuItem.Name = "fichierToolStripMenuItem";
			this.fichierToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
			this.fichierToolStripMenuItem.Text = "Fichier";
			// 
			// quitterToolStripMenuItem
			// 
			this.quitterToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("quitterToolStripMenuItem.Image")));
			this.quitterToolStripMenuItem.Name = "quitterToolStripMenuItem";
			this.quitterToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
			this.quitterToolStripMenuItem.Text = "&Quitter";
			this.quitterToolStripMenuItem.Click += new System.EventHandler(this.QuitterToolStripMenuItemClick);
			// 
			// serveurToolStripMenuItem
			// 
			this.serveurToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.ajouterToolStripMenuItem,
									this.supprimerToolStripMenuItem,
									this.editerLesServeursToolStripMenuItem,
									this.toolStripSeparator1,
									this.exécuterSurLesServeursSélectionnésToolStripMenuItem,
									this.exécuterSurTousLesServeursToolStripMenuItem});
			this.serveurToolStripMenuItem.Name = "serveurToolStripMenuItem";
			this.serveurToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
			this.serveurToolStripMenuItem.Text = "Serveur";
			// 
			// ajouterToolStripMenuItem
			// 
			this.ajouterToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ajouterToolStripMenuItem.Image")));
			this.ajouterToolStripMenuItem.Name = "ajouterToolStripMenuItem";
			this.ajouterToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
			this.ajouterToolStripMenuItem.Text = "&Ajouter";
			this.ajouterToolStripMenuItem.Click += new System.EventHandler(this.AjouterToolStripMenuItemClick);
			// 
			// supprimerToolStripMenuItem
			// 
			this.supprimerToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("supprimerToolStripMenuItem.Image")));
			this.supprimerToolStripMenuItem.Name = "supprimerToolStripMenuItem";
			this.supprimerToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
			this.supprimerToolStripMenuItem.Text = "&Supprimer";
			this.supprimerToolStripMenuItem.Click += new System.EventHandler(this.SupprimerToolStripMenuItemClick);
			// 
			// editerLesServeursToolStripMenuItem
			// 
			this.editerLesServeursToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("editerLesServeursToolStripMenuItem.Image")));
			this.editerLesServeursToolStripMenuItem.Name = "editerLesServeursToolStripMenuItem";
			this.editerLesServeursToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
			this.editerLesServeursToolStripMenuItem.Text = "É&diter le serveur";
			this.editerLesServeursToolStripMenuItem.Click += new System.EventHandler(this.EditerLeServeurToolStripMenuItemClick);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(265, 6);
			// 
			// exécuterSurLesServeursSélectionnésToolStripMenuItem
			// 
			this.exécuterSurLesServeursSélectionnésToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exécuterSurLesServeursSélectionnésToolStripMenuItem.Image")));
			this.exécuterSurLesServeursSélectionnésToolStripMenuItem.Name = "exécuterSurLesServeursSélectionnésToolStripMenuItem";
			this.exécuterSurLesServeursSélectionnésToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
			this.exécuterSurLesServeursSélectionnésToolStripMenuItem.Text = "&Exécuter sur les serveurs sélectionnés";
			this.exécuterSurLesServeursSélectionnésToolStripMenuItem.Click += new System.EventHandler(this.ExécuterSurLesServeursSélectionnésToolStripMenuItemClick);
			// 
			// exécuterSurTousLesServeursToolStripMenuItem
			// 
			this.exécuterSurTousLesServeursToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exécuterSurTousLesServeursToolStripMenuItem.Image")));
			this.exécuterSurTousLesServeursToolStripMenuItem.Name = "exécuterSurTousLesServeursToolStripMenuItem";
			this.exécuterSurTousLesServeursToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
			this.exécuterSurTousLesServeursToolStripMenuItem.Text = "E&xécuter sur tous les serveurs";
			this.exécuterSurTousLesServeursToolStripMenuItem.Click += new System.EventHandler(this.ExécuterSurTousLesServeursToolStripMenuItemClick);
			// 
			// spc_main
			// 
			this.spc_main.Dock = System.Windows.Forms.DockStyle.Fill;
			this.spc_main.Location = new System.Drawing.Point(0, 24);
			this.spc_main.Name = "spc_main";
			// 
			// spc_main.Panel1
			// 
			this.spc_main.Panel1.Controls.Add(this.clb_serverList);
			// 
			// spc_main.Panel2
			// 
			this.spc_main.Panel2.Controls.Add(this.tbc_result);
			this.spc_main.Size = new System.Drawing.Size(632, 431);
			this.spc_main.SplitterDistance = 210;
			this.spc_main.TabIndex = 1;
			// 
			// clb_serverList
			// 
			this.clb_serverList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.clb_serverList.Location = new System.Drawing.Point(0, 0);
			this.clb_serverList.Name = "clb_serverList";
			this.clb_serverList.Size = new System.Drawing.Size(210, 431);
			this.clb_serverList.TabIndex = 0;
			// 
			// tbc_result
			// 
			this.tbc_result.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbc_result.Location = new System.Drawing.Point(0, 0);
			this.tbc_result.Name = "tbc_result";
			this.tbc_result.SelectedIndex = 0;
			this.tbc_result.Size = new System.Drawing.Size(418, 431);
			this.tbc_result.TabIndex = 0;
			// 
			// frm_main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(632, 455);
			this.Controls.Add(this.spc_main);
			this.Controls.Add(this.mnu_main);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.mnu_main;
			this.Name = "frm_main";
			this.Text = "multi-query";
			this.mnu_main.ResumeLayout(false);
			this.mnu_main.PerformLayout();
			this.spc_main.Panel1.ResumeLayout(false);
			this.spc_main.Panel2.ResumeLayout(false);
			this.spc_main.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ToolStripMenuItem editerLesServeursToolStripMenuItem;
		private MultiQuery.CustomForm.CheckListBox clb_serverList;
		private System.ComponentModel.BackgroundWorker bgw_executeQuery;
		private System.Windows.Forms.MenuStrip mnu_main;
		private System.Windows.Forms.TabControl tbc_result;
		private System.Windows.Forms.SplitContainer spc_main;
		private System.Windows.Forms.ToolStripMenuItem exécuterSurTousLesServeursToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exécuterSurLesServeursSélectionnésToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem supprimerToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ajouterToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem serveurToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem quitterToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fichierToolStripMenuItem;
	}
}
