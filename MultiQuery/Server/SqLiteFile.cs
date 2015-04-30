/*
 * Crée par SharpDevelop.
 * Utilisateur: SRUMEU
 * Date: 30/04/2015
 * Heure: 09:19
 * 
 */
using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Runtime.Serialization;
using System.Windows.Forms;

using MultiQuery.Config;

namespace MultiQuery.Server
{
	[Serializable()]
	public class SqLiteFile : Server
	{
		/// <summary>
		/// Fichier à ouvrir.
		/// </summary>
		private string _fileName = string.Empty;
						
		/// <summary>
		/// Se souvenir de moi (valeur).
		/// </summary>
		private bool _rememberMe = false;
		
		/// <summary>
		/// Mot de passe (valeur).
		/// </summary>
		private string _password = string.Empty;
				
		/// <summary>
		/// Host ou IP de connexion (accesseur).
		/// </summary>
		public string FileName { get { return _fileName; } private set {}}
						
		/// <summary>
		/// Se souvenir des identifiants (accesseur).
		/// </summary>
		public bool RememberMe { get { return _rememberMe; } private set {}}
		
		/// <summary>
		/// Mot de passe (accesseur).
		/// </summary>
		public string Password { get { return _password; } private set {}}
				
		/// <summary>
		/// Instanciation d'un nouveau fichier SqLite.
		/// </summary>
		/// <param name="fileName">Fichier à ouvrir.</param>
		/// <param name="rememberMe">Se souvenir des paramètres de connexion.</param>
		/// <param name="password">Mot de passe.</param>
		/// <param name="serverName">Nom d'affichage.</param>
		/// <param name="color">Couleur d'affichage.</param>
		/// <returns>Nouveau SqLite.</returns>
		public static SqLiteFile New(string fileName, bool rememberMe, string password, string serverName, Color color)
		{
			SqLiteFile newServer = new SqLiteFile(serverName, color, fileName, rememberMe, password);
			
			return newServer;
		}
		
		/// <summary>
		/// Constructeur d'un serveur SQL Server.
		/// </summary>
		/// <param name="serverName">Nom d'affichage.</param>
		/// <param name="color">Couleur d'affichage.</param>
		/// <param name="fileName">Fichier à ouvrir.</param>
		/// <param name="rememberMe">Se souvenir des paramètres de connexion.</param>
		/// <param name="password">Mot de passe.</param>
		
		private SqLiteFile(string serverName, Color serverColor, string fileName, bool rememberMe, string password) : base (serverName, serverColor)
		{
			_fileName = fileName;
			_rememberMe = rememberMe;
			_password = password;
		}
		
		/// <summary>
		/// Exécution d'une requête sur le serveur.
		/// </summary>
		/// <param name="sql">Requête à exécuter.</param>
		/// <returns>Jeu de résultats.</returns>
		
		public override DataSet Execute(string sql)
		{			
			DataSet data = new DataSet();
			
			bool executed = false;
			bool stop = false;

			SQLiteConnection con = new SQLiteConnection(SqLiteFile.CreateConnectionString(_fileName, _password));
			SQLiteCommand com = new SQLiteCommand(sql, con);
			SQLiteDataAdapter adapter = new SQLiteDataAdapter(com);
			
			while (executed == false && stop == false)
			{
				try
				{
					con.Open();
					adapter.Fill(data);
					con.Close();
					
					executed = true;
				}
				catch (SQLiteException exp)
				{
					/*if (exp.ErrorCode == 18456) // Login Failed
					{
						frm_MsSqlServer_ConnectionDialog conDialog = new frm_MsSqlServer_ConnectionDialog();
						conDialog.UserName = this._userName;
						conDialog.Password = this._password;
						conDialog.RememberMe = this._rememberMe;
						
						DialogResult ret = conDialog.ShowDialog();
						if (ret == DialogResult.OK)
						{
							_userName = conDialog.UserName;
							_password = conDialog.Password;
							_rememberMe = conDialog.RememberMe;
							
							DoSaveAfterExecute = true;
						}
						else if(ret == DialogResult.Cancel)
						{
							throw exp;
						}
						else
						{
							stop = true;
						}
					}
					else
					{*/
						throw exp;
					/*}*/
				}
			}
			return data;
		}
		
		/// <summary>
		/// Création d'une chaîne de connexion en fonction des paramètres du serveur.
		/// Mis en statique pour pouvoir utiliser la fonction de test sans créer de nouveau serveur.
		/// </summary>
		/// <param name="fileName">Host ou IP du serveur.</param>
		/// <param name="password">Mot de passe.</param>
		/// <returns></returns>
		
		private static string CreateConnectionString(string fileName, string password)
		{
			string data = "Version=3;Data Source=" + fileName + ";";
					
			if (string.IsNullOrEmpty(password) == false)
			{
				data += "Password=" + password + ";";
			}
			
			return data;
		}
		
		/// <summary>
		/// Tester une connexion à un serveur.
		/// </summary>
		/// <param name="fileName">Host ou IP du serveur.</param>
		/// <param name="password">Mot de passe.</param>
		/// <returns>Vrai ou exception si la connexion ne peut s'effectuer.</returns>
		
		public static bool TestConnection(string fileName, string password)
		{
			SQLiteConnection con = new SQLiteConnection(SqLiteFile.CreateConnectionString(fileName, password));
				
			con.Open();
			con.Close();
			
			return true;
		}
		
		/// <summary>
		/// Renvoie le nom du serveur.
		/// </summary>
		/// <returns>Nom du serveur.</returns>
		
		public override string ToString()
		{
			return this.ServerName;
		}
		
		/// <summary>
		/// Constructeur depuis désérialisation.
		/// </summary>
		/// <param name="info">Infos de désérialisation.</param>
		/// <param name="ctxt">Contexte de désérialisation.</param>

		public SqLiteFile(SerializationInfo info, StreamingContext ctxt) : base (info, ctxt)
		{
			_fileName = info.GetString("FileName");
			_rememberMe = info.GetBoolean("RememberMe");
			_password = info.GetString("Password");
		}
		        
		/// <summary>
		/// Fonction de sérialisation.
		/// </summary>
		/// <param name="info">Infos de désérialisation.</param>
		/// <param name="ctxt">Contexte de désérialisation.</param>

		public override void GetObjectData(SerializationInfo info, StreamingContext ctxt)
		{
			base.GetObjectData(info, ctxt);
		    info.AddValue("FileName", _fileName);
		    info.AddValue("RememberMe", _rememberMe);
		    info.AddValue("Password", _rememberMe ? _password : string.Empty);
		}
		
		/// <summary>
		/// Change les valeurs du serveur en cours.
		/// </summary>
		/// <param name="fileName">Host ou IP du serveur.</param>
		/// <param name="rememberMe">Se souvenir des paramètres de connexion.</param>
		/// <param name="password">Mot de passe.</param>
		/// <param name="serverName">Nom d'affichage du serveur.</param>
		/// <param name="color">Couleur d'affichage.</param>
		
		public void SetNewValues(string fileName, bool rememberMe, string password, string serverName, Color color)
		{
			base.SetNewValues(serverName, color);
			
			this._fileName = fileName;
			this._rememberMe = rememberMe;
			this._password = password;
		}
	}
}
