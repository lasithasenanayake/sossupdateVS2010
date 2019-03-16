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
using System.Configuration;
using sossProcessors;

namespace sossupdate
{
    public partial class Form1 : Form
    {
        private ProductOptionValueContract[] rpov;
        private DataTable dtOnlineData = new DataTable();
        private string URI = "";
        private DataSet DsMappings;
        private FileLocker flMapping = new FileLocker("mapping");
        private ShopperzConnector shopperzcon;
        public Form1()
        {
            URI = System.Configuration.ConfigurationManager.AppSettings["URI"];
            shopperzcon = new ShopperzConnector(URI);
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'oNLINEDBDataSet.ITEM' table. You can move, or remove it, as needed.
            //this.iTEMTableAdapter.Fill(this.oNLINEDBDataSet.ITEM);
            listView1.Items.Clear();
            if (System.IO.File.Exists("data.xml")){
                this.iTEMTableAdapter.Fill(this.oNLINEDBDataSet.ITEM);
                
                DataSet ds = new DataSet();
                ds.ReadXml("data.xml");
                DsMappings = new DataSet();
                DsMappings.ReadXml("mappings.xml");
                foreach (DataRow dr in DsMappings.Tables[0].Rows)
                {
                    DataRow[] drs =oNLINEDBDataSet.ITEM.Select("M5ITCD='" + dr["M5ITCD"] + "'");
                   
                    if (drs.Length != 0)
                    {
                         drs[0]["OptionID"]=dr["OptionID"];
                         //drs[0]["ProductID"]=dr["ProductID"];
                    }
                    if (drs.Length > 1) {
                        Console.WriteLine(dr["M5ITCD"].ToString());
                    }
                    //DataView dv = new DataView(oNLINEDBDataSet.ITEM, "M5ITCD='" + dr["M5ITCD"] + "'", "M5ITCD Desc", DataViewRowState.CurrentRows).;
                }
                dataGridView1.DataSource = oNLINEDBDataSet.ITEM;
                updatedata(oNLINEDBDataSet.ITEM);
               

            }else{
                this.iTEMTableAdapter.Fill(this.oNLINEDBDataSet.ITEM);
                updatedata(this.oNLINEDBDataSet.ITEM);
                dataGridView1.DataSource = oNLINEDBDataSet.ITEM;
                //oNLINEDBDataSet.WriteXml("data.xml");
            }

            //(dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("Field = '{0}'", textBox1.Text);
            
        }

        


        private ONLINEDBDataSet.ITEMDataTable updatedata(ONLINEDBDataSet.ITEMDataTable dt)
        {
            //ONLINEDBDataSet.ITEMDataTable dtnew = new ONLINEDBDataSet.ITEMDataTable();
            UpdateOnlineData();
            

            //dataGridView1.
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["OptionID"] != DBNull.Value)
                {
                    //int st = Convert.ToInt16(dr["ProductID"]);
                    int oid = 0;// dr["OptionID"] == DBNull.Value ? 0 : );
                    Int32.TryParse((dr["OptionID"] == DBNull.Value ? "0" : dr["OptionID"].ToString()), out oid);
                    
                    //int oid = Convert.ToInt32(dr["OptionID"]==DBNull.Value?"0":dr["OptionID"]);
                    //return dt;
                    //prlist.Select
                    var querypritems = from pritems in rpov.ToList()
                                       where  pritems.option_value_id == oid
                                       select pritems;
                    if (querypritems.ToList().Count != 0)
                    {
                        dr["responce"] = querypritems.ToList()[0].model + " " + querypritems.ToList()[0].optionname;
                        dr["QtyOnWeb"] = querypritems.ToList()[0].optqty;
                        //dr["OptionID"] = querypritems.ToList()[0].option_value_id;
                        dr["ProductID"] = querypritems.ToList()[0].product_id;
                    }
                    else
                    {
                        dr["responce"] = "Error";
                        dr["QtyOnWeb"] = 0;
                    }
                }
                else {
                    //dr["responce"] = "Not Mapped";
                }
            }

