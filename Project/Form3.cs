using System;
using System.Diagnostics;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Project
{
    public partial class Form3 : Form
    {
        globalVar glob = new globalVar();

        public Form3()
        {
            Program.f3 = this; //указатель на Form3 (нужен для обращения к элементу этой формы из других форм)            
            InitializeComponent();
        }
        
        private void Form3_FormClosing(object sender, FormClosingEventArgs e) // подтверждение выхода из формы
        {
            DialogResult result;

            result = MessageBox.Show("Вы уверены, что хотите выйти?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }

            Environment.Exit(1);
        }

        private void reg_button_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void del_change_button_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
        }
    }
}
