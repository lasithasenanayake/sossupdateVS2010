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
        private ProductOptionValueContract[] rpov;
        private DataTable dtOnlineData = new DataTable();
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
                this.iTEMTableAdapter.Fill(this.oNLINEDBDataSet.ITEM);
                DataSet ds = new DataSet();
                ds.ReadXml("data.xml");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    DataRow[] drs =oNLINEDBDataSet.ITEM.Select("M5ITCD='" + dr["M5ITCD"] + "'");
                    if (drs.Length != 0)
                    {
                         drs[0]["OptionID"]=dr["OptionID"];
                         drs[0]["ProductID"]=dr["ProductID"];
                    }
                    //DataView dv = new DataView(oNLINEDBDataSet.ITEM, "M5ITCD='" + dr["M5ITCD"] + "'", "M5ITCD Desc", DataViewRowState.CurrentRows).;
                }
                dataGridView1.DataSource = oNLINEDBDataSet.ITEM;
                updatedata(oNLINEDBDataSet.ITEM);
               

            }else{
                this.iTEMTableAdapter.Fill(this.oNLINEDBDataSet.ITEM);
                updatedata(this.oNLINEDBDataSet.ITEM);
                dataGridView1.DataSource = oNLINEDBDataSet.ITEM;
                oNLINEDBDataSet.WriteXml("data.xml");
            }

            //(dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("Field = '{0}'", textBox1.Text);
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
           
            //timer1.Enabled = true;
        }


        private ONLINEDBDataSet.ITEMDataTable updatedata(ONLINEDBDataSet.ITEMDataTable dt)
        {
            //ONLINEDBDataSet.ITEMDataTable dtnew = new ONLINEDBDataSet.ITEMDataTable();
            UpdateOnlineData();
            

            //dataGridView1.
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["ProductID"] != DBNull.Value)
                {
                    int st = Convert.ToInt16(dr["ProductID"]); 
                    int oid = Convert.ToInt16(dr["OptionID"]);  
                  //return dt;
                    //prlist.Select
                    var querypritems = from pritems in rpov.ToList()
                                       where pritems.product_id == st && pritems.option_value_id==oid
                                       select pritems;
                    if (querypritems.ToList().Count != 0)
                    {
                        dr["responce"] = querypritems.ToList()[0].model + " " + querypritems.ToList()[0].optionname;
                        dr["QtyOnWeb"] = querypritems.ToList()[0].optqty;
                        //dr["OptionID"] = querypritems.ToList()[0].option_value_id;
                        //dr["ProductID"] = querypritems.ToList()[0].option_value_id;
                    }
                    else {
                        dr["responce"] = "Error";
                        dr["QtyOnWeb"] = 0;
                    }
                }
            }

            return dt;
        }

        private void UpdateOnlineData()
        {
            var res = GET("http://shopperz.lk/ShopperzInventry/products");
            rpov = FromJSON<ProductOptionValueContract[]>(res);
            dtOnlineData = new DataTable();
            dtOnlineData.Columns.Add("product_id");
            dtOnlineData.Columns.Add("option_value_id");
            dtOnlineData.Columns.Add("model");
            dtOnlineData.Columns.Add("optionname"); 
            dtOnlineData.Columns.Add("stockqty");
            dtOnlineData.Columns.Add("optqty");
            dtOnlineData.Columns.Add("option_id");

            foreach (ProductOptionValueContract pv in rpov)
            {
                DataRow Dr = dtOnlineData.NewRow();
                Dr["product_id"] = pv.product_id;
                Dr["option_value_id"] = pv.option_value_id;
                Dr["option_id"] = pv.option_id;
                Dr["model"] = pv.model;
                Dr["optionname"] = pv.optionname;
                Dr["stockqty"] = pv.stockqty;
                Dr["optqty"] = pv.optqty;
                dtOnlineData.Rows.Add(Dr);
            }

            dataGridView2.DataSource = dtOnlineData;
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                DataView dv = new DataView(oNLINEDBDataSet.ITEM, "M5ITCD like '" + textBox1.Text + "%'", "M5ITCD Desc", DataViewRowState.CurrentRows);
                dataGridView1.DataSource = dv;
                DataView dv2 = new DataView(dtOnlineData, "model like '" + textBox1.Text + "%'", "model Desc", DataViewRowState.CurrentRows);
                dataGridView2.DataSource = dv2;
            }
            else
            {
                dataGridView1.DataSource = oNLINEDBDataSet.ITEM;
                dataGridView2.DataSource = dtOnlineData;
            }
        }
    }
}
