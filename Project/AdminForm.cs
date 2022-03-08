using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Project
{
    public partial class AdminForm : Form
    {
        globalVar glob = new globalVar();

        /* конструктор класса */
        public AdminForm()
        {
            InitializeComponent();
        }

        /* Действия при закрытии программы */
        private void AdminForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result;

            result = MessageBox.Show("Вы уверены, что хотите выйти?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
            e.Cancel = true;
            
        }

        /* Действия при загрузке формы*/
        private void AdminForm_Load(object sender, EventArgs e)
        {
            updateListBox();            
        }

        /*Переход на форму регестрации пользователя*/
        private void зарегестрироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 mngForm = new Form2();
            mngForm.Show();
        }

        /*Переход на форму удаления пользователя*/
        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 mngForm = new Form4();
            mngForm.Show();
        }

        /*Перезапуск программы*/
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

        /* Обновление всех листбоксов в форме*/
        private void updateListBox()
        {
            glob.selectALL(listBox1);
            glob.selectALL(listBox2);
            glob.selectALL(listBox3);
            glob.selectALL(listBox4);
        }
        /*Кнопка добавление товара*/
        private void button1_Click(object sender, EventArgs e)
        {
            glob.StartSQLite();
            if (label19.Visible)
                label19.Visible = false;

            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text) &&
                !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) &&
                !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox3.Text) &&
                !string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox4.Text))
            {
                SQLiteCommand cmd = globalVar.db.CreateCommand();

                cmd.CommandText = "insert into [products] (producer, model, price, quantity) values (@producer, @model, @price, @quantity)";

                cmd.Parameters.Add("@producer", System.Data.DbType.String).Value = Convert.ToString(textBox1.Text); // подставляем в запрос параметры
                cmd.Parameters.Add("@model", System.Data.DbType.String).Value = Convert.ToString(textBox2.Text);
                try{
                    cmd.Parameters.Add("@price", System.Data.DbType.Int32).Value = Convert.ToInt32(textBox3.Text);
                    cmd.Parameters.Add("@quantity", System.Data.DbType.Int32).Value = Convert.ToInt32(textBox4.Text);
                }catch (Exception){
                    label19.Visible = true;
                    label19.Text = "Параметры 'количество' и 'цена' \n должны быть числами!";
                }
                try{   
                    cmd.ExecuteNonQuery();
                    
                    MessageBox.Show("Запись успешно добавлена!");                    
                    updateListBox();
                }catch (Exception) {
                    //MessageBox.Show("Error!");
                }
            }
            else
            {
                label19.Visible = true;
                label19.Text = "Все поля должны быть заполнены!";
            }
            glob.StopSQLite();
        }

