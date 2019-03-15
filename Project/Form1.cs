using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Project
{
    public partial class Form1 : Form
    {
        public static List<string> login = new List<string>() { "admin" };
        public static List<string> password = new List<string> { "123qwe" };
        public static List<string> position = new List<string> { "Director" };

        int count = 0;
        int time = 20;

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result;

            result = MessageBox.Show("Вы уверены, что хотите выйти?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void Enter_but_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < login.Count; i++)
            {
                if ((login[i] == Login.Text) && (password[i] == Password.Text))
                {
                    MessageBox.Show("Congratulations! You are entered!");
                }
                else
                {
                    count++;
                    MessageBox.Show("Неправильный логин или пароль! Попробуйте заново, осталось " + (3 - count) + " попыток!");

                    if ((3 - count) == 0)
                    {
                        MessageBox.Show("Временная блокировка, ожидайте 20 секунд.");
                        timer1.Start();
                    }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 1000;

            Enter_but.Enabled = false;
            Enter_but.Text = "Осталось времени (" + time + ") секунд";
            time = time - 1;

            if (time == -1)
            {
                timer1.Stop();
                Enter_but.Text = "Войти";
                Enter_but.Enabled = true;
                count = 0;
            }


        }

        private void reg_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
