/*
 * Crée par SharpDevelop.
 * Utilisateur: SRUMEU
 * Date: 29/04/2015
 * Heure: 15:40
 * 
 */
using System;
using System.Data;
using System.Windows.Forms;

using MultiQuery.CustomForm;

namespace MultiQuery
{
	/// <summary>
	/// Description of QueryAndResultSet.
	/// </summary>
	public class QueryAndResultSet
	{
		public Server.Server ExecuteOn { get; set; }
		public string SQL { get; set; }
		public DataSet Result { get; set; }
		public string Err { get; set; }
		public TabPage Tab { get; set; }
		
		public QueryAndResultSet(Server.Server srv, string sql, TabPage tab)
		{
			ExecuteOn = srv;
			SQL = sql;
			Result = null;
			Err = string.Empty;
			Tab = tab;
		}
	}
}
