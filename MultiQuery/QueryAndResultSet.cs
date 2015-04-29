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
	/// Structure utilisée comme paramètres du Background Worker
	/// qui accueillera les résultats d'exécution des requêtes.
	/// </summary>
	public class QueryAndResultSet
	{
		/// <summary>
		/// Serveur d'exécution.
		/// </summary>
		public Server.Server ExecuteOn { get; set; }
		
		/// <summary>
		/// Requête à exécuter.
		/// </summary>
		public string SQL { get; set; }
		
		/// <summary>
		/// Données de retour.
		/// </summary>
		public DataSet Result { get; set; }
		
		/// <summary>
		/// Message si erreur.
		/// </summary>
		public string Err { get; set; }
		
		/// <summary>
		/// Page de résultats.
		/// </summary>
		public TabPage Tab { get; set; }
		
		/// <summary>
		/// Initialisation des varilables.
		/// </summary>
		/// <param name="srv">Serveur d'exécution.</param>
		/// <param name="sql">Requête à exécuter.</param>
		/// <param name="tab">Page de résultats.</param>
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
