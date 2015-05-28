/*
 * Crée par SharpDevelop.
 * Utilisateur: SRUMEU
 * Date: 30/04/2015
 * Heure: 14:21
 * 
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace MultiQuery.MySqlDataSourceEnumerator
{
	/// <summary>
	/// Description of MySqlDataSourceEnumerator.
	/// </summary>
	public class Instance
	{
		/// <summary>
		/// Détection des IP avec le port 3306 ouvert.
		/// Ca n'assure pas que MySQL y est installé, ni que tous les serveurs sont présents,
		/// mais ça permet d'avoir une première idée des serveurs disponibles.
		/// 
		/// Ne cherche que sur les IP dans le même sous domaine.
		/// </summary>
		/// <returns></returns>
		
		public static DataTable GetDataSources()
		{
			DataTable source = new DataTable();
			source.Columns.Add("ServerName");
			
			List<string> serverList = ListServers();
			
			foreach (string curServer in serverList)
			{
				source.Rows.Add(curServer);
			}
				
			return source;
		}
		
		private static List<string> ListServers()
		{
			List<string> ServerList = new List<string>();

			ServerList = ListDevices();
	
			List<string> dbServerList = new List<string>();
			string strServer = null;
			bool CanConnect = false;
			int x = 0;
			//add loop for these
			x = 0;
			foreach (string strServer_loopVariable in ServerList) {
				strServer = strServer_loopVariable;
				CanConnect = TestConnection(ServerList[x].ToString());
				if (CanConnect == true) {
					dbServerList.Add(ServerList[x].ToString());
				}
				x += 1;
			}
			
			return ServerList;
		}
		
		private static List<string> ListDevices()
		{
			List<string> ServerList = new List<string>();
			DirectoryEntry childEntry = default(DirectoryEntry);
			DirectoryEntry ParentEntry = new DirectoryEntry();
			try {
				ParentEntry.Path = "WinNT:";
				foreach (object childEntry in ParentEntry.Children) {
					switch (childEntry.SchemaClassName) {
						case "Domain":
	
							DirectoryEntry SubChildEntry = default(DirectoryEntry);
							DirectoryEntry SubParentEntry = new DirectoryEntry();
							SubParentEntry.Path = "WinNT://" + childEntry.Name;
							foreach (object SubChildEntry in SubParentEntry.Children) {
								switch (SubChildEntry.SchemaClassName) {
									case "Computer":
										ServerList.Add(SubChildEntry.Name);
	
										break;
								}
							}
	
							break;
					}
				}
				return ServerList;
			//Console.WriteLine(ServerList(1))
			} catch (Exception Excep) {
				Interaction.MsgBox("Error While Reading Directories : " + Excep.Message.ToString);
				return null;
			} finally {
				ParentEntry = null;
	
			}
		}
		
		private static bool TestConnection(string strServer)
		{
			return false;	
		}
	}
}
