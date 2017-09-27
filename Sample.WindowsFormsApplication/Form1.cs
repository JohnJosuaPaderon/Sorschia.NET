using Sorschia;
using Sorschia.Data;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Sample.WindowsFormsApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var dbHelper = SorschiaApp.ResolveService<IDbHelper<SqlConnection, SqlTransaction, SqlCommand, IQueryParameter>>();
        }
    }
}
