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
			DataSet data = new DataSet();
			
			bool executed = false;
			bool stop = false;

			SqlConnection con = new SqlConnection(this.ConString);
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
						DialogResult ret = conDialog.ShowDialog();
						if (ret == DialogResult.OK)
						{
							
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
		
		public static string CreateConnectionString(string dns, string userName, bool rememberMe, string password, bool useTrusted)
		{
			string data = "Server=" + dns + ";";
			
			
			if (useTrusted == true)
				data += "Trusted_Connection=True;";
			else
			{
				data += "User Id=" + userName + ";";
				if (rememberMe == true)
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
		
		public static bool TestConnection(string dns, string userName, string password, bool useTrusted)
		{
			SqlConnection con = new SqlConnection(MsSqlServer.CreateConnectionString(dns, userName, true, password, useTrusted));
				
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
		    
		}
		        
		/// <summary>
		/// Serialization function.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="ctxt"></param>

		public override void GetObjectData(SerializationInfo info, StreamingContext ctxt)
		{
			base.GetObjectData(info, ctxt);
		}
	}
}
