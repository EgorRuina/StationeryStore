using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace StationeryStore
{
    public partial class DbConnection : Form
    {
        public DbConnection()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connStr = textBox1.Text;

            if (string.IsNullOrWhiteSpace(connStr))
            {
                MessageBox.Show("Please enter valid connection string.",
                    "Input Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connStr)) 
            {
                try
                {
                    conn.Open();

                    SqlConnectionStringBuilder builder =
                        new SqlConnectionStringBuilder(connStr);
                    string dbName = builder.InitialCatalog;

                    MessageBox.Show($"Connected to: {dbName}", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    MainForm mainForm = new MainForm(connStr);
                    mainForm.Show();
                    this.Hide();
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show($"SQL Error: {sqlEx.Message}",
                        "Connection Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                catch (Exception ex) 
                {
                    MessageBox.Show($"An error occured: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
