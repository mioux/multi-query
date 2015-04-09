﻿/*
 * Crée par SharpDevelop.
 * Utilisateur: SRUMEU
 * Date: 25/03/2015
 * Heure: 16:57
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Xml;

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
		/// Requête.
		/// </summary>
		Forms.frm_sql frmSql = new MultiQuery.Forms.frm_sql();
		
		/// <summary>
		/// Constructeur.
		/// </summary>
		public frm_main()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
			if (File.Exists("ServerList.xml"))
		    {
		    	try
		    	{
		    		XmlDocument xml = new XmlDocument();
		    		xml.Load("ServerList.xml");
		    		
		    		XmlNodeList servers = xml.SelectNodes("/servers/server");
		    		foreach (XmlNode node in servers)
		    		{
		    			MemoryStream stream = new MemoryStream(Cypher.Dechiffre(node.InnerText));
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
		}
		
		/// <summary>
		/// Ajouter un serveur.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void AjouterToolStripMenuItemClick(object sender, EventArgs e)
		{
			frm_newServer newServer = new frm_newServer();
			
			if (newServer.ShowDialog() == DialogResult.OK)
			{
				clb_serverList.AddServer(newServer.NewServer);
				
				SaveServerList();
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void SupprimerToolStripMenuItemClick(object sender, EventArgs e)
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
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		
		void ExécuterSurLesServeursSélectionnésToolStripMenuItemClick(object sender, EventArgs e)
		{
			string sql = string.Empty;
			
			if (frmSql.ShowDialog() == DialogResult.OK)
			{
				tbc_result.TabPages.Clear();
				foreach(Server.Server srv in clb_serverList.GetSelected())
				{
					AddNewResult(srv, frmSql.Data);
				}
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		
		void ExécuterSurTousLesServeursToolStripMenuItemClick(object sender, EventArgs e)
		{
			string sql = string.Empty;
			
			if (frmSql.ShowDialog() == DialogResult.OK)
			{
				tbc_result.TabPages.Clear();
				foreach(Server.Server srv in clb_serverList.GetAll())
				{
					AddNewResult(srv, frmSql.Data);
				}
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		
		void QuitterToolStripMenuItemClick(object sender, EventArgs e)
		{
			Environment.Exit(0);
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="srv"></param>
		/// <param name="SQL"></param>
		
		void AddNewResult(Server.Server srv, string SQL)
		{
			TabPage newTab = new TabPage();
			newTab.Text = srv.ServerName;
			
			tbc_result.TabPages.Add(newTab);
			
			try
			{
				DataSet data = srv.Execute(SQL);
				if (data.Tables.Count > 0)
				{
					TabControl tbc = new TabControl();
					tbc.Dock = DockStyle.Fill;
					newTab.Controls.Add(tbc);
					
					for (int i = 0; i < data.Tables.Count; ++i)
					{
						TabData tbd = new TabData();
						tbd.DataSource = data.Tables[i];
						tbd.Text = string.Format("Résultat {0}", i + 1);
						tbc.TabPages.Add(tbd);
					}
				}
				else
				{
					Label lbl = new Label();
					lbl.Text = "Pas de résultats";
					lbl.Location = new Point(5, 5);
					newTab.Controls.Add(lbl);
				}
			}
			catch (Exception exp)
			{
				TextBox txt = new TextBox();
				txt.Multiline = true;
				txt.Dock = DockStyle.Fill;
				txt.Text = exp.Message + "\n\n" + exp.StackTrace;
				
				newTab.Controls.Add(txt);
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		
		void SaveServerList()
		{
			try
			{
				XmlDocument serverList = new XmlDocument();
				XmlNode rootNode = serverList.CreateNode(XmlNodeType.Element, "", "servers", "");
				serverList.AppendChild(rootNode);
				
				foreach (Server.Server srv in clb_serverList.GetAll())
				{
					MemoryStream ms = new MemoryStream();
					BinaryFormatter bformatter = new BinaryFormatter();

					bformatter.Serialize(ms, srv);
					XmlNode newServer = serverList.CreateNode(XmlNodeType.Element, "", "server", "");
					newServer.InnerText = Cypher.Chiffre(ms.ToArray());
					rootNode.AppendChild(newServer);
					ms.Close();
				}
				
				serverList.Save("ServerList.xml");
			}
			catch (Exception exp)
			{
				MessageBox.Show("Ne peut enregistrer la liste des serveurs.\n" + exp.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
