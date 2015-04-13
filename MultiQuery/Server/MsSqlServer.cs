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
		private string _dns = string.Empty;
		private string _userName = string.Empty;
		private bool _useTrusted = true;
		private bool _rememberMe = false;
		private string _password = string.Empty;
		private string _defaultDatabase = string.Empty;
		
		public static MsSqlServer New(string dns, string userName, bool rememberMe, string password, bool useTrusted, string serverName, Color color, string defaultDatabese)
		{
			MsSqlServer newServer = new MsSqlServer(serverName, color, dns, userName, rememberMe, password, useTrusted, defaultDatabese);
			
			return newServer;
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="connectionString"></param>
		/// <param name="serverName"></param>
		/// <param name="serverColor"></param>
		
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
		/// 
		/// </summary>
		/// <param name="sql"></param>
		/// <returns></returns>
		
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
		/// 
		/// </summary>
		/// <param name="dns"></param>
		/// <param name="userName"></param>
		/// <param name="rememberMe"></param>
		/// <param name="password"></param>
		/// <param name="useTrusted"></param>
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
		/// 
		/// </summary>
		/// <param name="dns"></param>
		/// <param name="userName"></param>
		/// <param name="password"></param>
		/// <param name="useTrusted"></param>
		/// <returns></returns>
		
		public static bool TestConnection(string dns, string userName, string password, bool useTrusted, string defaultDatabase)
		{
			SqlConnection con = new SqlConnection(MsSqlServer.CreateConnectionString(dns, userName, password, useTrusted, defaultDatabase));
				
			con.Open();
			con.Close();
			
			return true;
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		
		public override string ToString()
		{
			return this.ServerName;
		}
		
		/// <summary>
		/// Deserialization constructor.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="ctxt"></param>

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
		/// Serialization function.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="ctxt"></param>

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
	}
}