            return dt;
        }

        private void UpdateOnlineData()
        {
            
            dtOnlineData = shopperzcon.UpdateOnlineData(DsMappings);
            dataGridView2.DataSource = dtOnlineData;
            rpov = shopperzcon.GetOnlineProduct();
        }

        

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            btnUpdate.Enabled=false;
            try
            {
                while (!flMapping.Lock())
                {

                }

                DataTable dtModified = oNLINEDBDataSet.ITEM.GetChanges(DataRowState.Modified);
                //DataTable dtAdded = oNLINEDBDataSet.ITEM.GetChanges(DataRowState.Added);
                if (!System.IO.File.Exists("mappings.xml"))
                {
                    DataTable dtMappingData = new DataTable();
                    dtMappingData.Columns.Add("OptionID");
                    dtMappingData.Columns.Add("M5ITCD");
                    DsMappings = new DataSet();
                    DsMappings.Tables.Add(dtMappingData);
                }
                else
                {
                    DsMappings = new DataSet();
                    DsMappings.ReadXml("mappings.xml");
                }

                foreach (DataRow dr in dtModified.Rows)
                {
                    DataRow[] drs = DsMappings.Tables[0].Select("M5ITCD ='" + dr["M5ITCD"] + "'");
                    if (drs.Length != 0)
                    {
                        if (dr["OptionID"] != DBNull.Value)
                        {
                            drs[0]["OptionID"] = dr["OptionID"];
                        }
                        else {
                            DsMappings.Tables[0].Rows.Remove(drs[0]);
                        }
                    }
                    else
                    {
                        DsMappings.Tables[0].Rows.Add(dr["OptionID"], dr["M5ITCD"]);
                    }
                }



                DsMappings.WriteXml("mappings.xml");
                oNLINEDBDataSet.WriteXml("data.xml");
                
                flMapping.Release();
                UpdateOnlineData();
                MessageBox.Show("Mapping Has been saved.", "Online Mapper", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex) {
                flMapping.Release();
                MessageBox.Show(ex.Message, "Online Mapper Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }finally{
                //flMapping.Release();
                btnUpdate.Enabled=true;
            }
            
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

        private void updateonlineqty() {
            timer1.Enabled = false;
            try
            {
                this.iTEMTableAdapter.Fill(this.oNLINEDBDataSet.ITEM);
                DsMappings = new DataSet();
                DsMappings.ReadXml("mappings.xml");
                foreach (DataRow dr in DsMappings.Tables[0].Rows)
                {
                    DataRow[] drs = oNLINEDBDataSet.ITEM.Select("M5ITCD='" + dr["M5ITCD"] + "'");

                    if (drs.Length != 0)
                    {
                        drs[0]["OptionID"] = dr["OptionID"];
                        //drs[0]["ProductID"]=dr["ProductID"];
                    }
                    if (drs.Length > 1)
                    {
                        Console.WriteLine(dr["M5ITCD"].ToString());
                    }
                    //DataView dv = new DataView(oNLINEDBDataSet.ITEM, "M5ITCD='" + dr["M5ITCD"] + "'", "M5ITCD Desc", DataViewRowState.CurrentRows).;
                }
                var items = shopperzcon.UpdateOnlineQty(oNLINEDBDataSet);
                if (items.Count != 0)
                {
                    string status = shopperzcon.SaveQtyOnline(items.ToArray());
                    foreach (var line in items)
                    {
                        string[] row = { DateTime.Now.ToString(), line.model.ToString(), line.optqty.ToString(), status };
                        listView1.Items.Add(new ListViewItem(row));
                    }
                }
            }catch(Exception ex)
            {
                string[] row = { DateTime.Now.ToString(), "Error", "0", ex.Message };
                listView1.Items.Add(new ListViewItem(row));
            }
            timer1.Enabled = true;
        }



        private void btnsyncstart_Click(object sender, EventArgs e)
        {
            //timer1.Enabled = true;
            listView1.Visible = true;
            timer1.Interval=Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToInt32(numericUpDown1.Value)).TotalMilliseconds);
            timer1.Enabled = true;
            btnsyncstop.Enabled = true;
            btnsyncstart.Enabled = false;
            
        }

        private void btnsyncstop_Click(object sender, EventArgs e)
        {
            //timer1.Enabled = false;
            listView1.Visible = false;
            timer1.Enabled = false;
            btnsyncstop.Enabled = false;
            btnsyncstart.Enabled = true;
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "OptionID" )
            {

                //int oid = Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == DBNull.Value ? 0 : dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                //return dt;
                //prlist.Select
                try
                {
                    //int st = Convert.ToInt16(dataGridView1["ProductID", e.RowIndex].Value == DBNull.Value ? 0 : dataGridView1["ProductID", e.RowIndex].Value);
                    int oid = Convert.ToInt32(dataGridView1["OptionID", e.RowIndex].Value == DBNull.Value ? 0 : dataGridView1["OptionID", e.RowIndex].Value);
                    //return dt;
                    //prlist.Select
                    var querypritems = from pritems in rpov.ToList()
                                       where pritems.option_value_id == oid
                                       select pritems;

                    if (querypritems.ToList().Count != 0)
                    {
                        dataGridView1["responce", e.RowIndex].Value = Convert.ToString(querypritems.ToList()[0].model + " " + querypritems.ToList()[0].optionname);
                        dataGridView1["ProductID", e.RowIndex].Value = querypritems.ToList()[0].product_id;
                        dataGridView1["QtyOnWeb", e.RowIndex].Value = querypritems.ToList()[0].optqty;



                    }
                    else
                    {
                        dataGridView1["responce", e.RowIndex].Value = "Error";
                        dataGridView1["ProductID", e.RowIndex].Value = 0;
                        dataGridView1["QtyOnWeb", e.RowIndex].Value = "0";
                    }
                }
                catch (Exception ex)
                {
                    dataGridView1["responce", e.RowIndex].Value = "Error "+ ex.Message;
                }
            }
           
        }

        private void btnopennilsonlinestore_Click(object sender, EventArgs e)
        {
            OpenOnlinestore oform = new OpenOnlinestore();
            oform.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            updateonlineqty();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!btnsyncstart.Enabled)
            {
                notifyIcon1.Visible = true;
                notifyIcon1.Icon = this.Icon;
                this.Visible = false;
                e.Cancel = true;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Visible = true;
            notifyIcon1.Visible = false;
        }
    }
}
