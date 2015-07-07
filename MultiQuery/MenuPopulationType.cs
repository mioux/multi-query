/*
 * Crée par SharpDevelop.
 * Utilisateur: SRUMEU
 * Date: 30/04/2015
 * Heure: 13:56
 * 
 */
using System;
using System.Data;

namespace MultiQuery
{
	/// <summary>
	/// Description of MenuPopulationType.
	/// </summary>
	public class MenuPopulationType
	{
		public DataTable ItemList { get; private set; }
		public Type ItemType { get; private set; }
		
		public MenuPopulationType(DataTable itemList, Type itemType)
		{
			ItemList = itemList;
			ItemType = itemType;
		}
	}
}
