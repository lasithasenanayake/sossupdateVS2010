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
