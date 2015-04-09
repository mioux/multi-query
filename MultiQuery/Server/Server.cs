﻿/*
 * Crée par SharpDevelop.
 * Utilisateur: SRUMEU
 * Date: 30/03/2015
 * Heure: 10:21
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;
using System.Data;
using System.Drawing;
using System.Runtime.Serialization;
using System.Text;

namespace MultiQuery.Server
{
	/// <summary>
	/// Description of Server.
	/// </summary>

	[Serializable()]
	public class Server : ISerializable
	{
		/// <summary>
		/// Chaîne de connexion.
		/// </summary>
		protected string ConString { get; set; }
		
		/// <summary>
		/// Nom du serveur.
		/// </summary>
		public string ServerName { get; set; }
		
		/// <summary>
		/// Couleur du serveur à afficher dans la liste.
		/// </summary>
		public Color ServerColor { get; set; }
		
		/// <summary>
		/// Constructeur.
		/// </summary>
		/// <param name="connectionString">Chaîne de connexion initial.</param>
		/// <param name="serverName">Nom du serveur initial.</param>
		/// <param name="serverColor">Couleur initiale.</param>
		
		public Server(string connectionString, string serverName, Color serverColor)
		{
			this.ConString = connectionString;
			this.ServerName = serverName;
			this.ServerColor = serverColor;
		}
		
		/// <summary>
		/// Exécuter une requête. Ne dois pas être appelé depuis cette classe.
		/// </summary>
		/// <param name="SQL"></param>
		/// <returns></returns>
		
		public virtual DataSet Execute(string SQL)
		{
			throw new Exception("Eh Oh, tu dois utiliser les classes de base !");
		}
		
		/// <summary>
		/// Deserialization constructor.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="ctxt"></param>

		public Server(SerializationInfo info, StreamingContext ctxt)
		{
		    ConString = (String)info.GetValue("ConString", typeof(string));
		    ServerName = (String)info.GetValue("ServerName", typeof(string));
		    ServerColor = (Color)info.GetValue("ServerColor", typeof(Color));
		}
		        
		/// <summary>
		/// Serialization function.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="ctxt"></param>

		public virtual void GetObjectData(SerializationInfo info, StreamingContext ctxt)
		{
		    info.AddValue("ConString", ConString);
		    info.AddValue("ServerName", ServerName);
		    info.AddValue("ServerColor", ServerColor);
		}
	}
}