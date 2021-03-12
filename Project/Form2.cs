using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Project
{
    public partial class Form2 : Form
    {
        globalVar glob = new globalVar();

        public Form2()
        {
            InitializeComponent();
        }

        private void save_reg_Click(object sender, EventArgs e)
        {
            glob.StartSQLite();
            SQLiteCommand cmd = globalVar.db.CreateCommand();
            if (((string.IsNullOrEmpty(reg_login.Text) && string.IsNullOrWhiteSpace(reg_login.Text))
                 ||
                 (string.IsNullOrEmpty(reg_password.Text) && string.IsNullOrWhiteSpace(reg_password.Text)))
                 ||
                 (reg_positions.SelectedItem != null)             
                 || (string.IsNullOrEmpty(textBox1.Text) && string.IsNullOrWhiteSpace(textBox1.Text)))
            {

                if (reg_password.Text == textBox1.Text)
                {
                    cmd.CommandText = "insert into [log_table] (login, password, position) values (@login, @password, @position)"; // ищем в таблице БД такие логин и пароль

                    cmd.Parameters.Add("@login", System.Data.DbType.String).Value = reg_login.Text; // подставляем в запрос параметры
                    cmd.Parameters.Add("@password", System.Data.DbType.String).Value = reg_password.Text;
                    cmd.Parameters.Add("@position", System.Data.DbType.String).Value = reg_positions.Text;

                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Пользователь успешно добавлен!");
                        reg_login.Text = "";
                        reg_password.Text = "";
                        textBox1.Text = "";


                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Ошибка! \n\nТакой пользователь уже существует!");
                    }
                }
                else
                {
                    MessageBox.Show("Пароли не совпадают!");
                    reg_password.Text = "";
                    textBox1.Text = "";
                }
            }
            else {
                MessageBox.Show("Заполните все данные!");
            }

            glob.StopSQLite();
        }
    }
}
