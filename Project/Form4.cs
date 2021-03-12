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

        private SQLiteCommand sql_cmd;
        private SQLiteDataAdapter DB;
        private DataSet DS = new DataSet();
        private DataTable DT = new DataTable();

        private void Form4_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void ExecuteQuery(string txtQuery) {
            
            sql_cmd = globalVar.db.CreateCommand();
            sql_cmd.CommandText = txtQuery;
            try { sql_cmd.ExecuteNonQuery(); } catch (Exception) {
                MessageBox.Show("Данное действие недоступно.");
            } 
            
        }

        private void LoadData() {
            sql_cmd = globalVar.db.CreateCommand();
            string CommandText = "select * from log_table";
            DB = new SQLiteDataAdapter(CommandText, globalVar.db);
            DS.Reset();
            DB.Fill(DS);
            DT = DS.Tables[0];
            grid.DataSource = DT;
        }

        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id_box.Text = grid.SelectedRows[0].Cells[0].Value.ToString();
            }
            catch (Exception) { MessageBox.Show("Упс! Что-то пошло не так..."); }           

        }

        private void del_button_Click(object sender, EventArgs e)
        {
            DialogResult result;

            result = MessageBox.Show("Вы уверены, что хотите удалить пользователя?", "Да", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
     
            }
            else
            {
                string txtQuery = "delete from log_table where ID =" + id_box.Text;
                glob.StartSQLite();
                ExecuteQuery(txtQuery);
                glob.StopSQLite();
                LoadData();
            }
        }
    }
}
