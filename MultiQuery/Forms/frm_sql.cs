/*
 * Crée par SharpDevelop.
 * Utilisateur: SRUMEU
 * Date: 02/04/2015
 * Heure: 12:59
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MultiQuery.Forms
{
	/// <summary>
	/// Description of frm_sql.
	/// </summary>
	public partial class frm_sql : Form
	{
		public string Data { get { return rtb_sql.Text; } private set { } }
		
		public frm_sql()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
			if (File.Exists("last.sql"))
			{
				try
				{
					rtb_sql.Text = File.ReadAllText("last.sql");
					rtb_sql_TextChanged(rtb_sql, new EventArgs());
				}
				catch (Exception exp)
				{
					MessageBox.Show("Erreur lors de la lecture de la dernière requête utilisée.\n" + exp.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}
		
		/// <summary>
		/// Coloration syntaxique.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		
		void rtb_sql_TextChanged(object sender, EventArgs e)
		{
			return;
			
			/*Dictionary<string, Color> cl = new Dictionary<string, Color>();
			
			cl.Add("ADD", Color.Salmon);
			cl.Add("ALL", Color.Gray);
			cl.Add("ALTER", Color.Blue);
			cl.Add("AND", Color.Gray);
			cl.Add("ANY", Color.Gray);
			cl.Add("AS", Color.Blue);
			cl.Add("ASC", Color.Blue);
			cl.Add("AUTHORIZATION", Color.Blue);
			cl.Add("BACKUP", Color.Blue);
			cl.Add("BEGIN", Color.Blue);
			cl.Add("BETWEEN", Color.Gray);
			cl.Add("BREAK", Color.Blue);
			cl.Add("BROWSE", Color.Gray);
			cl.Add("BULK", Color.Blue);
			cl.Add("BY", Color.Blue);
			cl.Add("CASCADE", Color.Blue);
			cl.Add("CASE", Color.Blue);
			cl.Add("CHECK", Color.Blue);
			cl.Add("CHECKPOINT", Color.Blue);
			cl.Add("CLOSE", Color.Blue);
			cl.Add("CLUSTERED", Color.Blue);
			cl.Add("COALESCE", Color.Salmon);
			cl.Add("COLLATE", Color.Blue);
			cl.Add("COLUMN", Color.Blue);
			cl.Add("COMMIT", Color.Blue);
			cl.Add("COMPUTE", Color.Blue);
			cl.Add("CONSTRAINT", Color.Blue);
			cl.Add("CONTAINS", Color.Salmon);
			cl.Add("CONTAINSTABLE", Color.Blue);
			cl.Add("CONTINUE", Color.Blue);
			cl.Add("CONVERT", Color.Salmon);
			cl.Add("CREATE", Color.Blue);
			cl.Add("CROSS", Color.Gray);
			cl.Add("CURRENT", Color.Blue);
			cl.Add("CURRENT_DATE", Color.Gray);
			cl.Add("CURRENT_TIME", Color.Gray);
			cl.Add("CURRENT_TIMESTAMP", Color.Gray);
			cl.Add("CURRENT_USER", Color.Gray);
			cl.Add("CURSOR", Color.Blue);
			cl.Add("DATABASE", Color.Blue);
			cl.Add("DBCC", Color.Blue);
			cl.Add("DEALLOCATE", Color.Blue);
			cl.Add("DECLARE", Color.Blue);
			cl.Add("DEFAULT", Color.Blue);
			cl.Add("DELETE", Color.Blue);
			cl.Add("DENY", Color.Blue);
			cl.Add("DESC", Color.Blue);
			cl.Add("DISK", Color.Blue);
			cl.Add("DISTINCT", Color.Blue);
			cl.Add("DISTRIBUTED", Color.Blue);
			cl.Add("DOUBLE", Color.Blue);
			cl.Add("DROP", Color.Blue);
			cl.Add("DUMMY", Color.Blue);
			cl.Add("DUMP", Color.Blue);
			cl.Add("ELSE", Color.Blue);
			cl.Add("END", Color.Blue);
			cl.Add("ERRLVL", Color.Gray);
			cl.Add("ESCAPE", Color.Blue);
			cl.Add("EXCEPT", Color.Gray);
			cl.Add("EXEC", Color.Blue);
			cl.Add("EXECUTE", Color.Blue);
			cl.Add("EXISTS", Color.Gray);
			cl.Add("EXIT", Color.Blue);
			cl.Add("FETCH", Color.Blue);
			cl.Add("FILE", Color.Gray);
			cl.Add("FILLFACTOR", Color.Gray);
			cl.Add("FOR", Color.Blue);
			cl.Add("FOREIGN", Color.Blue);
			cl.Add("FREETEXT", Color.Blue);
			cl.Add("FREETEXTTABLE", Color.Blue);
			cl.Add("FROM", Color.Blue);
			cl.Add("FULL", Color.Gray);
			cl.Add("FUNCTION", Color.Blue);
			cl.Add("GOTO", Color.Blue);
			cl.Add("GRANT", Color.Gray);
			cl.Add("GROUP", Color.Blue);
			cl.Add("HAVING", Color.Blue);
			cl.Add("HOLDLOCK", Color.Gray);
			cl.Add("IDENTITY", Color.Salmon);
			cl.Add("IDENTITYCOL", Color.Salmon);
			cl.Add("IDENTITY_INSERT", Color.Salmon);
			cl.Add("IF", Color.Blue);
			cl.Add("IN", Color.Gray);
			cl.Add("INDEX", Color.Blue);
			cl.Add("INNER", Color.Blue);
			cl.Add("INSERT", Color.Blue);
			cl.Add("INTERSECT", Color.Blue);
			cl.Add("INTO", Color.Blue);
			cl.Add("IS", Color.Gray);
			cl.Add("JOIN", Color.Gray);
			cl.Add("KEY", Color.Blue);
			cl.Add("KILL", Color.Salmon);
			cl.Add("LEFT", Color.Gray);
			cl.Add("LIKE", Color.Gray);
			cl.Add("LINENO", Color.Gray);
			cl.Add("LOAD", Color.Gray);
			cl.Add("NATIONAL", Color.Gray);
			cl.Add("NOCHECK", Color.Blue);
			cl.Add("NONCLUSTERED", Color.Blue);
			cl.Add("NOT", Color.Gray);
			cl.Add("NULL", Color.Gray);
			cl.Add("NULLIF", Color.Salmon);
			cl.Add("OF", Color.Gray);
			cl.Add("OFF", Color.Blue);
			cl.Add("OFFSETS", Color.Gray);
			cl.Add("ON", Color.Blue);
			cl.Add("OPEN", Color.Blue);
			cl.Add("OPENDATASOURCE", Color.Blue);
			cl.Add("OPENQUERY", Color.Blue);
			cl.Add("OPENROWSET", Color.Blue);
			cl.Add("OPENXML", Color.Blue);
			cl.Add("OPTION", Color.Blue);
			cl.Add("OR", Color.Gray);
			cl.Add("ORDER", Color.Blue);
			cl.Add("OUTER", Color.Gray);
			cl.Add("OVER", Color.Blue);
			cl.Add("PERCENT", Color.Blue);
			cl.Add("PLAN", Color.Blue);
			cl.Add("PRECISION", Color.Blue);
			cl.Add("PRIMARY", Color.Blue);
			cl.Add("PRINT", Color.Blue);
			cl.Add("PROC", Color.Blue);
			cl.Add("PROCEDURE", Color.Blue);
			cl.Add("PUBLIC", Color.Blue);
			cl.Add("RAISERROR", Color.Salmon);
			cl.Add("READ", Color.Salmon);
			cl.Add("READTEXT", Color.Salmon);
			cl.Add("RECONFIGURE", Color.Salmon);
			cl.Add("REFERENCES", Color.Salmon);
			cl.Add("REPLICATION", Color.Salmon);
			cl.Add("RESTORE", Color.Blue);
			cl.Add("RESTRICT", Color.Gray);
			cl.Add("RETURN", Color.Blue);
			cl.Add("REVOKE", Color.Blue);
			cl.Add("RIGHT", Color.Gray);
			cl.Add("ROLLBACK", Color.Blue);
			cl.Add("ROWCOUNT", Color.Salmon);
			cl.Add("ROWGUIDCOL", Color.Salmon);
			cl.Add("RULE", Color.Blue);
			cl.Add("SAVE", Color.Salmon);
			cl.Add("SCHEMA", Color.Blue);
			cl.Add("SELECT", Color.Blue);
			cl.Add("SESSION_USER", Color.Blue);
			cl.Add("SET", Color.Blue);
			cl.Add("SETUSER", Color.Blue);
			cl.Add("SHUTDOWN", Color.Blue);
			cl.Add("SOME", Color.Blue);
			cl.Add("STATISTICS", Color.Salmon);
			cl.Add("SYSTEM_USER", Color.Salmon);
			cl.Add("TABLE", Color.Blue);
			cl.Add("TEXTSIZE", Color.Salmon);
			cl.Add("THEN", Color.Blue);
			cl.Add("TO", Color.Blue);
			cl.Add("TOP", Color.Blue);
			cl.Add("TRAN", Color.Blue);
			cl.Add("TRANSACTION", Color.Blue);
			cl.Add("TRIGGER", Color.Blue);
			cl.Add("TRUNCATE", Color.Blue);
			cl.Add("TSEQUAL", Color.Blue);
			cl.Add("UNION", Color.Blue);
			cl.Add("UNIQUE", Color.Blue);
			cl.Add("UPDATE", Color.Blue);
			cl.Add("UPDATETEXT", Color.Salmon);
			cl.Add("USE", Color.Blue);
			cl.Add("USER", Color.Salmon);
			cl.Add("VALUES", Color.Blue);
			cl.Add("VARYING", Color.Blue);
			cl.Add("VIEW", Color.Blue);
			cl.Add("WAITFOR", Color.Blue);
			cl.Add("WHEN", Color.Blue);
			cl.Add("WHERE", Color.Blue);
			cl.Add("WHILE", Color.Blue);
			cl.Add("WITH", Color.Blue);
			cl.Add("WRITETEXT", Color.Salmon);
			
			string rx_search = "(";
			string rx_sep = string.Empty;
			foreach (string key in cl.Keys)
			{
				rx_search += rx_sep + "\\b" + key + "\\b";
				rx_sep = "|";
			}
			rx_search +=")";
			
			Regex rex = new Regex(rx_search, RegexOptions.IgnoreCase);  
		    MatchCollection mc = rex.Matches(rtb_sql.Text);  
		    int StartCursorPosition = rtb_sql.SelectionStart;  
		    rtb_sql.SelectAll();
		    rtb_sql.SelectionColor = Color.Black;
		    rtb_sql.SelectionStart = StartCursorPosition;
		    
		    foreach (Match m in mc)
		    {  
		        int startIndex = m.Index;  
		        int StopIndex = m.Length;  
		        rtb_sql.Select(startIndex, StopIndex);
		        rtb_sql.SelectionColor = cl[m.Value.ToUpper()];
		        rtb_sql.SelectionStart = StartCursorPosition;  
		        rtb_sql.SelectionColor = Color.Black;  
		    }  */
		}
		
		/// <summary>
		/// Bouton OK
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		
		void Btn_okClick(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			try
			{
				File.WriteAllText("last.sql", rtb_sql.Text);
			}
			catch (Exception exp)
			{
				MessageBox.Show("Erreur lors de la sauvegarde de la dernière requête utilisée.\n" + exp.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			this.Close();
		}
		
		void Btn_cancelClick(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
	}
}
