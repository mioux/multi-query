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
			this.exporterServerListxmlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.importerServerListxmlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
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
			this.tbp_request = new System.Windows.Forms.TabPage();
			this.tec_request = new ICSharpCode.TextEditor.TextEditorControl();
			this.bgw_executeQuery = new System.ComponentModel.BackgroundWorker();
			this.sfd_export = new System.Windows.Forms.SaveFileDialog();
			this.ofd_import = new System.Windows.Forms.OpenFileDialog();
			this.aOTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mnu_main.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.spc_main)).BeginInit();
			this.spc_main.Panel1.SuspendLayout();
			this.spc_main.Panel2.SuspendLayout();
			this.spc_main.SuspendLayout();
			this.tbc_result.SuspendLayout();
			this.tbp_request.SuspendLayout();
			this.SuspendLayout();
			// 
			// mnu_main
			// 
			this.mnu_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.fichierToolStripMenuItem,
									this.serveurToolStripMenuItem,
									this.aOTToolStripMenuItem});
			resources.ApplyResources(this.mnu_main, "mnu_main");
			this.mnu_main.Name = "mnu_main";
			// 
			// fichierToolStripMenuItem
			// 
			this.fichierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.exporterServerListxmlToolStripMenuItem,
									this.importerServerListxmlToolStripMenuItem,
									this.toolStripSeparator2,
									this.quitterToolStripMenuItem});
			this.fichierToolStripMenuItem.Name = "fichierToolStripMenuItem";
			resources.ApplyResources(this.fichierToolStripMenuItem, "fichierToolStripMenuItem");
			// 
			// exporterServerListxmlToolStripMenuItem
			// 
			resources.ApplyResources(this.exporterServerListxmlToolStripMenuItem, "exporterServerListxmlToolStripMenuItem");
			this.exporterServerListxmlToolStripMenuItem.Name = "exporterServerListxmlToolStripMenuItem";
			this.exporterServerListxmlToolStripMenuItem.Click += new System.EventHandler(this.ExporterServerListxmlToolStripMenuItemClick);
			// 
			// importerServerListxmlToolStripMenuItem
			// 
			resources.ApplyResources(this.importerServerListxmlToolStripMenuItem, "importerServerListxmlToolStripMenuItem");
			this.importerServerListxmlToolStripMenuItem.Name = "importerServerListxmlToolStripMenuItem";
			this.importerServerListxmlToolStripMenuItem.Click += new System.EventHandler(this.ImporterServerListxmlToolStripMenuItemClick);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
			// 
			// quitterToolStripMenuItem
			// 
			resources.ApplyResources(this.quitterToolStripMenuItem, "quitterToolStripMenuItem");
			this.quitterToolStripMenuItem.Name = "quitterToolStripMenuItem";
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
			resources.ApplyResources(this.serveurToolStripMenuItem, "serveurToolStripMenuItem");
			// 
			// ajouterToolStripMenuItem
			// 
			resources.ApplyResources(this.ajouterToolStripMenuItem, "ajouterToolStripMenuItem");
			this.ajouterToolStripMenuItem.Name = "ajouterToolStripMenuItem";
			this.ajouterToolStripMenuItem.Click += new System.EventHandler(this.AjouterToolStripMenuItemClick);
			// 
			// supprimerToolStripMenuItem
			// 
			resources.ApplyResources(this.supprimerToolStripMenuItem, "supprimerToolStripMenuItem");
			this.supprimerToolStripMenuItem.Name = "supprimerToolStripMenuItem";
			this.supprimerToolStripMenuItem.Click += new System.EventHandler(this.SupprimerToolStripMenuItemClick);
			// 
			// editerLesServeursToolStripMenuItem
			// 
			resources.ApplyResources(this.editerLesServeursToolStripMenuItem, "editerLesServeursToolStripMenuItem");
			this.editerLesServeursToolStripMenuItem.Name = "editerLesServeursToolStripMenuItem";
			this.editerLesServeursToolStripMenuItem.Click += new System.EventHandler(this.EditerLeServeurToolStripMenuItemClick);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
			// 
			// exécuterSurLesServeursSélectionnésToolStripMenuItem
			// 
			resources.ApplyResources(this.exécuterSurLesServeursSélectionnésToolStripMenuItem, "exécuterSurLesServeursSélectionnésToolStripMenuItem");
			this.exécuterSurLesServeursSélectionnésToolStripMenuItem.Name = "exécuterSurLesServeursSélectionnésToolStripMenuItem";
			this.exécuterSurLesServeursSélectionnésToolStripMenuItem.Click += new System.EventHandler(this.ExecuterSurLesServeursSelectionnesToolStripMenuItemClick);
			// 
			// exécuterSurTousLesServeursToolStripMenuItem
			// 
			resources.ApplyResources(this.exécuterSurTousLesServeursToolStripMenuItem, "exécuterSurTousLesServeursToolStripMenuItem");
			this.exécuterSurTousLesServeursToolStripMenuItem.Name = "exécuterSurTousLesServeursToolStripMenuItem";
			this.exécuterSurTousLesServeursToolStripMenuItem.Click += new System.EventHandler(this.ExecuterSurTousLesServeursToolStripMenuItemClick);
			// 
			// spc_main
			// 
			resources.ApplyResources(this.spc_main, "spc_main");
			this.spc_main.Name = "spc_main";
			// 
			// spc_main.Panel1
			// 
			this.spc_main.Panel1.Controls.Add(this.clb_serverList);
			// 
			// spc_main.Panel2
			// 
			this.spc_main.Panel2.Controls.Add(this.tbc_result);
			// 
			// clb_serverList
			// 
			resources.ApplyResources(this.clb_serverList, "clb_serverList");
			this.clb_serverList.Name = "clb_serverList";
			// 
			// tbc_result
			// 
			this.tbc_result.Controls.Add(this.tbp_request);
			resources.ApplyResources(this.tbc_result, "tbc_result");
			this.tbc_result.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
			this.tbc_result.Name = "tbc_result";
			this.tbc_result.SelectedIndex = 0;
			this.tbc_result.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.Tbc_resultDrawItem);
			// 
			// tbp_request
			// 
			this.tbp_request.Controls.Add(this.tec_request);
			resources.ApplyResources(this.tbp_request, "tbp_request");
			this.tbp_request.Name = "tbp_request";
			this.tbp_request.UseVisualStyleBackColor = true;
			// 
			// tec_request
			// 
			resources.ApplyResources(this.tec_request, "tec_request");
			this.tec_request.IsReadOnly = false;
			this.tec_request.Name = "tec_request";
			// 
			// aOTToolStripMenuItem
			// 
			resources.ApplyResources(this.aOTToolStripMenuItem, "aOTToolStripMenuItem");
			this.aOTToolStripMenuItem.Name = "aOTToolStripMenuItem";
			this.aOTToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("unpined")));
			this.aOTToolStripMenuItem.Click += new System.EventHandler(this.AOTToolStripMenuItemClick);
			// 
			// frm_main
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.spc_main);
			this.Controls.Add(this.mnu_main);
			this.MainMenuStrip = this.mnu_main;
			this.Name = "frm_main";
			this.mnu_main.ResumeLayout(false);
			this.mnu_main.PerformLayout();
			this.spc_main.Panel1.ResumeLayout(false);
			this.spc_main.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.spc_main)).EndInit();
			this.spc_main.ResumeLayout(false);
			this.tbc_result.ResumeLayout(false);
			this.tbp_request.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ToolStripMenuItem aOTToolStripMenuItem;
		public ICSharpCode.TextEditor.TextEditorControl tec_request;
		private System.Windows.Forms.TabPage tbp_request;
		private System.Windows.Forms.OpenFileDialog ofd_import;
		private System.Windows.Forms.SaveFileDialog sfd_export;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem importerServerListxmlToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exporterServerListxmlToolStripMenuItem;
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
