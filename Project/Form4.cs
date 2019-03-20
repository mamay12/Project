using System;
using System.Data.SQLite;
using System.Data;
using System.Windows.Forms;

namespace Project
{
    public partial class Form4 : Form
    {
        globalVar glob = new globalVar();

        public Form4()
        {
            InitializeComponent();
        }

       // private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;
        private SQLiteDataAdapter DB;
        private DataSet DS = new DataSet();
        private DataTable DT = new DataTable();

        private void Form4_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e) // подтверждение выхода из формы
        {
            DialogResult result;

            result = MessageBox.Show("Вы уверены, что хотите выйти?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                //glob.StopSQLite();
                this.Close();
            }
            e.Cancel = true;


        }
        private void ExecuteQuery(string txtQuery) {
            glob.StartSQLite();
            sql_cmd = globalVar.db.CreateCommand();
            sql_cmd.CommandText = txtQuery;
            try { sql_cmd.ExecuteNonQuery(); } catch (Exception) {
                MessageBox.Show("Данное действие недоступно.");
            } 
            glob.StopSQLite();
        }

        private void LoadData() {
            glob.StartSQLite();
            sql_cmd = globalVar.db.CreateCommand();
            string CommandText = "select * from log_table";
            DB = new SQLiteDataAdapter(CommandText, globalVar.db);
            DS.Reset();
            DB.Fill(DS);
            DT = DS.Tables[0];
            grid.DataSource = DT;
            glob.StopSQLite();
        }

        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id_box.Text = grid.SelectedRows[0].Cells[0].Value.ToString();
                log_box.Text = grid.SelectedRows[0].Cells[1].Value.ToString();
                password_box.Text = grid.SelectedRows[0].Cells[2].Value.ToString();
            }
            catch (Exception) { MessageBox.Show("Упс! Что-то пошло не так..."); }           

        }

        private void del_button_Click(object sender, EventArgs e)
        {
            string txtQuery = "delete from log_table where ID =" + id_box.Text;
            ExecuteQuery(txtQuery);
            LoadData();
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void update_button_Click(object sender, EventArgs e)
        {
            string txtQuery = "update log_table set login = '" + log_box.Text + "', password = '" + password_box.Text + "' where id = '" + id_box.Text + "'";
            ExecuteQuery(txtQuery);
            LoadData();
        }
    }
}
