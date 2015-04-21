/*
 * Crée par SharpDevelop.
 * Utilisateur: SRUMEU
 * Date: 30/03/2015
 * Heure: 11:36
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Runtime.Serialization;
using System.Windows.Forms;

using MultiQuery.Config;

namespace MultiQuery.Server
{
	/// <summary>
	/// Description of MsSqlServer.
	/// </summary>

	[Serializable()]
	public class MsSqlServer : Server
	{
		/// <summary>
		/// Host ou IP de connexion (valeu).
		/// </summary>
		private string _dns = string.Empty;
		
		/// <summary>
		/// Nom d'utilisateur (valeur).
		/// </summary>
		private string _userName = string.Empty;
		
		/// <summary>
		/// Utilise le login Windows pour la connexion (valeur).
		/// </summary>
		private bool _useTrusted = true;
		
		/// <summary>
		/// Se souvenir de moi (valeur).
		/// </summary>
		private bool _rememberMe = false;
		
		/// <summary>
		/// Mot de passe (valeur).
		/// </summary>
		private string _password = string.Empty;
		
		/// <summary>
		/// Base par défaut (valeur).
		/// </summary>
		private string _defaultDatabase = string.Empty;
		
		/// <summary>
		/// Host ou IP de connexion (accesseur).
		/// </summary>
		public string Dns { get { return _dns; } private set {}}
		
		/// <summary>
		/// Nom d'utilisateur (accesseur).
		/// </summary>
		public string UserName { get { return _userName; } private set {}}
		
		/// <summary>
		/// Utilisation du login Windows pour se connecter (accesseur).
		/// </summary>
		public bool UseTrusted { get { return _useTrusted; } private set {}}
		
		/// <summary>
		/// Se souvenir des identifiants (accesseur).
		/// </summary>
		public bool RememberMe { get { return _rememberMe; } private set {}}
		
		/// <summary>
		/// Mot de passe (accesseur).
		/// </summary>
		public string Password { get { return _password; } private set {}}
		
		/// <summary>
		/// Base par défaut.
		/// </summary>
		public string DefaultDatabase { get { return _defaultDatabase; } private set {}}
		
		/// <summary>
		/// Instanciation d'un nouveau serveur SQL Server.
		/// </summary>
		/// <param name="dns">Host ou IP de connexion.</param>
		/// <param name="userName">Utilisateur.</param>
		/// <param name="rememberMe">Se souvenir des paramètres de connexion.</param>
		/// <param name="password">Mot de passe.</param>
		/// <param name="useTrusted">Utilisation du login Windows.</param>
		/// <param name="serverName">Nom d'affichage.</param>
		/// <param name="color">Couleur d'affichage.</param>
		/// <param name="defaultDatabese">Base par défaut.</param>
		/// <returns>Nouveau MsSqlServer.</returns>
		public static MsSqlServer New(string dns, string userName, bool rememberMe, string password, bool useTrusted, string serverName, Color color, string defaultDatabese)
		{
			MsSqlServer newServer = new MsSqlServer(serverName, color, dns, userName, rememberMe, password, useTrusted, defaultDatabese);
			
			return newServer;
		}
		
		/// <summary>
		/// Constructeur d'un serveur SQL Server.
		/// </summary>
		/// <param name="serverName">Nom d'affichage.</param>
		/// <param name="color">Couleur d'affichage.</param>
		/// <param name="dns">Host ou IP de connexion.</param>
		/// <param name="userName">Utilisateur.</param>
		/// <param name="rememberMe">Se souvenir des paramètres de connexion.</param>
		/// <param name="password">Mot de passe.</param>
		/// <param name="useTrusted">Utilisation du login Windows.</param>
		/// <param name="defaultDatabese">Base par défaut.</param>
		
		private MsSqlServer(string serverName, Color serverColor, string dns, string userName, bool rememberMe, string password, bool useTrusted, string defaultDatabase) : base (serverName, serverColor)
		{
			_dns = dns;
			_userName = userName;
			_useTrusted = useTrusted;
			_rememberMe = rememberMe;
			_password = password;
			_defaultDatabase = defaultDatabase;
		}
		
		/// <summary>
		/// Exécution d'une requête sur le serveur.
		/// </summary>
		/// <param name="sql">Requête à exécuter.</param>
		/// <returns>Jeu de résultats.</returns>
		
		public override DataSet Execute(string sql)
		{
			DoSaveAfterExecute = false;
			
			DataSet data = new DataSet();
			
			bool executed = false;
			bool stop = false;

			SqlConnection con = new SqlConnection(MsSqlServer.CreateConnectionString(_dns, _userName, _password, _useTrusted, _defaultDatabase));
			SqlCommand com = new SqlCommand(sql, con);
			SqlDataAdapter adapter = new SqlDataAdapter(com);
			
			while (executed == false && stop == false)
			{
				try
				{
					con.Open();
					adapter.Fill(data);
					con.Close();
					
					executed = true;
				}
				catch (SqlException exp)
				{
					if (exp.ErrorCode == 18456) // Login Failed
					{
						frm_MsSqlServer_ConnectionDialog conDialog = new frm_MsSqlServer_ConnectionDialog();
						conDialog.UserName = this._userName;
						conDialog.Password = this._password;
						conDialog.RememberMe = this._rememberMe;
						conDialog.UseTrusted = this._useTrusted;
						
						DialogResult ret = conDialog.ShowDialog();
						if (ret == DialogResult.OK)
						{
							_userName = conDialog.UserName;
							_password = conDialog.Password;
							_rememberMe = conDialog.RememberMe;
							_useTrusted = conDialog.UseTrusted;
							
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
					{
						throw exp;
					}
				}
			}
			return data;
		}
		
		/// <summary>
		/// Création d'une chaîne de connexion en fonction des paramètres du serveur.
		/// Mis en statique pour pouvoir utiliser la fonction de test sans créer de nouveau serveur.
		/// </summary>
		/// <param name="dns">Host ou IP du serveur.</param>
		/// <param name="userName">Nom d'utilisateur.</param>
		/// <param name="password">Mot de passe.</param>
		/// <param name="useTrusted">Utilisation du login Windows.</param>
		/// <param name="defaultDatabase">Base par défaut.</param>
		/// <returns></returns>
		
		private static string CreateConnectionString(string dns, string userName, string password, bool useTrusted, string defaultDatabase)
		{
			string data = "Server=" + dns + ";";
			
			if (string.IsNullOrEmpty(defaultDatabase) == false)
			{
				data += "Database=" + defaultDatabase + ";";
			}
			
			if (useTrusted == true)
			{
				data += "Trusted_Connection=True;";
			}
			else
			{
				data += "User Id=" + userName + ";";
				data += "Password=" + password + ";";
			}
			
			return data;
		}
		
		/// <summary>
		/// Tester une connexion à un serveur.
		/// </summary>
		/// <param name="dns">Host ou IP du serveur.</param>
		/// <param name="userName">Nom d'utilisateur.</param>
		/// <param name="password">Mot de passe.</param>
		/// <param name="useTrusted">Utilisation du login Windows.</param>
		/// <returns>Vrai ou exception si la connexion ne peut s'effectuer.</returns>
		
		public static bool TestConnection(string dns, string userName, string password, bool useTrusted, string defaultDatabase)
		{
			SqlConnection con = new SqlConnection(MsSqlServer.CreateConnectionString(dns, userName, password, useTrusted, defaultDatabase));
				
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

		public MsSqlServer(SerializationInfo info, StreamingContext ctxt) : base (info, ctxt)
		{
			_dns = info.GetString("Dns");
			_userName = info.GetString("UserName");
			_useTrusted = info.GetBoolean("UseTrusted");
			_rememberMe = info.GetBoolean("RememberMe");
			_password = info.GetString("Password");
			_defaultDatabase = info.GetString("DefaultDatabase");
		}
		        
		/// <summary>
		/// Fonction de sérialisation.
		/// </summary>
		/// <param name="info">Infos de désérialisation.</param>
		/// <param name="ctxt">Contexte de désérialisation.</param>

		public override void GetObjectData(SerializationInfo info, StreamingContext ctxt)
		{
			base.GetObjectData(info, ctxt);
		    info.AddValue("Dns", _dns);
		    info.AddValue("UserName", _userName);
		    info.AddValue("UseTrusted", _useTrusted);
		    info.AddValue("RememberMe", _rememberMe);
		    info.AddValue("Password", _rememberMe ? _password : string.Empty);
		    info.AddValue("DefaultDatabase", _defaultDatabase);
		}
		
		/// <summary>
		/// Change les valeurs du serveur en cours.
		/// </summary>
		/// <param name="dns">Host ou IP du serveur.</param>
		/// <param name="userName">Nom d'utilisateur.</param>
		/// <param name="rememberMe">Se souvenir des paramètres de connexion.</param>
		/// <param name="password">Mot de passe.</param>
		/// <param name="useTrusted">Utilisation du login Windows/</param>
		/// <param name="serverName">Nom d'affichage du serveur.</param>
		/// <param name="color">Couleur d'affichage.</param>
		/// <param name="defaultDatabese">Base par défaut.</param>
		
		public void SetNewValues(string dns, string userName, bool rememberMe, string password, bool useTrusted, string serverName, Color color, string defaultDatabese)
		{
			base.SetNewValues(serverName, color);
			
			this._dns = dns;
			this._userName = userName;
			this._rememberMe = rememberMe;
			this._password = password;
			this._useTrusted = useTrusted;
			this._defaultDatabase = defaultDatabese;
		}
	}
}
