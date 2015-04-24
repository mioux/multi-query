/*
 * Crée par SharpDevelop.
 * Utilisateur: SRUMEU
 * Date: 02/04/2015
 * Heure: 12:59
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
namespace MultiQuery.Forms
{
	partial class frm_sql
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
			this.btn_ok = new System.Windows.Forms.Button();
			this.btn_cancel = new System.Windows.Forms.Button();
			this.pan_sql = new System.Windows.Forms.Panel();
			this.rtb_sql = new ICSharpCode.TextEditor.TextEditorControl();
			this.pan_sql.SuspendLayout();
			this.SuspendLayout();
			// 
			// btn_ok
			// 
			this.btn_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_ok.Location = new System.Drawing.Point(383, 379);
			this.btn_ok.Name = "btn_ok";
			this.btn_ok.Size = new System.Drawing.Size(75, 23);
			this.btn_ok.TabIndex = 0;
			this.btn_ok.Text = "OK";
			this.btn_ok.UseVisualStyleBackColor = true;
			this.btn_ok.Click += new System.EventHandler(this.Btn_okClick);
			// 
			// btn_cancel
			// 
			this.btn_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_cancel.Location = new System.Drawing.Point(302, 379);
			this.btn_cancel.Name = "btn_cancel";
			this.btn_cancel.Size = new System.Drawing.Size(75, 23);
			this.btn_cancel.TabIndex = 1;
			this.btn_cancel.Text = "Annuler";
			this.btn_cancel.UseVisualStyleBackColor = true;
			this.btn_cancel.Click += new System.EventHandler(this.Btn_cancelClick);
			// 
			// pan_sql
			// 
			this.pan_sql.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.pan_sql.Controls.Add(this.rtb_sql);
			this.pan_sql.Location = new System.Drawing.Point(12, 12);
			this.pan_sql.Name = "pan_sql";
			this.pan_sql.Size = new System.Drawing.Size(446, 361);
			this.pan_sql.TabIndex = 2;
			// 
			// rtb_sql
			// 
			this.rtb_sql.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rtb_sql.IsReadOnly = false;
			this.rtb_sql.Location = new System.Drawing.Point(0, 0);
			this.rtb_sql.Name = "rtb_sql";
			this.rtb_sql.Size = new System.Drawing.Size(446, 361);
			this.rtb_sql.TabIndex = 0;
			// 
			// frm_sql
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(469, 411);
			this.ControlBox = false;
			this.Controls.Add(this.pan_sql);
			this.Controls.Add(this.btn_cancel);
			this.Controls.Add(this.btn_ok);
			this.Name = "frm_sql";
			this.Text = "Exécuter SQL";
			this.pan_sql.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private ICSharpCode.TextEditor.TextEditorControl rtb_sql;
		private System.Windows.Forms.Panel pan_sql;
		private System.Windows.Forms.Button btn_cancel;
		private System.Windows.Forms.Button btn_ok;
	}
}
