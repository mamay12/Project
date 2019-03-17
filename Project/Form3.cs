using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Project
{
    public partial class Form3 : Form
    {
        public SQLiteConnection db; //строка подключения

        public Form3()
        {
            Program.f3 = this; //указатель на Form3 (нужен для обращения к элементу этой формы из других форм)
            InitializeComponent();
        }      
      
      
        private void reg_button_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e) // подтверждение выхода из формы
        {
            DialogResult result;

            result = MessageBox.Show("Вы уверены, что хотите выйти?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
            db.Close();
        }
    }
}
