using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Web.SessionState;
using System.Drawing;
using System.Collections;
using System.Runtime.InteropServices;
using System.Runtime;
using System.Threading;


namespace WebCWBasicClass.Log
{
    public class ErrorLog : System.Web.UI.Page
    {

        //public static void LogError(Exception ex)
        //{
        //    string msg = ex.Message + Environment.NewLine + ex.StackTrace;

        //    if (ex.InnerException != null)
        //        msg += Environment.NewLine + "Inner: " + ex.InnerException.Message + Environment.NewLine + ex.InnerException.StackTrace;

        //    LogError(msg);
        //}
        public static void LogError(Exception ex, string filpath)
        {
            string msg = ex.Message + Environment.NewLine + ex.StackTrace;

            if (ex.InnerException != null)
                msg += Environment.NewLine + "Inner: " + ex.InnerException.Message + Environment.NewLine + ex.InnerException.StackTrace;

            LogError(msg, filpath);
        }

        //public static void LogError(string readme)
        //{
        //    string strTmp = "";
        //    string FilePath = Path.Combine(ConfigurationManager.AppSettings["logDirectory"], "Log");
        //    // string FilePath = @"C:\Program Files (x86)\APEX\SDP\OmniVox3D\AM\";

        //    strTmp = "MultiWebCallBackLog" + "_" + DateTime.Now.Year.ToString() + "\\" + DateTime.Now.Month.ToString() + "\\" + DateTime.Now.Day.ToString() + "\\";
        //    FilePath += strTmp;


        //    lock ("LOG")
        //    {
        //        lock ("LOG")
        //        {
        //            if (!Directory.Exists(FilePath))
        //            {
        //                Directory.CreateDirectory(FilePath);
        //            }

        //            FilePath += "WebCallBack_log_";
        //            FilePath += DateTime.Now.Year.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Hour.ToString() + ".txt";


        //            using (TextWriter myWriter = new StreamWriter(FilePath, true))
        //            {
        //                TextWriter.Synchronized(myWriter).WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " " + readme);
        //            }
        //        }
        //    }
        //}
        public static string MapPath(string strPath)
        {
            if (HttpContext.Current != null)
            {
                return HttpContext.Current.Server.MapPath(strPath);
            }
            else //if not web System invoke
            {
                strPath = "";
                strPath = strPath.Replace("/", "\\");
                if (strPath.StartsWith("\\"))
                {
                    //strPath = strPath.Substring(strPath.IndexOf('\\', 1)).TrimStart('\\');
                    strPath = strPath.TrimStart('\\');
                }
                return System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, strPath);
            }
        }
        public static void LogError(string readme, string filpath)
        {
            string strTmp = "";
            string FilePath = Path.Combine(MapPath("./LOG/"), "Log_Error");
            // string FilePath = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("./"), "Log_Error");
            // string FilePath = @"C:\Program Files (x86)\APEX\SDP\OmniVox3D\AM\";

            strTmp = filpath + "_" + DateTime.Now.Year.ToString() + "\\" + DateTime.Now.Month.ToString() + "\\" + DateTime.Now.Day.ToString() + "\\";
            FilePath += strTmp;


            lock ("LOG")
            {
                lock ("LOG")
                {
                    if (!Directory.Exists(FilePath))
                    {
                        Directory.CreateDirectory(FilePath);
                    }

                    FilePath += filpath + "_";
                    FilePath += DateTime.Now.Year.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Hour.ToString() + ".txt";


                    using (TextWriter myWriter = new StreamWriter(FilePath, true))
                    {
                        TextWriter.Synchronized(myWriter).WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " " + readme);
                    }
                }
            }
        }

    }

    public class TransitLog : System.Web.UI.Page
    {
        public static void LogTransit(Exception ex, string filpath)
        {
            string msg = ex.Message + Environment.NewLine + ex.StackTrace;

            if (ex.InnerException != null)
                msg += Environment.NewLine + "Inner: " + ex.InnerException.Message + Environment.NewLine + ex.InnerException.StackTrace;

            LogTransit(msg, filpath);
        }

        //public static void LogError(string readme)
        //{
        //    string strTmp = "";
        //    string FilePath = Path.Combine(ConfigurationManager.AppSettings["logDirectory"], "Log");
        //    // string FilePath = @"C:\Program Files (x86)\APEX\SDP\OmniVox3D\AM\";

        //    strTmp = "MultiWebCallBackLog" + "_" + DateTime.Now.Year.ToString() + "\\" + DateTime.Now.Month.ToString() + "\\" + DateTime.Now.Day.ToString() + "\\";
        //    FilePath += strTmp;


        //    lock ("LOG")
        //    {
        //        lock ("LOG")
        //        {
        //            if (!Directory.Exists(FilePath))
        //            {
        //                Directory.CreateDirectory(FilePath);
        //            }

        //            FilePath += "WebCallBack_log_";
        //            FilePath += DateTime.Now.Year.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Hour.ToString() + ".txt";


        //            using (TextWriter myWriter = new StreamWriter(FilePath, true))
        //            {
        //                TextWriter.Synchronized(myWriter).WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " " + readme);
        //            }
        //        }
        //    }
        //}
        public static string MapPath(string strPath)
        {
            if (HttpContext.Current != null)
            {
                return HttpContext.Current.Server.MapPath(strPath);
            }
            else //if not web System invoke
            {
                strPath = "";
                strPath = strPath.Replace("/", "\\");
                if (strPath.StartsWith("\\"))
                {
                    //strPath = strPath.Substring(strPath.IndexOf('\\', 1)).TrimStart('\\');
                    strPath = strPath.TrimStart('\\');
                }
                return System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, strPath);
            }
        }

        public static void LogTransit(string readme, string filpath)
        {
            string strTmp = "";
            //string FilePath = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("./"), "Log_Transit");
            string FilePath = Path.Combine(MapPath("./LOG/"), "Log_Transit");
            // string FilePath = @"C:\Program Files (x86)\APEX\SDP\OmniVox3D\AM\";

            strTmp = filpath + "_" + DateTime.Now.Year.ToString() + "\\" + DateTime.Now.Month.ToString() + "\\" + DateTime.Now.Day.ToString() + "\\";
            FilePath += strTmp;


            lock ("LOG")
            {
                lock ("LOG")
                {
                    if (!Directory.Exists(FilePath))
                    {
                        Directory.CreateDirectory(FilePath);
                    }

                    FilePath += filpath + "_";
                    FilePath += DateTime.Now.Year.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Hour.ToString() + ".txt";


                    using (TextWriter myWriter = new StreamWriter(FilePath, true))
                    {
                        TextWriter.Synchronized(myWriter).WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " " + readme);
                    }
                }
            }
        }

    }
}
