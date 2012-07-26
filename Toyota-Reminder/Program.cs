using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data;
using ToyotaDAL;

namespace Toyota_Reminder
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
          
        static void Main()
        {
            IDbConnection _conn;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                _conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\ToyotaAPP\toyota.mdb");
                _conn.Open();

                Application.Run(new MenuUtama(_conn));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fail to connect/disconnect: " + ex.Message);
            }
            
        }
    }
}
