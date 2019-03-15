using System;
using System.Windows.Forms;

namespace Project
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result;

            result = MessageBox.Show("Вы уверены, что хотите выйти?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void save_reg_Click(object sender, EventArgs e)
        {
            Form1.login.Add(reg_login.Text.ToString());
            Form1.password.Add(reg_password.Text.ToString());
            Form1.position.Add(reg_positions.Items.ToString());
        }

        private void back_to_start_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

    }
}
