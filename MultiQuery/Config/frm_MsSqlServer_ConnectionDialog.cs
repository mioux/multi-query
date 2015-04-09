/*
 * Crée par SharpDevelop.
 * Utilisateur: SRUMEU
 * Date: 09/04/2015
 * Heure: 17:03
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MultiQuery.Config
{
	/// <summary>
	/// Description of frm_MsSqlServer_ConnectionDialog.
	/// </summary>
	public partial class frm_MsSqlServer_ConnectionDialog : Form
	{
		public frm_MsSqlServer_ConnectionDialog()
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
		/// 
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
		
		void Btn_okClick(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		
		void Btn_annulerClick(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
		}
	}
}
