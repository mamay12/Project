using System;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Project
{
    public partial class ManagerForm : Form
    {
        globalVar glob = new globalVar();

        /* добавление товара */
        public ManagerForm()
        {            
            InitializeComponent();
;        }

        /* закрытие формы */
        private void ManagerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result;

            result = MessageBox.Show("Вы уверены, что хотите выйти?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Environment.Exit(0);
            }

            e.Cancel = true;
        }

        /* Обновление всех листбоксов в форме*/
        private void updateListBox()
        {
            glob.selectALL(listBox1);
            glob.selectALL(listBox2);
        }

        /* при загрузке формы */
        private void ManagerForm_Load(object sender, EventArgs e)
        {
            updateListBox();
        }

        /* опция "выйти" */
        private void выйтиToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult result;

            result = MessageBox.Show("Вы уверены, что хотите перезайти?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
            }

            this.Hide();
            var form1 = new Form1();
            form1.Closed += (s, args) => this.Close();
            form1.Show();
        }

        /* добавить продукт*/
        private void button1_Click(object sender, EventArgs e)
        {
            glob.StartSQLite();
            if (label19.Visible)
                label19.Visible = false;

            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text) &&
                !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) &&
               // !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox3.Text) &&
                !string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox4.Text))
            {
                SQLiteCommand cmd = globalVar.db.CreateCommand();

                cmd.CommandText = "insert into [products] (producer, model, price, quantity) values (@producer, @model, @price, @quantity)";

                cmd.Parameters.Add("@producer", System.Data.DbType.String).Value = Convert.ToString(textBox1.Text); // подставляем в запрос параметры
                cmd.Parameters.Add("@model", System.Data.DbType.String).Value = Convert.ToString(textBox2.Text);
                try
                {
                    cmd.Parameters.Add("@price", System.Data.DbType.Int32).Value = 0;
                    cmd.Parameters.Add("@quantity", System.Data.DbType.Int32).Value = Convert.ToInt32(textBox4.Text);
                }
                catch (Exception)
                {
                    label19.Visible = true;
                    label19.Text = "Параметры 'количество' и 'цена' должны быть числами!";
                }
                try
                {
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Запись успешно добавлена!");
                    updateListBox();
                }
                catch (Exception)
                {
                    MessageBox.Show("Error!");
                }
            }
            else
            {
                label19.Visible = true;
                label19.Text = "Все поля должны быть заполнены!";
            }
            glob.StopSQLite();
        }

    /* кнопка поиска товара */
        private void button3_Click(object sender, EventArgs e)
        {
            glob.StartSQLite();
            if (label20.Visible)
                label20.Visible = false;

            if (((string.IsNullOrEmpty(textBox5.Text) && string.IsNullOrWhiteSpace(textBox5.Text))
                &&
                (string.IsNullOrEmpty(textBox6.Text) && string.IsNullOrWhiteSpace(textBox6.Text)))
                &&
                ((string.IsNullOrEmpty(textBox7.Text) && string.IsNullOrWhiteSpace(textBox7.Text))
                &&
                (string.IsNullOrEmpty(textBox8.Text) && string.IsNullOrWhiteSpace(textBox8.Text))))
            {
                label20.Visible = true;
                label20.Text = "Заполните хотя бы одно поле!";
            }



            //если заполнен только один из текстбоксов
            if (textBox8.Text != "" && textBox7.Text == "" && textBox6.Text == "" && textBox5.Text == "")
            {

                SQLiteCommand cmd = globalVar.db.CreateCommand();
                string var1 = textBox8.Text;
                cmd.CommandText = "select * from products where producer like '%" + var1 + "%'"; // поиск                    


                SQLiteDataReader SQL = cmd.ExecuteReader(); // выполняем запрос
                listBox2.Items.Clear();

                while (SQL.Read())
                {
                    listBox2.Items.Add("ID: " + SQL[0].ToString() + "; Производитель: " + SQL[1].ToString() + "; Модель: " + SQL[2].ToString() + "; Цена: " + SQL[3].ToString() + "; Количество товара: " + SQL[4].ToString() + ".");
                }

                SQL.Close();

            }

            if (textBox8.Text == "" && textBox7.Text != "" && textBox6.Text == "" && textBox5.Text == "")
            {
                SQLiteCommand cmd = globalVar.db.CreateCommand();
                string var1 = textBox7.Text;
                cmd.CommandText = "select * from products where model like '%" + var1 + "%'"; // поиск                    

                SQLiteDataReader SQL = cmd.ExecuteReader(); // выполняем запрос
                listBox2.Items.Clear();

                while (SQL.Read())
                {
                    listBox2.Items.Add("ID: " + SQL[0].ToString() + "; Производитель: " + SQL[1].ToString() + "; Модель: " + SQL[2].ToString() + "; Цена: " + SQL[3].ToString() + "; Количество товара: " + SQL[4].ToString() + ".");
                }

                SQL.Close();
            }

            if (textBox8.Text == "" && textBox7.Text == "" && textBox6.Text != "" && textBox5.Text == "")
            {
                SQLiteCommand cmd = globalVar.db.CreateCommand();
                string var1 = textBox6.Text;
                cmd.CommandText = "select * from products where price like '%" + var1 + "%'"; // поиск                    


                SQLiteDataReader SQL = cmd.ExecuteReader(); // выполняем запрос
                listBox2.Items.Clear();

                while (SQL.Read())
                {
                    listBox2.Items.Add("ID: " + SQL[0].ToString() + "; Производитель: " + SQL[1].ToString() + "; Модель: " + SQL[2].ToString() + "; Цена: " + SQL[3].ToString() + "; Количество товара: " + SQL[4].ToString() + ".");
                }

                SQL.Close();
            }

            if (textBox8.Text == "" && textBox7.Text == "" && textBox6.Text == "" && textBox5.Text != "")
            {
                SQLiteCommand cmd = globalVar.db.CreateCommand();
                string var1 = textBox5.Text;
                cmd.CommandText = "select * from products where quantity like '%" + var1 + "%'"; // поиск                    

                SQLiteDataReader SQL = cmd.ExecuteReader(); // выполняем запрос
                listBox2.Items.Clear();

                while (SQL.Read())
                {
                    listBox2.Items.Add("ID: " + SQL[0].ToString() + "; Производитель: " + SQL[1].ToString() + "; Модель: " + SQL[2].ToString() + "; Цена: " + SQL[3].ToString() + "; Количество товара: " + SQL[4].ToString() + ".");
                }

                SQL.Close();
            }

            //если заполнен производитель + что-то другое

            if (textBox8.Text != "" && textBox7.Text != "" && textBox6.Text == "" && textBox5.Text == "")
            {

                SQLiteCommand cmd = globalVar.db.CreateCommand();
                string var1 = textBox8.Text;
                string var2 = textBox7.Text;
                cmd.CommandText = "select * from products where producer like '%" + var1 + "%' and model like '%" + var2 + "%'"; // поиск                    

                SQLiteDataReader SQL = cmd.ExecuteReader(); // выполняем запрос
                listBox2.Items.Clear();

                while (SQL.Read())
                {
                    listBox2.Items.Add("ID: " + SQL[0].ToString() + "; Производитель: " + SQL[1].ToString() + "; Модель: " + SQL[2].ToString() + "; Цена: " + SQL[3].ToString() + "; Количество товара: " + SQL[4].ToString() + ".");
                }

                SQL.Close();
            }

            if (textBox8.Text != "" && textBox7.Text == "" && textBox6.Text != "" && textBox5.Text == "")
            {

                SQLiteCommand cmd = globalVar.db.CreateCommand();
                string var1 = textBox8.Text;
                string var2 = textBox6.Text;
                cmd.CommandText = "select * from products where producer like '%" + var1 + "%' and price like '%" + var2 + "%'"; // поиск                    

                SQLiteDataReader SQL = cmd.ExecuteReader(); // выполняем запрос
                listBox2.Items.Clear();

                while (SQL.Read())
                {
                    listBox2.Items.Add("ID: " + SQL[0].ToString() + "; Производитель: " + SQL[1].ToString() + "; Модель: " + SQL[2].ToString() + "; Цена: " + SQL[3].ToString() + "; Количество товара: " + SQL[4].ToString() + ".");
                }

                SQL.Close();
            }

            if (textBox8.Text != "" && textBox7.Text == "" && textBox6.Text == "" && textBox5.Text != "")
            {

                SQLiteCommand cmd = globalVar.db.CreateCommand();
                string var1 = textBox8.Text;
                string var2 = textBox5.Text;
                cmd.CommandText = "select * from products where producer like '%" + var1 + "%' and quantity like '%" + var2 + "%'"; // поиск                    

                SQLiteDataReader SQL = cmd.ExecuteReader(); // выполняем запрос
                listBox2.Items.Clear();

                while (SQL.Read())
                {
                    listBox2.Items.Add("ID: " + SQL[0].ToString() + "; Производитель: " + SQL[1].ToString() + "; Модель: " + SQL[2].ToString() + "; Цена: " + SQL[3].ToString() + "; Количество товара: " + SQL[4].ToString() + ".");
                }

                SQL.Close();
            }

            //если заполнена модель + что-то другое
            if (textBox8.Text == "" && textBox7.Text != "" && textBox6.Text != "" && textBox5.Text == "")
            {

                SQLiteCommand cmd = globalVar.db.CreateCommand();
                string var1 = textBox7.Text;
                string var2 = textBox6.Text;
                cmd.CommandText = "select * from products where model like '%" + var1 + "%' and price like '%" + var2 + "%'"; // поиск                    

                SQLiteDataReader SQL = cmd.ExecuteReader(); // выполняем запрос
                listBox2.Items.Clear();

                while (SQL.Read())
                {
                    listBox2.Items.Add("ID: " + SQL[0].ToString() + "; Производитель: " + SQL[1].ToString() + "; Модель: " + SQL[2].ToString() + "; Цена: " + SQL[3].ToString() + "; Количество товара: " + SQL[4].ToString() + ".");
                }

                SQL.Close();
            }

            if (textBox8.Text == "" && textBox7.Text != "" && textBox6.Text == "" && textBox5.Text != "")
            {

                SQLiteCommand cmd = globalVar.db.CreateCommand();
                string var1 = textBox7.Text;
                string var2 = textBox5.Text;
                cmd.CommandText = "select * from products where model like '%" + var1 + "%' and quantity like '%" + var2 + "%'"; // поиск                    

                SQLiteDataReader SQL = cmd.ExecuteReader(); // выполняем запрос
                listBox2.Items.Clear();

                while (SQL.Read())
                {
                    listBox2.Items.Add("ID: " + SQL[0].ToString() + "; Производитель: " + SQL[1].ToString() + "; Модель: " + SQL[2].ToString() + "; Цена: " + SQL[3].ToString() + "; Количество товара: " + SQL[4].ToString() + ".");
                }

                SQL.Close();
            }

            //цена + кол-во

            if (textBox8.Text == "" && textBox7.Text == "" && textBox6.Text != "" && textBox5.Text != "")
            {

                SQLiteCommand cmd = globalVar.db.CreateCommand();
                string var1 = textBox6.Text;
                string var2 = textBox5.Text;
                cmd.CommandText = "select * from products where price like '%" + var1 + "%' and quantity like '%" + var2 + "%'"; // поиск                    

                SQLiteDataReader SQL = cmd.ExecuteReader(); // выполняем запрос
                listBox2.Items.Clear();

                while (SQL.Read())
                {
                    listBox2.Items.Add("ID: " + SQL[0].ToString() + "; Производитель: " + SQL[1].ToString() + "; Модель: " + SQL[2].ToString() + "; Цена: " + SQL[3].ToString() + "; Количество товара: " + SQL[4].ToString() + ".");
                }

                SQL.Close();
            }

            // тройные комбинации
            if (textBox8.Text != "" && textBox7.Text != "" && textBox6.Text != "" && textBox5.Text == "")
            {

                SQLiteCommand cmd = globalVar.db.CreateCommand();
                string var1 = textBox8.Text;
                string var2 = textBox7.Text;
                string var3 = textBox6.Text;
                cmd.CommandText = "select * from products where producer like '%" + var1 + "%' and model like '%" + var2 + "%' and price like '%" + var3 + "%'"; // поиск                    

                SQLiteDataReader SQL = cmd.ExecuteReader(); // выполняем запрос
                listBox2.Items.Clear();

                while (SQL.Read())
                {
                    listBox2.Items.Add("ID: " + SQL[0].ToString() + "; Производитель: " + SQL[1].ToString() + "; Модель: " + SQL[2].ToString() + "; Цена: " + SQL[3].ToString() + "; Количество товара: " + SQL[4].ToString() + ".");
                }

                SQL.Close();
            }

            if (textBox8.Text != "" && textBox7.Text != "" && textBox6.Text == "" && textBox5.Text != "")
            {

                SQLiteCommand cmd = globalVar.db.CreateCommand();
                string var1 = textBox8.Text;
                string var2 = textBox7.Text;
                string var3 = textBox5.Text;
                cmd.CommandText = "select * from products where producer like '%" + var1 + "%' and model like '%" + var2 + "%' and quantity like '%" + var3 + "%'"; // поиск                    

                SQLiteDataReader SQL = cmd.ExecuteReader(); // выполняем запрос
                listBox2.Items.Clear();

                while (SQL.Read())
                {
                    listBox2.Items.Add("ID: " + SQL[0].ToString() + "; Производитель: " + SQL[1].ToString() + "; Модель: " + SQL[2].ToString() + "; Цена: " + SQL[3].ToString() + "; Количество товара: " + SQL[4].ToString() + ".");
                }

                SQL.Close();
            }

            if (textBox8.Text != "" && textBox7.Text != "" && textBox6.Text == "" && textBox5.Text != "")
            {

                SQLiteCommand cmd = globalVar.db.CreateCommand();
                string var1 = textBox7.Text;
                string var2 = textBox6.Text;
                string var3 = textBox5.Text;
                cmd.CommandText = "select * from products where model like '%" + var1 + "%' and price like '%" + var2 + "%' and quantity like '%" + var3 + "%'"; // поиск                    

                SQLiteDataReader SQL = cmd.ExecuteReader(); // выполняем запрос
                listBox2.Items.Clear();

                while (SQL.Read())
                {
                    listBox2.Items.Add("ID: " + SQL[0].ToString() + "; Производитель: " + SQL[1].ToString() + "; Модель: " + SQL[2].ToString() + "; Цена: " + SQL[3].ToString() + "; Количество товара: " + SQL[4].ToString() + ".");
                }

                SQL.Close();
            }
            // когда 4 бокса заполнены
            if (textBox8.Text != "" && textBox7.Text != "" && textBox6.Text != "" && textBox5.Text != "")
            {

                SQLiteCommand cmd = globalVar.db.CreateCommand();
                string var1 = textBox8.Text;
                string var2 = textBox7.Text;
                string var3 = textBox6.Text;
                string var4 = textBox5.Text;

                cmd.CommandText = "select * from products where producer like '%" + var1 + "%' and model like '%" + var2 + "%' and price like '%" + var3 + "%' and quantity like '%" + var4 + "%'"; // поиск                    

                SQLiteDataReader SQL = cmd.ExecuteReader(); // выполняем запрос
                listBox2.Items.Clear();

                while (SQL.Read())
                {
                    listBox2.Items.Add("ID: " + SQL[0].ToString() + "; Производитель: " + SQL[1].ToString() + "; Модель: " + SQL[2].ToString() + "; Цена: " + SQL[3].ToString() + "; Количество товара: " + SQL[4].ToString() + ".");
                }

                SQL.Close();
            }
            glob.StopSQLite();
        }

        /* обновить таблицу на первой странице */
        private void button2_Click(object sender, EventArgs e)
        {
            string sort = Convert.ToString(comboBox1.SelectedItem);
            glob.selectALL(listBox1, sort);
        }

        /*обновить таблицу на второй странице*/
        private void button4_Click(object sender, EventArgs e)
        {
            string sort = Convert.ToString(comboBox2.SelectedItem);
            glob.selectALL(listBox2, sort);
        }
    }
}
