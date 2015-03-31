/*
 * Crée par SharpDevelop.
 * Utilisateur: SRUMEU
 * Date: 31/03/2015
 * Heure: 09:41
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
namespace MultiQuery.CustomForm
{
	partial class CheckListBox
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the control.
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
			this.lbx_main = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// lbx_main
			// 
			this.lbx_main.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lbx_main.FormattingEnabled = true;
			this.lbx_main.Location = new System.Drawing.Point(0, 0);
			this.lbx_main.Name = "lbx_main";
			this.lbx_main.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
			this.lbx_main.Size = new System.Drawing.Size(133, 95);
			this.lbx_main.TabIndex = 0;
			// 
			// CheckListBox
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.lbx_main);
			this.Name = "CheckListBox";
			this.Size = new System.Drawing.Size(133, 97);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.ListBox lbx_main;
	}
}
