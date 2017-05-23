using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Json;

namespace sossupdate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'oNLINEDBDataSet.ITEM' table. You can move, or remove it, as needed.
            //this.iTEMTableAdapter.Fill(this.oNLINEDBDataSet.ITEM);
            if (System.IO.File.Exists("data.xml")){
                DataSet ds = new DataSet();
                oNLINEDBDataSet.ReadXml("data.xml");
                dataGridView1.DataSource = oNLINEDBDataSet.ITEM;

            }else{
                this.iTEMTableAdapter.Fill(this.oNLINEDBDataSet.ITEM);
                updatedata(this.oNLINEDBDataSet.ITEM);
                dataGridView1.DataSource = oNLINEDBDataSet.ITEM;
                
                oNLINEDBDataSet.WriteXml("data.xml");
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
           
            //timer1.Enabled = true;
        }


        private ONLINEDBDataSet.ITEMDataTable updatedata(ONLINEDBDataSet.ITEMDataTable dt)
        {
            //ONLINEDBDataSet.ITEMDataTable dtnew = new ONLINEDBDataSet.ITEMDataTable();
            string res = GET("http://localhost:9000/data/oc_product");
            Responce<ProductContract> pr = FromJSON<Responce<ProductContract>>(res);
            List<ProductContract> prlist = pr.response.ToList<ProductContract>();
            res = GET("http://localhost:9000/data/oc_product_option_value");
            Responce<ProductOptionValueContract> rpov = FromJSON<Responce<ProductOptionValueContract>>(res);

            //dataGridView1.
            foreach (DataRow dr in dt.Rows)
            {
                string st = dr["M5ITCD"].ToString(); //return dt;
                //prlist.Select
                var querypritems = from pritems in prlist
                                           where pritems.model == st
                                           select pritems;
                if (querypritems.ToList().Count != 0)
                {
                    dr["responce"] = querypritems.ToList()[0].product_id;
                    dr["QtyOnWeb"] = querypritems.ToList()[0].qty;
                }
            }

            return dt;
        }

        private string GET(string url)
        {
            WebRequest request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                WebResponse response = request.GetResponse();
                
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    return reader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                WebResponse errorResponse = ex.Response;
                using (Stream responseStream = errorResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                    String errorText = reader.ReadToEnd();
                    // log errorText
                }
                throw;
            }
        }

        public static T FromJSON<T>(string json)
        {
            T outObj = default(T);
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            using (MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(json)))
            {
                outObj = (T)serializer.ReadObject(ms);
            }
            return outObj;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                MessageBox.Show("SSS");
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            oNLINEDBDataSet.WriteXml("data.xml");
        }
    }
}
