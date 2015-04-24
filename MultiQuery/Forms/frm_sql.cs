/*
 * Crée par SharpDevelop.
 * Utilisateur: SRUMEU
 * Date: 02/04/2015
 * Heure: 12:59
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using ICSharpCode.TextEditor.Document;

namespace MultiQuery.Forms
{
	/// <summary>
	/// Description of frm_sql.
	/// </summary>
	public partial class frm_sql : Form
	{
		public string Data { get { return rtb_sql.Text; } private set { } }
		
		public frm_sql()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			if (File.Exists("last.sql"))
			{
				try
				{
					rtb_sql.Text = File.ReadAllText("last.sql");
				}
				catch (Exception exp)
				{
					MessageBox.Show("Erreur lors de la lecture de la dernière requête utilisée.\n" + exp.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			
			string dir = @".\hl\"; // Insert the path to your xshd-files.
			FileSyntaxModeProvider fsmProvider; // Provider
			if (Directory.Exists(dir))
			{
			    fsmProvider = new FileSyntaxModeProvider(dir); // Create new provider with the highlighting directory.
			    HighlightingManager.Manager.AddSyntaxModeFileProvider(fsmProvider); // Attach to the text editor.
			    rtb_sql.SetHighlighting("sql"); // Activate the highlighting, use the name from the SyntaxDefinition node.
			}
		}
		
		/// <summary>
		/// Bouton OK
		/// </summary>
		/// <param name="sender">Objet appelant.</param>
		/// <param name="e">Arguments d'appel.</param>
		
		void Btn_okClick(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			try
			{
				File.WriteAllText("last.sql", rtb_sql.Text);
			}
			catch (Exception exp)
			{
				MessageBox.Show("Erreur lors de la sauvegarde de la dernière requête utilisée.\n" + exp.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			this.Close();
		}
		
		/// <summary>
		/// Annulation de la requête.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		
		void Btn_cancelClick(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
	}
}
