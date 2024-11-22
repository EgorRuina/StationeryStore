using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StationeryStore
{
    public partial class MainForm : Form
    {
        private string _connStr;

        public MainForm(string connStr)
        {
            InitializeComponent();
            _connStr = connStr;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
