using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace sossupdate
{
    public partial class OpenOnlinestore : Form
    {
        DataTable dtOnlineData = new DataTable();
        public OpenOnlinestore(DataTable dt)
        {
            InitializeComponent();
            dtOnlineData = dt;
            
        }

        private void OpenOnlinestore_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dtOnlineData;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                
                DataView dv2 = new DataView(dtOnlineData, "model like '" + textBox1.Text + "%'", "model Desc", DataViewRowState.CurrentRows);
                dataGridView1.DataSource = dv2;
            }
            else
            {
                
                dataGridView1.DataSource = dtOnlineData;
            }
        }
    }
}
