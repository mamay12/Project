﻿using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Project
{
    public partial class Form1 : Form
    {
        //public SQLiteConnection db; //строка подключения       
        globalVar glob = new globalVar();
        int count = 0; //счётчик неудачных попыток входа
        int time = 20; //счётчик времени

        public Form1()
        {
            Program.f1 = this;
            InitializeComponent();           
        }
        
        private void Form1_FormClosing(object sender, FormClosingEventArgs e) // подтверждения выхода
        {      
            DialogResult result;

            result = MessageBox.Show("Вы уверены, что хотите выйти?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
            e.Cancel = true;
        }

        private void Enter_but_Click(object sender, EventArgs e)
        {
            string log = Login.Text.ToUpper();
            string pass = Password.Text.ToUpper();

            if (Login.Text != "" && Password.Text != "")
            {
                SQLiteCommand cmd = globalVar.db.CreateCommand();

                cmd.CommandText = "select * from log_table where login like @login and password like @password"; // ищем в таблице БД такие логин и пароль

                cmd.Parameters.Add("@login", System.Data.DbType.String).Value = log; // подставляем в запрос параметры
                cmd.Parameters.Add("@password", System.Data.DbType.String).Value = pass;

                SQLiteDataReader SQL = cmd.ExecuteReader(); // выполняем запрос

                if (SQL.HasRows) //если такая строка нашлась ...
                {                   
                    SQLiteCommand getcmd = globalVar.db.CreateCommand();
                    getcmd.CommandText = "select position from log_table where login like @login and password like @password"; //запрос на получение уровня доступа

                    getcmd.Parameters.Add("@login", System.Data.DbType.String).Value = log; //подставляем параметры
                    getcmd.Parameters.Add("@password", System.Data.DbType.String).Value = pass;

                    string pos = (string)getcmd.ExecuteScalar(); //здесь лежит позиция входящего человека
                    SQL.Close();

                    switch (pos){
                        case "Director":
                            this.Hide();
                            AdminForm admForm = new AdminForm();
                            admForm.Closed += (s, args) => this.Close();
                            admForm.Show();
                            break;

                        case "Manager":
                            this.Hide();
                            ManagerForm mngForm = new ManagerForm();
                            mngForm.Closed += (s, args) => this.Close();
                            mngForm.Show();
                            break;

                        case "Seller":
                            this.Hide();
                            SellerForm sellForm = new SellerForm();
                            sellForm.Closed += (s, args) => this.Close();
                            sellForm.Show();
                            break;
                    }  
                }
                else // если пароль или логин неправильный
                {
                    count++;
                    MessageBox.Show("Неправильный логин или пароль! Попробуйте заново, осталось " + (3 - count) + " попыток!");

                    if ((3 - count) == 0)
                    {
                        MessageBox.Show("Временная блокировка, ожидайте 20 секунд."); 
                        timer1.Start(); //вызываем таймер
                    }
                    
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 1000; // = 1 секунда

            Enter_but.Enabled = false; //выключаем активность кнопки
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

        private void Form1_Load(object sender, EventArgs e)
        {
            glob.StartSQLite();
        }
    }
}
