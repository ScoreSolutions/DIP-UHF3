using System;
//using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;

namespace DIP_Handheld
{
    public static class FunctionENG
    {
        public static DataTable dtLost = new DataTable();

        public static string GetAppNo(string AppNo) {
            string ret = "";
            //try {
            //    string url1 = "http://192.168.1.46/DIPUHF3_WebService/frmHandheldWebService.aspx?MethodName=GetTagListByAppNo&AppNo=" + AppNo;

            //    System.Net.WebRequest webReq;
            //    System.Net.WebResponse webRes;
            //    webReq = System.Net.WebRequest.Create(url1);
            //    webReq.Timeout = 10000;

            //    webRes = webReq.GetResponse();

            //    StreamReader strm = new StreamReader(webRes.GetResponseStream(), System.Text.UnicodeEncoding.Default);
            //    if (strm.Peek() != -1){
            //        ret = strm.ReadLine();
            //    }
            //}
            //catch (Exception ex) {
            //    ret = "";
            //}

            return ret;
        }

        public static bool GetTagFileLost(string AppNo) {
            bool ret = false;
            try { 
                //if (File.Exists(@"\My Documents\DIPFileLost.txt"))
                if(dtLost.Rows.Count>0)
                {
                    bool chkTag = false;
                    dtLost.DefaultView.RowFilter = "app_no='" + AppNo + "'";
                    if (dtLost.DefaultView.Count > 0)
                    {
                        if (File.Exists(@"\My Documents\DIPFileDiscover.txt") == true)
                        {
                            using (var fd = new StreamReader(@"\My Documents\DIPFileDiscover.txt"))
                            {
                                string fdTag;
                                while ((fdTag = fd.ReadLine()) != null)
                                {
                                    if (fdTag != AppNo)
                                    {
                                        chkTag = true;
                                    }
                                    else {
                                        chkTag = false;
                                        break;
                                    }
                                }
                            }
                        }
                        else
                        {
                            chkTag = true;
                        }
                    }
                    dtLost.DefaultView.RowFilter = "";


                    if (chkTag == true)
                    {
                        try
                        {
                            StreamWriter stw = new StreamWriter(@"\My Documents\DIPFileDiscover.txt", true);
                            stw.WriteLine(AppNo);
                            stw.Close();
                            stw.Dispose();
                            ret = true;
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }
            }
            catch (Exception ex) {
                ret = false;
            }

            return ret;
        }
    }
}
