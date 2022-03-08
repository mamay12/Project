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

        public void selectALL(ListBox list, string sort = "бренду") {
            db = new SQLiteConnection("Data Source = db.db; Version = 3");

            try { db.Open(); }
            catch (Exception)
            {
                MessageBox.Show("База данных не найдена.");
            }

            switch (sort) {
                case "бренду":
                    SQLiteCommand cmd1 = db.CreateCommand();
                    cmd1.CommandText = "select * from products order by producer ASC";

                    SQLiteDataReader SQL1 = cmd1.ExecuteReader(); // выполняем запрос
                    list.Items.Clear();

                    while (SQL1.Read())
                    {
                        list.Items.Add("ID: " + SQL1[0].ToString() + "; Производитель: " + SQL1[1].ToString() + "; Модель: " + SQL1[2].ToString() + "; Цена: " + SQL1[3].ToString() + "; Количество товара: " + SQL1[4].ToString() + ".");
                    }

                    SQL1.Close();
                    break;

                case "модели":
                    SQLiteCommand cmd2 = db.CreateCommand();
                    cmd2.CommandText = "select * from products order by model ASC";

                    SQLiteDataReader SQL2 = cmd2.ExecuteReader(); // выполняем запрос
                    list.Items.Clear();

                    while (SQL2.Read())
                    {
                        list.Items.Add("ID: " + SQL2[0].ToString() + "; Производитель: " + SQL2[1].ToString() + "; Модель: " + SQL2[2].ToString() + "; Цена: " + SQL2[3].ToString() + "; Количество товара: " + SQL2[4].ToString() + ".");
                    }

                    SQL2.Close();
                    break;

                case "цене":
                    SQLiteCommand cmd3 = db.CreateCommand();
                    cmd3.CommandText = "select * from products order by price ASC";

                    SQLiteDataReader SQL3 = cmd3.ExecuteReader(); // выполняем запрос
                    list.Items.Clear();

                    while (SQL3.Read())
                    {
                        list.Items.Add("ID: " + SQL3[0].ToString() + "; Производитель: " + SQL3[1].ToString() + "; Модель: " + SQL3[2].ToString() + "; Цена: " + SQL3[3].ToString() + "; Количество товара: " + SQL3[4].ToString() + ".");
                    }

                    SQL3.Close();
                    break;

                case "количеству":
                    SQLiteCommand cmd4 = db.CreateCommand();
                    cmd4.CommandText = "select * from products order by quantity ASC";

                    SQLiteDataReader SQL4 = cmd4.ExecuteReader(); // выполняем запрос
                    list.Items.Clear();

                    while (SQL4.Read())
                    {
                        list.Items.Add("ID: " + SQL4[0].ToString() + "; Производитель: " + SQL4[1].ToString() + "; Модель: " + SQL4[2].ToString() + "; Цена: " + SQL4[3].ToString() + "; Количество товара: " + SQL4[4].ToString() + ".");
                    }

                    SQL4.Close();
                    break;
            }
            db.Close();
        }

        public SQLiteConnection get_path() {
            return db;
        }
    }
}
