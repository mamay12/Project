using System;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace Project
{
    public partial class Form2 : Form
    {

        globalVar glob = new globalVar();
     //   Form2 frm2 = new Form2();

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e) // подтверждение выхода из формы
        {
            DialogResult result;

            result = MessageBox.Show("Вы уверены, что хотите выйти?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                this.Hide();
            }          
        }

        private void save_reg_Click(object sender, EventArgs e)
        {
            glob.StartSQLite();
            SQLiteCommand cmd = globalVar.db.CreateCommand();

            cmd.CommandText = "insert into [log_table] (login, password, position) values (@login, @password, @position)"; // ищем в таблице БД такие логин и пароль

            cmd.Parameters.Add("@login", System.Data.DbType.String).Value = reg_login.Text; // подставляем в запрос параметры
            cmd.Parameters.Add("@password", System.Data.DbType.String).Value = reg_password.Text;
            cmd.Parameters.Add("@position", System.Data.DbType.String).Value = reg_positions.Text;

            try {
                cmd.ExecuteNonQuery();
                save_reg.Text = "Регистрация прошла успешно!";
                save_reg.BackColor = Color.Green;
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка! \n\nТакой пользователь уже существует!");
            }
            glob.StopSQLite();
        }
      

        /* private void back_to_start_Click(object sender, EventArgs e)
         {
             this.Hide();
         }*/

    }
}