/// ///////////////////////////////////////////////////////////////////////////////////////////
        /*Кнопка поиска товара*/
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
            if (textBox8.Text != "" && textBox7.Text == "" && textBox6.Text == "" && textBox5.Text == "") {

                    SQLiteCommand cmd = globalVar.db.CreateCommand();
                    string var1 = textBox8.Text;
                    cmd.CommandText = "select * from products where producer like '%" + var1 + "%'"; // поиск                    

                    
                    SQLiteDataReader SQL = cmd.ExecuteReader(); // выполняем запрос
                    listBox2.Items.Clear();

                    while (SQL.Read()){
                        listBox2.Items.Add("ID: " + SQL[0].ToString() + "; Производитель: " + SQL[1].ToString() + "; Модель: " + SQL[2].ToString() + "; Цена: " + SQL[3].ToString() + "; Количество товара: " + SQL[4].ToString() + ".");
                   }

                    SQL.Close();
                    
                }

            if (textBox8.Text == "" && textBox7.Text != "" && textBox6.Text == "" && textBox5.Text == "") {
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
        /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        /* Изменение товара*/

        private void button9_Click(object sender, EventArgs e)
        {
            if (label21.Visible)
                label21.Visible = false;

            if (string.IsNullOrEmpty(textBox13.Text) && string.IsNullOrWhiteSpace(textBox13.Text))
            {
                label21.Visible = true;
            }
            else
            {
               
            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            glob.StartSQLite();

            if (string.IsNullOrEmpty(textBox13.Text) && string.IsNullOrWhiteSpace(textBox13.Text))
            {
                label21.Visible = true;
            }
            else
            {
                SQLiteCommand cmd = globalVar.db.CreateCommand();
                cmd.CommandText = "UPDATE [products] SET[producer] = @producer, [model] = @model, [price] = @price, [quantity] = @quantity WHERE[id] = @id";                       

                try
                {
                    cmd.Parameters.Add("@id", System.Data.DbType.String).Value = Convert.ToString(textBox13.Text);
                    cmd.Parameters.Add("@producer", System.Data.DbType.String).Value = Convert.ToString(textBox12.Text);
                    cmd.Parameters.Add("@model", System.Data.DbType.String).Value = Convert.ToString(textBox11.Text);
                    cmd.Parameters.Add("@price", System.Data.DbType.String).Value = Convert.ToString(textBox10.Text);
                    cmd.Parameters.Add("@quantity", System.Data.DbType.String).Value = Convert.ToString(textBox9.Text);
                    cmd.ExecuteNonQuery();
                    
                    updateListBox();
                }
                catch (Exception) {
                    MessageBox.Show("Ошибка!");
                }
            }
            glob.StopSQLite();
        }

        /* Удаление товара */
        private void button8_Click(object sender, EventArgs e)
        {
            glob.StartSQLite();
            if (label22.Visible)
                label22.Visible = false;

            if (string.IsNullOrEmpty(textBox14.Text) && string.IsNullOrWhiteSpace(textBox14.Text))
            {
                label22.Visible = true;
                label22.Text = "Поле ID должно быть заполнено!";
            }
            else
            {
                SQLiteCommand cmd = globalVar.db.CreateCommand();
                cmd.CommandText = "DELETE from [products] where ID = @id";

                cmd.Parameters.Add("@id", System.Data.DbType.String).Value = Convert.ToString(textBox14.Text);

                try
                {                    
                    cmd.ExecuteNonQuery();
                    
                    label22.Text = "Удаление прошло успешно!";
                    label22.ForeColor = Color.Green;
                    updateListBox();
                }
                catch (Exception) {
                    MessageBox.Show("Ошибка при удалении!");
                }
            }
            glob.StopSQLite();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sort = Convert.ToString(comboBox1.SelectedItem);
            glob.selectALL(listBox1, sort);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string sort = Convert.ToString(comboBox2.SelectedItem);
            glob.selectALL(listBox2, sort);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string sort = Convert.ToString(comboBox3.SelectedItem);
            glob.selectALL(listBox3, sort);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string sort = Convert.ToString(comboBox4.SelectedItem);
            glob.selectALL(listBox4, sort);
        }
        
        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            if (textBox13.Text != null && textBox13.Text != "")
            {
                glob.StartSQLite();
                SQLiteCommand getProdcmd = globalVar.db.CreateCommand();

                getProdcmd.CommandText = "Select producer FROM [products] where id = @id;";                

                SQLiteCommand getModelcmd = globalVar.db.CreateCommand();

                getModelcmd.CommandText = "Select model FROM [products] where id = @id;";         

                SQLiteCommand getPricecmd = globalVar.db.CreateCommand();

                getPricecmd.CommandText = "Select price FROM [products] where id = @id;";
         
                SQLiteCommand getQuantitycmd = globalVar.db.CreateCommand();

                getQuantitycmd.CommandText = "Select quantity FROM [products] where id = @id;";

                try
                {
                    getModelcmd.Parameters.Add("@id", System.Data.DbType.String).Value = Convert.ToInt32(textBox13.Text);
                    getPricecmd.Parameters.Add("@id", System.Data.DbType.String).Value = Convert.ToInt32(textBox13.Text);
                    getProdcmd.Parameters.Add("@id", System.Data.DbType.String).Value = Convert.ToInt32(textBox13.Text);
                    getQuantitycmd.Parameters.Add("@id", System.Data.DbType.String).Value = Convert.ToInt32(textBox13.Text);
                    textBox12.Text = (string)getProdcmd.ExecuteScalar();
                    textBox11.Text = (string)getModelcmd.ExecuteScalar();
                    textBox10.Text = Convert.ToString(getPricecmd.ExecuteScalar());
                    textBox9.Text = Convert.ToString(getQuantitycmd.ExecuteScalar());
                }
                catch (FormatException)
                {
                    MessageBox.Show("Введите число!");
                    textBox13.Text = "";
                }               
               
                glob.StopSQLite();
            }
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
