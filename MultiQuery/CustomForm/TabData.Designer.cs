/*
 * Crée par SharpDevelop.
 * Utilisateur: SRUMEU
 * Date: 01/04/2015
 * Heure: 15:06
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */

namespace MultiQuery.CustomForm
{
	partial class TabData
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
			this.dgv_data = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.dgv_data)).BeginInit();
			this.SuspendLayout();
			// 
			// dgv_data
			// 
			this.dgv_data.AllowUserToAddRows = false;
			this.dgv_data.AllowUserToDeleteRows = false;
			this.dgv_data.AllowUserToOrderColumns = true;
			this.dgv_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv_data.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgv_data.Location = new System.Drawing.Point(0, 0);
			this.dgv_data.Name = "dgv_data";
			this.dgv_data.Size = new System.Drawing.Size(150, 150);
			this.dgv_data.TabIndex = 0;
			// 
			// TabData
			// 
			//this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			//this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.dgv_data);
			this.Name = "TabData";
			((System.ComponentModel.ISupportInitialize)(this.dgv_data)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.DataGridView dgv_data;
	}
}
