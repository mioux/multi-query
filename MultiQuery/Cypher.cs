/*
 * Crée par SharpDevelop.
 * Utilisateur: SRUMEU
 * Date: 12/03/2015
 * Heure: 18:02
 *
 * Code honteusement pompé depuis http://www.devasp.net/net/articles/display/1354.html
 * pour la partie "Legacy".
 * (originalement trouvé sur StackOverflow mais je retrouve plus le post correspondant)
 */
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace MultiQuery
{
	/// <summary>
	/// Description of ProprieteChiffre.
	/// </summary>
	public class Cypher
	{
		/// <summary>
		/// Clef de chiffrement/déchiffrement.
		/// </summary>
		private static string encryptKey = @"_Is20d+g";
		/// <summary>
		/// Vecteur d'initialisation.
		/// </summary>
		private static string IV_val = @"""W|<0^iU";
		
		/// <summary>
		/// Chiffre une chaîne de caractère et la convertit en Base64.
		/// </summary>
		/// <param name="inputString">Chaîne à chiffrer</param>
		/// <returns><see cref="String"></see> en Base64 chiffrée.</returns>
		public static string Chiffre(byte[] byteInput)
		{
			byte[] cyphered = ProtectedData.Protect(byteInput, null, DataProtectionScope.CurrentUser);
			return Convert.ToBase64String(cyphered);
		}
		
		/// <summary>
		/// Ancienne méthide de déchifrement conservée pour version portable.
		/// </summary>
		/// <param name="inputString">Chaîne à chiffrer</param>
		/// <returns><see cref="String"></see> en Base64 chiffrée.</returns>
		public static string Chiffre(byte[] byteInput)
		{
			if (byteInput.Length == 0)
				return "";
			
			MemoryStream memStream = null;
			try
			{
				byte[] key = { };
				byte[] IV = { };
				key = Encoding.UTF8.GetBytes(encryptKey);
				IV = Encoding.UTF8.GetBytes(IV_val);
				DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
				memStream = new MemoryStream();
				ICryptoTransform transform = provider.CreateEncryptor(key, IV);
				CryptoStream cryptoStream = new CryptoStream(memStream, transform, CryptoStreamMode.Write);
				cryptoStream.Write(byteInput, 0, byteInput.Length);
				cryptoStream.FlushFinalBlock();
				
				return Convert.ToBase64String(memStream.ToArray());
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			
			return "";
		}
		
		/// <summary>
		/// Déchiffre une chaîne de caractère codée en Base64.
		/// </summary>
		/// <param name="inputString">Chaîne chiffrée.</param>
		/// <returns><see cref="String">Chaîne</see> déchiffrée.</returns>
		public static byte[] Dechiffre(string inputString)
		{
			byte[] cyphered = Convert.FromBase64String(inputString);
			return ProtectedData.Unprotect(cyphered, null, DataProtectionScope.CurrentUser);
		}
		
		/// <summary>
		/// Ancienne méthide de déchifrement conservée pour mise à jour des fichiers de paramètres ou pour version portable.
		/// </summary>
		/// <param name="inputString"></param>
		/// <returns></returns>
		public static byte[] DechiffreLegacy(string inputString)
		{
			if (inputString == "")
				return null;
			
			MemoryStream memStream = null;
			try 
			{
					byte[] key = { };
					byte[] IV = {  };
					key = Encoding.UTF8.GetBytes(encryptKey);
					IV = Encoding.UTF8.GetBytes(IV_val);
					byte[] byteInput = new byte[inputString.Length];
					byteInput = Convert.FromBase64String(inputString);
					DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
					memStream = new MemoryStream();
					ICryptoTransform transform = provider.CreateDecryptor(key, IV);
					CryptoStream cryptoStream = new CryptoStream(memStream, transform, CryptoStreamMode.Write);
					cryptoStream.Write(byteInput, 0, byteInput.Length);
					cryptoStream.FlushFinalBlock();
					
				return memStream.ToArray();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			
			return null;
		} 
	}
}
