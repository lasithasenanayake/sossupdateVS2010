using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sossProcessors;

namespace sossupdate
{
    public partial class OpenOnlinestore : Form
    {
        DataTable dtOnlineData = new DataTable();
        private string URI = "";

        public OpenOnlinestore(DataTable dt)
        {
            InitializeComponent();
            dtOnlineData = dt;
            
        }

        public OpenOnlinestore()
        {
            

            InitializeComponent();
            URI = System.Configuration.ConfigurationManager.AppSettings["URI"];
            ShopperzConnector shopperzcon = new ShopperzConnector(URI);
            dtOnlineData = shopperzcon.UpdateOnlineData(null);
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
