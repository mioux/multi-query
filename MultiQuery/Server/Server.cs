/*
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
		/// Doit sauvegarder les données après exécution d'une requête.
		/// (Si changement de login/mot de passe à l'exécution).
		/// </summary>
		public bool DoSaveAfterExecute { get; set; }
		
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
		
		public Server(string serverName, Color serverColor)
		{
			this.ServerName = serverName;
			this.ServerColor = serverColor;
			this.DoSaveAfterExecute = false;
		}
		
		/// <summary>
		/// Exécuter une requête. Ne dois pas être appelé depuis cette classe.
		/// </summary>
		/// <param name="SQL">Requête à exécuter.</param>
		/// <returns></returns>
		
		public virtual DataSet Execute(string SQL)
		{
			throw new InvalidOperationException("Eh Oh, tu dois utiliser les classes de base !");
		}
		
		/// <summary>
		/// Constructeur depuis désérialisation.
		/// </summary>
		/// <param name="info">Infos de désérialisation.</param>
		/// <param name="ctxt">Contexte de désérialisation.</param>

		public Server(SerializationInfo info, StreamingContext ctxt)
		{
		    ServerName = info.GetString("ServerName");
		    ServerColor = (Color)info.GetValue("ServerColor", typeof(Color));
		}
		        
		/// <summary>
		/// Fonction de sérialisation.
		/// </summary>
		/// <param name="info">Infos de désérialisation.</param>
		/// <param name="ctxt">Contexte de désérialisation.</param>

		public virtual void GetObjectData(SerializationInfo info, StreamingContext ctxt)
		{
		    info.AddValue("ServerName", ServerName);
		    info.AddValue("ServerColor", ServerColor);
		}
		
		/// <summary>
		/// Définition de nouvelles valeurs pour le serveur.
		/// </summary>
		/// <param name="serverName">Nom d'affichage du serveur.</param>
		/// <param name="serverColor">Couleur d'affichage du serveur.</param>
		
		public virtual void SetNewValues(string serverName, Color serverColor)
		{
			ServerName = serverName;
			ServerColor = serverColor;
		}
	}
}
