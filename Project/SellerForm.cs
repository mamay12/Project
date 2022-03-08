using System;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Project
{
    public partial class SellerForm : Form
    {
        globalVar glob = new globalVar();

        /* конструктор класса */
        public SellerForm()
        {
            InitializeComponent();
        }

        /*закрытие формы */
        private void SellerForm_FormClosing(object sender, FormClosingEventArgs e)
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
            glob.selectALL(listBox3);
        }

        /*загрузка формы*/
        private void SellerForm_Load(object sender, EventArgs e)
        {
            updateListBox();
        }

        /* кнопка меню выйти */
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

        /*поиск товара */
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

        /* обновить таблицу на странице поиска */
        private void button4_Click(object sender, EventArgs e)
        {
            string sort = Convert.ToString(comboBox2.SelectedItem);
            glob.selectALL(listBox2, sort);
        }

        /*страница продажи товара*/
        private void button6_Click(object sender, EventArgs e)
        {
            glob.StartSQLite();
            if (label21.Visible)
                label21.Visible = false;

            if (string.IsNullOrEmpty(textBox13.Text) && string.IsNullOrWhiteSpace(textBox13.Text) &&
                string.IsNullOrEmpty(textBox9.Text) && string.IsNullOrWhiteSpace(textBox9.Text))
            {
                label21.Visible = true;
            }
            else
            {
                SQLiteCommand cmd = globalVar.db.CreateCommand();

                cmd.CommandText = "update products set quantity = quantity-@count where id = @id;";
                try
                {
                    cmd.Parameters.Add("@count", System.Data.DbType.Int32).Value = Convert.ToInt32(textBox9.Text); // подставляем в запрос параметры
                    cmd.Parameters.Add("@id", System.Data.DbType.Int32).Value = Convert.ToInt32(textBox13.Text);
                    cmd.ExecuteNonQuery();
                }
                catch (FormatException) {
                    MessageBox.Show("Введите числа!");
                    textBox13.Text = "";
                    textBox9.Text = "";
                }
                

                
                updateListBox();
            }
            glob.StopSQLite();
        }

        /*обновить листбокс на странице продажи*/
        private void button5_Click(object sender, EventArgs e)
        {
            string sort = Convert.ToString(comboBox3.SelectedItem);
            glob.selectALL(listBox3, sort);
        }

        /*возврат товара*/
        private void button2_Click(object sender, EventArgs e)
        {
            glob.StartSQLite();
            if (label1.Visible)
                label1.Visible = false;

            if (string.IsNullOrEmpty(textBox1.Text) && string.IsNullOrWhiteSpace(textBox1.Text) &&
                string.IsNullOrEmpty(textBox2.Text) && string.IsNullOrWhiteSpace(textBox2.Text))
            {
                label1.Visible = true;
            }
            else
            {
                if (checkBox1.Checked == true)
                {
                    MessageBox.Show("Товар удачно списан.");
                }
                else
                {
                    SQLiteCommand cmd = globalVar.db.CreateCommand();

                    cmd.CommandText = "update products set quantity = quantity+@count where id = @id;";
                    try
                    {
                        cmd.Parameters.Add("@count", System.Data.DbType.Int32).Value = Convert.ToInt32(textBox2.Text); // подставляем в запрос параметры
                        cmd.Parameters.Add("@id", System.Data.DbType.Int32).Value = Convert.ToInt32(textBox1.Text);

                        cmd.ExecuteNonQuery();
                    }
                    catch (FormatException) {
                        MessageBox.Show("Введите числа!");
                        textBox1.Text = "";
                        textBox2.Text = "";
                    }                                       

                    

                    updateListBox();
                }
                glob.StopSQLite();
            }
        }

        /*обновить листбокс на странице возврата*/
        private void button1_Click(object sender, EventArgs e)
        {
            string sort = Convert.ToString(comboBox1.SelectedItem);
            glob.selectALL(listBox1, sort);
        }
    }
}