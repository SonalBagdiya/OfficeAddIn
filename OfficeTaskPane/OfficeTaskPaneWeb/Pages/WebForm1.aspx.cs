using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OfficeTaskPaneWeb.Pages
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string GetData()
        {
         //   List<Assumption> lstAssumption = new List<Assumption>();
            try
            {
                var responseText = GetRequest("https://us-staging.gomercatus.com/rest/projectDetail/assumptions/12084",  //12084
                    true, "Bearer 7b78fb60-2af3-4201-8522-43974f601f7d");

                //JObject o = JObject.Parse(responseText);
                //var val = o["data"]["liteAssumptionVOs"];  //o["data"]["liteAssumptionVOs"][0]["rn"].ToString()	"SCS_Associate"	string

                //lstAssumption.Clear();

                //foreach (var str in val)
                //{
                //    Assumption obj = new Assumption();
                //    obj.assumptionId = Convert.ToInt64(str["aid"].ToString());
                //    obj.organizationId = Convert.ToInt64(str["oid"].ToString());
                //    obj.referenceName = str["rn"].ToString().Replace(str["oid"].ToString() + "_", "").Trim();
                //    obj.isOutput = Convert.ToBoolean(str["io"].ToString());
                //    obj.value = str["v"].ToString();
                //    obj.fieldType = str["ft"].ToString();
                //    lstAssumption.Add(obj);
                //}


                return responseText.ToString();
            }
            catch (Exception ex)
            {
                return "";
               // MessageBox.Show(ex.Message, "Mercatus Add-In for Microsoft Office", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        
        private static object GetRequest(string url, bool isAuthorizationHeaderRequired, string token)
        {
            try
            {
                var wreq = (HttpWebRequest)WebRequest.Create(url);
                wreq.Method = "GET";
                wreq.ServicePoint.Expect100Continue = true;
                wreq.KeepAlive = true;
                wreq.ContentType = "application/json; charset=UTF-8";
                wreq.Timeout = 120000;//2 mins
                wreq.ReadWriteTimeout = 120000;//2 mins
                //wreq.ContentLength = dataByte.Length;
                if (isAuthorizationHeaderRequired)
                {
                    wreq.PreAuthenticate = true;
                    wreq.Headers.Add("Authorization", token);
                    //wreq.Credentials = new NetworkCredential(userName: "mitesh.agrawal@synerzip.com", password: "test1234");
                }

                //if (addCookie)
                //{
                //    var strCookie = ReadFromIsolatedStorage();
                //    if (strCookie != null)
                //    {
                //        var cookie = new Cookie(strCookie[0].Trim(), strCookie[1].Trim());
                //        wreq.CookieContainer = new CookieContainer();
                //        wreq.CookieContainer.Add(new Uri(url), cookie);
                //    }
                //}

                //// Get the request stream
                //using (var postStream = wreq.GetRequestStream())
                //{
                //    postStream.Write(dataByte, 0, dataByte.Length);
                //    postStream.Flush();
                //    postStream.Close();
                //}

                using (var response = (HttpWebResponse)wreq.GetResponse())
                {
                    var responseValue = string.Empty;

                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        // ReSharper disable once FormatStringProblem
                        var message = String.Format("GET failed. Received HTTP {0}",
                            response.StatusCode + " " + response.StatusDescription);
                        throw new ApplicationException(message);
                    }

                    //var setCookie = response.Headers.GetValues("Set-Cookie");
                    //check if the set cookie header has something
                    //if (setCookie != null && setCookie.Length > 0)
                    //{
                    //    var cookie = new Cookie();
                    //    cookie.Name = setCookie[0].Substring(0, setCookie[0].IndexOf("="));
                    //    cookie.Value = setCookie[0].Substring(setCookie[0].IndexOf("=") + 1, setCookie[0].IndexOf(";") - cookie.Name.Length - 1);
                    //    WriteToIsolatedStorage(cookie);
                    //}

                    // grab the response   
                    using (var responseStream = response.GetResponseStream())
                    {
                        if (responseStream == null) return responseValue;

                        using (var reader = new StreamReader(responseStream))
                        {
                            responseValue = reader.ReadToEnd();
                        }
                    }

                    return responseValue;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}