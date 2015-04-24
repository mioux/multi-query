/*
 * Crée par SharpDevelop.
 * Utilisateur: SRUMEU
 * Date: 01/04/2015
 * Heure: 15:06
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MultiQuery.CustomForm
{
	/// <summary>
	/// Description of TabData.
	/// </summary>
	public partial class TabData : TabPage
	{
		public TabData()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
		}
		
		/// <summary>
		/// Source de données.
		/// </summary>
		
		public object DataSource { get { return dgv_data.DataSource; } set { dgv_data.DataSource = value; } }
	}
}
