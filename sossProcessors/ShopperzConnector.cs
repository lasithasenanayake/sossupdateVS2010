using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Data;
using System.Runtime.Serialization.Json;


namespace sossProcessors
{
    public class ShopperzConnector
    {
        private string URI = "";
        private ProductOptionValueContract[] rpov; 
        public ShopperzConnector(string uri) {
            URI = uri;        
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

        public string SaveQtyOnline(ProductOptionValueContract[] povs) {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(URI + "productsUpdate");
                string res = "";
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = "{\"user\":\"test\"," +
                                  "\"password\":\"bla\"}";
                    MemoryStream stream1 = new MemoryStream();
                    var serializer = new DataContractJsonSerializer(typeof(ProductOptionValueContract[]));
                    serializer.WriteObject(stream1, povs);
                    stream1.Position = 0;
                    StreamReader sr = new StreamReader(stream1);
                    json = sr.ReadToEnd();
                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    res = streamReader.ReadToEnd();

                }

                return res;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public DataTable UpdateOnlineData(DataSet DsMappings)
        {
            var res = GET(URI + "products");
            rpov = FromJSON<ProductOptionValueContract[]>(res);
            DataTable dtOnlineData = new DataTable();
            dtOnlineData.Columns.Add("option_value_id");
            dtOnlineData.Columns.Add("product_id");
            dtOnlineData.Columns.Add("model");
            dtOnlineData.Columns.Add("optionname");
            dtOnlineData.Columns.Add("stockqty");
            dtOnlineData.Columns.Add("optqty");
            dtOnlineData.Columns.Add("option_id");

            foreach (ProductOptionValueContract pv in rpov)
            {
                if (DsMappings != null)
                {
                    DataRow[] drs = DsMappings.Tables[0].Select("OptionID ='" + pv.option_value_id + "'");
                    if (drs.Length != 0)
                    {
                        continue; 
                    }
                }

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

            
            return dtOnlineData;
        }

        public List<ProductOptionValueContract> UpdateOnlineQty(DataSet DsLocalData)
        {
            var res = GET(URI + "products");
            rpov = FromJSON<ProductOptionValueContract[]>(res);
            List<ProductOptionValueContract> newpvs = new List<ProductOptionValueContract>();

            foreach (ProductOptionValueContract pv in rpov)
            {
                
                  DataRow[] drs = DsLocalData.Tables[0].Select("OptionID ='" + pv.option_value_id + "'");
                  if (drs.Length != 0)
                  {
                    if (Convert.ToInt32(drs[0]["QTYINHAND"]) != pv.optqty) {
                        newpvs.Add( new ProductOptionValueContract {model=pv.model,optionname=pv.optionname,option_id=pv.option_id,option_value_id=pv.option_value_id,optqty= Convert.ToInt32(drs[0]["QTYINHAND"]),product_id=pv.product_id,product_option_id=pv.product_option_id,stockqty= Convert.ToInt32(drs[0]["QTYINHAND"]) });

                    }                                       
                  }

            }
            return newpvs;
        }

       public ProductOptionValueContract[] GetOnlineProduct() {
            //var res = GET(URI + "products");
            //ProductOptionValueContract[] rpov = FromJSON<ProductOptionValueContract[]>(res);

            return rpov;
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
    }
}
