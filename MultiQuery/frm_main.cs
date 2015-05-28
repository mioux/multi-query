/*
 * Crée par SharpDevelop.
 * Utilisateur: SRUMEU
 * Date: 25/03/2015
 * Heure: 16:57
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Xml;
//using System.Runtime.InteropServices;

using ICSharpCode.TextEditor.Document;
using MultiQuery.Config;
using MultiQuery.CustomForm;

namespace MultiQuery
{
	/// <summary>
	/// Description of frm_main.
	/// </summary>
	public partial class frm_main : Form
	{
		/// <summary>
		/// Constructeur.
		/// </summary>
		public frm_main()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			if (File.Exists("ServerList.xml"))
		    {
				ImportServers(false, "ServerList.xml");
		    }
			
			if (File.Exists("last.sql"))
			{
				try
				{
					tec_request.Text = File.ReadAllText("last.sql");
				}
				catch (Exception exp)
				{
					MessageBox.Show("Erreur lors de la lecture de la dernière requête utilisée.\n" + exp.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			
			string dir = @".\hl\";
			FileSyntaxModeProvider fsmProvider;
			if (Directory.Exists(dir))
			{
			    fsmProvider = new FileSyntaxModeProvider(dir);
			    HighlightingManager.Manager.AddSyntaxModeFileProvider(fsmProvider);
			    tec_request.SetHighlighting("sql");
			}
		}
		
		/// <summary>
		/// Mise à jour du fichier Settings.
		/// </summary>
		/// <param name="xml"></param>
		
		private void UpdateServerList(XmlDocument xml)
		{
			if (xml.DocumentElement == null)
				return;
			
			if (xml.DocumentElement.Attributes["version"] == null || 
		     	 xml.DocumentElement.Attributes["version"].Value == "" || 
		     	 Convert.ToInt32(xml.DocumentElement.Attributes["version"].Value) < 2)
			{
				if (xml.DocumentElement.Attributes["version"] == null)
				{
					XmlAttribute newAttribute = xml.CreateAttribute("version");
					newAttribute.Value = "2";
					
					xml.DocumentElement.Attributes.Append(newAttribute);
				}
				else
				{
					xml.DocumentElement.Attributes["version"].Value = "2";
				}
				
				XmlNodeList servers = xml.SelectNodes("/servers/server");
	    		foreach (XmlNode node in servers)
	    		{
	    			node.InnerText = Cypher.Chiffre(Cypher.DechiffreLegacy(node.InnerText));
	    		}
	    		
	    		xml.Save("ServerList.xml");
			}
		}
		
		/// <summary>
		/// Ajouter un serveur.
		/// </summary>
		/// <param name="sender">Objet appelant.</param>
		/// <param name="e">Arguments d'appel.</param>
		private void AjouterToolStripMenuItemClick(object sender, EventArgs e)
		{
			frm_newServer newServer = new frm_newServer();
			
			if (newServer.ShowDialog() == DialogResult.OK)
			{
				clb_serverList.AddServer(newServer.NewServer);
				
				SaveServerList();
			}
		}
		
		/// <summary>
		/// Supprimer les serveurs sélectionnés.
		/// </summary>
		/// <param name="sender">Objet appelant.</param>
		/// <param name="e">Arguments d'appel.</param>
		private void SupprimerToolStripMenuItemClick(object sender, EventArgs e)
		{
			List<int> liste = new List<int>();
			
			if (clb_serverList.SelectedIndices.Count > 0)
			{
				foreach (int index in clb_serverList.SelectedIndices)
				{
					liste.Add(index);
				}
			}
			
			liste.Sort();
			liste.Reverse();
			
			foreach (int index in liste)
			{
				clb_serverList.DeleteServer(index);
			}
			
			SaveServerList();
		}
		
		/// <summary>
		/// Exécuter une requête sur les serveurs cochés.
		/// </summary>
		/// <param name="sender">Objet appelant.</param>
		/// <param name="e">Arguments d'appel.</param>
		
		private void ExecuterSurLesServeursSelectionnesToolStripMenuItemClick(object sender, EventArgs e)
		{			
			ExecuteOnServers(clb_serverList.GetSelected());
		}
		
		/// <summary>
		/// Exécuter une requête sur les serveurs listés.
		/// </summary>
		/// <param name="list">Liste des serveurs.</param>
		
		public void ExecuteOnServers(Server.Server[] list)
		{
			if (list.Length == 0)
			{
				MessageBox.Show("Aucun serveur sélectionné", "Alerte", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			
			string sql = string.Empty;

			ClearPages();
			File.WriteAllText("last.sql", tec_request.Text);
			
			foreach(Server.Server srv in list)
			{
				AddNewResult(srv, tec_request.Text);
			}
			
			if (tbc_result.TabPages.Count > 1)
			{
				tbc_result.SelectedIndex = 1;
			}
		}
		
		/// <summary>
		/// Exécuter une requête sur tous les serveurs.
		/// </summary>
		/// <param name="sender">Objet appelant.</param>
		/// <param name="e">Arguments d'appel.</param>
		
		private void ExecuterSurTousLesServeursToolStripMenuItemClick(object sender, EventArgs e)
		{
			ExecuteOnServers(clb_serverList.GetAll());
		}
		
		/// <summary>
		/// Quitter l'application.
		/// </summary>
		/// <param name="sender">Objet appelant.</param>
		/// <param name="e">Arguments d'appel.</param>
		
		private void QuitterToolStripMenuItemClick(object sender, EventArgs e)
		{
			Environment.Exit(0);
		}
		
		/// <summary>
		/// Ajouter un résultat dans la lsite.
		/// </summary>
		/// <param name="srv">Serveur d'exécution.</param>
		/// <param name="SQL">Serveur d'exécution.</param>
		
		public void AddNewResult(Server.Server srv, string SQL)
		{			
			TabPage newTab = new TabPage();
			newTab.Text = srv.ServerName + " ...";
			
			newTab.ForeColor = srv.ServerColor;
			
			tbc_result.TabPages.Add(newTab);
			
			BackgroundWorker bgw = new BackgroundWorker();
			bgw.DoWork += new DoWorkEventHandler(Bgw_executeDoWork);
			bgw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Bgw_executeRunWorkerCompleted);
			
			QueryAndResultSet param = new QueryAndResultSet(srv, SQL, newTab);
			bgw.RunWorkerAsync(param);
			
			SaveServerList();

		}
		
		/// <summary>
		/// Sauvegarder la liste des serveurs dans le fichier "ServerList.xml".
		/// Les données sont entièrement chiffrées.
		/// </summary>
		
		public void SaveServerList()
		{
			SaveServerList(false, "ServerList.xml");
		}
		
		/// <summary>
		/// Sauvegarder la liste des serveurs dans le fichier "ServerList.xml".
		/// Les données sont entièrement chiffrées.
		/// </summary>
		/// <param name="useLegacy">Utilisation du chiffrement "Legacy" avec clef et IV "en dur".</param>
		/// <param name="fileName">Fichier à sauvegarder.</param>
		
		public void SaveServerList(bool useLegacy, string fileName)
		{
			try
			{
				XmlDocument serverList = new XmlDocument();
				XmlNode rootNode = serverList.CreateNode(XmlNodeType.Element, "", "servers", "");
				serverList.AppendChild(rootNode);
				
				XmlAttribute version = serverList.CreateAttribute("version");
				version.Value = "2";
				
				rootNode.Attributes.Append(version);
				
				foreach (Server.Server srv in clb_serverList.GetAll())
				{
					MemoryStream ms = new MemoryStream();
					BinaryFormatter bformatter = new BinaryFormatter();

					bformatter.Serialize(ms, srv);
					XmlNode newServer = serverList.CreateNode(XmlNodeType.Element, "", "server", "");
					XmlAttribute serverType = serverList.CreateAttribute("type");
					serverType.Value = srv.GetType().ToString();
					newServer.Attributes.Append(serverType);
					
					if (useLegacy == true)
					{
						newServer.InnerText = Cypher.ChiffreLegacy(ms.ToArray());
					}
					else
					{
						newServer.InnerText = Cypher.Chiffre(ms.ToArray());
					}
					rootNode.AppendChild(newServer);
					ms.Close();
				}
				
				serverList.Save(fileName);
			}
			catch (Exception exp)
			{
				MessageBox.Show("Ne peut enregistrer la liste des serveurs.\n" + exp.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		
		/// <summary>
		/// Editer le serveur sélectionné.
		/// </summary>
		/// <param name="sender">Objet appelant.</param>
		/// <param name="e">Arguments d'appel.</param>
		
		private void EditerLeServeurToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (clb_serverList.SelectedIndices.Count != 1)
			{
				MessageBox.Show("Vous ne pouvez sélectionner qu'un serveur à la fois", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			
			Server.Server srv = clb_serverList.GetServer(clb_serverList.SelectedIndices[0]);
						
			frm_newServer editDialog = new frm_newServer(srv);
			if (editDialog.ShowDialog() == DialogResult.OK)
			{
				SaveServerList();
				clb_serverList.Refresh();
			}
		}
		
		/// <summary>
		/// Effacer les pages de résultat.
		/// </summary>
		
		public void ClearPages()
		{
			for (int i = tbc_result.TabPages.Count - 1; i > 0; --i)
			{
				tbc_result.TabPages.RemoveAt(i);
			}
		}
		
		/// <summary>
		/// Exporte le fichier de sauvegarde.
		/// </summary>
		/// <param name="sender">Objet appelant.</param>
		/// <param name="e">Arguments d'appel.</param>
		
		private void ExporterServerListxmlToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (sfd_export.ShowDialog() == DialogResult.OK)
			{
				SaveServerList(true, sfd_export.FileName);
			}
		}
		
		/// <summary>
		/// Importe le fichier de configuration.
		/// </summary>
		/// <param name="sender">Objet appelant.</param>
		/// <param name="e">Arguments d'appel.</param>
		
		private void ImporterServerListxmlToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (ofd_import.ShowDialog() == DialogResult.OK)
			{
				ImportServers(true, ofd_import.FileName);
				SaveServerList();
			}
		}
		
		/// <summary>
		/// Importer les serveurs depuis le fichier.
		/// </summary>
		/// <param name="useLegacy">Utilisation du chiffrement legacy.</param>
		/// <param name="fileName">Nom du fichier à lire.</param>
		
		private void ImportServers(bool useLegacy, string fileName)
		{
			try
	    	{
	    		XmlDocument xml = new XmlDocument();
	    		xml.Load(fileName);
	    		
	    		// L'utilisation du legacy ne se fait qu'en important un fichier ou lors d'une mise à jour d'un fichier.
	    		if (useLegacy == false)
	    		{
		    		UpdateServerList(xml);
	    		}
	    		
	    		XmlNodeList servers = xml.SelectNodes("/servers/server");
	    		foreach (XmlNode node in servers)
	    		{
	    			MemoryStream stream;
	    			if (useLegacy == true)
	    			{
		    			stream = new MemoryStream(Cypher.DechiffreLegacy(node.InnerText));
	    			}
	    			else
	    			{
		    			stream = new MemoryStream(Cypher.Dechiffre(node.InnerText));
	    			}
					BinaryFormatter bformatter = new BinaryFormatter();

					Server.Server srv = (Server.Server)bformatter.Deserialize(stream);
					stream.Close();
	    			
					clb_serverList.AddServer(srv);
	    		}
	    	}
	    	catch (Exception exp)
	    	{
	    		MessageBox.Show("Erreur au chargement du fichier de serveur.\nLe fichier sera écrasé lors de l'ajout ou de la suppression d'un serveur à la liste.\n\n" + exp.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
	    	}
		}
		
		/// <summary>
		/// Exécution d'une requête.
		/// </summary>
		/// <param name="sender">Objet appelant.</param>
		/// <param name="e">Arguments d'appel.</param>
		
		private void Bgw_executeDoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
		{
			QueryAndResultSet qrs = (QueryAndResultSet)e.Argument;
			
			e.Result = qrs;
			
			try
			{
				DataSet data = qrs.ExecuteOn.Execute(qrs.SQL);
				
				qrs.Result = data;
			}
			catch (Exception exp)
			{
				qrs.Err = exp.Message + "\n\n" + exp.StackTrace;
			}
		}
		
		/// <summary>
		/// Affichage des résultats d'exécution.
		/// </summary>
		/// <param name="sender">Objet appelant.</param>
		/// <param name="e">Arguments d'appel.</param>
		
		private void Bgw_executeRunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
		{
			QueryAndResultSet qrs = (QueryAndResultSet)e.Result;
			
			qrs.Tab.Text = qrs.Tab.Text.Substring(0, qrs.Tab.Text.Length - 4);
			
			if (qrs.Result != null)
			{
				if (qrs.Result.Tables.Count > 0)
				{
					TabControl tbc = new TabControl();
					tbc.Dock = DockStyle.Fill;
					qrs.Tab.Controls.Add(tbc);
					
					for (int i = 0; i < qrs.Result.Tables.Count; ++i)
					{
						TabData tbd = new TabData();
						tbd.DataSource = qrs.Result.Tables[i];
						tbd.Text = string.Format("Résultat {0}", i + 1);
						tbc.TabPages.Add(tbd);
					}
				}
				else
				{
					Label lbl = new Label();
					lbl.Text = "Pas de résultats";
					lbl.Location = new Point(5, 5);
					qrs.Tab.Controls.Add(lbl);
				}
			}
			else
			{
				TextBox txt = new TextBox();
				txt.Multiline = true;
				txt.Dock = DockStyle.Fill;
				txt.Text = qrs.Err;
				
				qrs.Tab.Controls.Add(txt);
			}
			
			lock(this) { SaveServerList(); }
		}
		
		/// <summary>
		/// Rendu des tabs avec couleur du sereur.
		/// </summary>
		/// <param name="sender">Objet appelant.</param>
		/// <param name="e">Arguments d'appel.</param>
		
		private void Tbc_resultDrawItem(object sender, DrawItemEventArgs e)
		{
		    TabPage page = tbc_result.TabPages[e.Index];
		    e.Graphics.FillRectangle(new SolidBrush(page.BackColor), e.Bounds);
		
		    Rectangle paddedBounds = e.Bounds;
		    int yOffset = (e.State == DrawItemState.Selected) ? -2 : 1;
		    paddedBounds.Offset(1, yOffset);
		    TextRenderer.DrawText(e.Graphics, page.Text, Font, paddedBounds, page.ForeColor);
		}
		
		/// <summary>
		/// Changement de l'état toujours au dessus.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		
		void ToujoursAuDessusToolStripMenuItemClick(object sender, EventArgs e)
		{			
			TopMost = TopMost == false;
			
			toujoursAuDessusToolStripMenuItem.Text = (TopMost == true ? "☑" : "☐") + " Toujours au dessus";
		}
	}
}
