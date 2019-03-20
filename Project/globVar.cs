using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Project
{
    class globalVar
    {
        public static SQLiteConnection db;
        
        public void StartSQLite() {
            db = new SQLiteConnection("Data Source = db.db; Version = 3");
            try { db.Open(); }
            catch (Exception)
            {
                MessageBox.Show("База данных не найдена.");
            }
        }

        public void StopSQLite() {
            db = new SQLiteConnection("Data Source = db.db; Version = 3");
            try { db.Close(); }
            catch (Exception) {
                MessageBox.Show("Поток не закрыт!");
            }
        }

        public SQLiteConnection get_path() {
            return db;
        }
    }
}
