using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using Fiddler;
using TimesheetManager.Library;

namespace TimesheetManager.Workers
{
    class IssueTracker
    {
        static Proxy oSecureEndpoint;
        static string sSecureEndpointHostname = "localhost";
        static int iSecureEndpointPort = 8877;
        public static void Start()
        {
            Main();
        }

        public static void DoQuit()
        {
            try
            {
                if (null != oSecureEndpoint)
                {
                    oSecureEndpoint.Dispose();
                }
                Fiddler.FiddlerApplication.Shutdown();

                Thread.Sleep(500);
            }
            catch (Exception exc)
            {
                System.Windows.Forms.MessageBox.Show(exc.Message);
            }
        }

        static void Main()
        {
            try
            {
                //List<Fiddler.Session> oAllSessions = new List<Fiddler.Session>();

                //Fiddler.FiddlerApplication.OnNotification += delegate(object sender, NotificationEventArgs oNEA) { /*Console.WriteLine("** NotifyUser: " + oNEA.NotifyString);*/ };

                //Fiddler.FiddlerApplication.BeforeRequest += delegate(Fiddler.Session oS)
                //{
                    //oS.bBufferResponse = true;
                    //string requestHeaders = oS.oRequest.headers.ToString().Trim().ToLower();
                    //if (requestHeaders.Contains("get /ontime2013web/api/v2/incidents") && requestHeaders.Contains("/template"))
                    //{
                    //    Globals.OnTime.IssueID = requestHeaders.Substring(36, requestHeaders.IndexOf("/template") - 36);
                    //}
                //};

                Fiddler.FiddlerApplication.AfterSessionComplete += delegate(Fiddler.Session oS) 
                {
                    string requestHeaders = "";
                    requestHeaders = oS.oRequest.headers.ToString().Trim().ToLower();
                    if (requestHeaders.Contains("get /ontime2013web/api/v2/incidents") && requestHeaders.Contains("/template"))
                    {
                        string[] wordAll = Encoding.UTF8.GetString(oS.responseBodyBytes).Split(new char[] { '{', '"', ':', '[', ',', '}' }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string word in wordAll)
                        {
                            Globals.Mech.AddWord(word);
                        }
                    }
                };

                Fiddler.CONFIG.IgnoreServerCertErrors = true;
                FiddlerApplication.Prefs.SetBoolPref("fiddler.network.streaming.abortifclientaborts", true);
                FiddlerCoreStartupFlags oFCSF = FiddlerCoreStartupFlags.Default;

                oFCSF = (oFCSF & ~FiddlerCoreStartupFlags.DecryptSSL);

                int iPort = 0;
                Fiddler.FiddlerApplication.Startup(iPort, oFCSF);

                oSecureEndpoint = FiddlerApplication.CreateProxyEndpoint(iSecureEndpointPort, true, sSecureEndpointHostname);
            }
            catch (Exception exc)
            {
                //System.Windows.Forms.MessageBox.Show(exc.Message);
            }
        }
    }
}
