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
    public partial class MainForm : Form
    {
        private string _connStr;
        private Dictionary<string, Action> _commands;

        public MainForm(string connStr)
        {
            InitializeComponent();
            _connStr = connStr;

            SqlConnectionStringBuilder builder =
                new SqlConnectionStringBuilder(connStr);

            richTextBox1.Text = $"Connected to {builder.InitialCatalog}\n\n";

            InitCommands();
        }

        private void InitCommands()
        {
            _commands = new Dictionary<string, Action>
                (StringComparer.OrdinalIgnoreCase)
            {
                { "/clear", Clear },
                { "/products.info", LoadProductsInfo }
                //{ "/sales.info", LoadSalesInfo } will add rest of the commands later

            };
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e) //All commands goes here
        {

        }

        private void button4_Click(object sender, EventArgs e) //To Run commands
        {
            string command = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(command))
            {
                MessageBox.Show("Please enter a command!", "Empty Command Error!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            ExecComm(command);
        }

        private void ExecComm(string command)
        {
            if (_commands.ContainsKey(command)) 
            {
                _commands[command].Invoke();
            }
            else
            {
                richTextBox1.Text = "Unknown command!\n";
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e) //All info shows here
        {
            
        }

        private void button1_Click(object sender, EventArgs e) //To get app info (ver. and other stuff)
        {
            MessageBox.Show("App version: 0.1 beta\n" +
                "Changelog: " +
                "\n\t >Added Main Form to work with DB", " App Info",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e) //Check available commands
        {

        }

        private void button3_Click(object sender, EventArgs e) //get back to connection wizard app
        {

        }

        private void LoadProductsInfo()
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                try
                {
                    conn.Open();
                    SqlCommand sqlCommand = new SqlCommand(
                        "SELECT * FROM products", conn);
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    richTextBox1.Clear();

                    foreach(DataRow dataRow in dataTable.Rows)
                    {
                        foreach(var item in dataRow.ItemArray)
                        {
                            richTextBox1.AppendText(item.ToString() + "\t");
                        }
                        richTextBox1.AppendText(Environment.NewLine);
                    }
                }
                catch(Exception ex)
                {
                    richTextBox1.Text = $"An error occurred while loading products: " +
                        $"{ex.Message}";
                }
            }
        }

        private void Clear()
        {
            try
            {
                richTextBox1.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error has occured: {ex.Message}", 
                    "Unknown error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
