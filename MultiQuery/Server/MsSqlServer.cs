/*
 * Crée par SharpDevelop.
 * Utilisateur: SRUMEU
 * Date: 30/03/2015
 * Heure: 11:36
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;

namespace MultiQuery.Server
{
	/// <summary>
	/// Description of MsSqlServer.
	/// </summary>
	public class MsSqlServer : Server
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="connectionString"></param>
		/// <param name="serverName"></param>
		/// <param name="serverColor"></param>
		
		public MsSqlServer(string connectionString, string serverName, Color serverColor) : base (connectionString, serverName, serverColor)
		{
			
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sql"></param>
		/// <returns></returns>
		
		public override DataSet Execute(string sql)
		{
			SqlConnection con = new SqlConnection(this.ConString);
			SqlCommand com = new SqlCommand(sql, con);
			SqlDataAdapter adapter = new SqlDataAdapter(com);
			DataSet data = null;
			con.Open();
			adapter.Fill(data);
			con.Close();
			
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
		
		public static string CreateConnectionString(string dns, string userName, bool rememberMe, string password, bool useTrusted)
		{
			string data = string.Empty;
			
			return data;
		}
		
		public static bool TestConnection(string dns, string userName, string password, bool useTrusted)
		{
			SqlConnection con = new SqlConnection(MsSqlServer.CreateConnectionString(dns, userName, true, password, useTrusted));
				
			con.Open();
			con.Close();
			
			return true;
		}
		
		public override string ToString()
		{
			return this.ServerName;
		}
	}
}
