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

                File.WriteAllText(Globals.Static.regeditLocation, StringBank.Regedit.DoDelete);
                Process RunRegedit = Process.Start("regedit.exe", String.Format("/s {0}", Globals.Static.regeditLocation));
                RunRegedit.WaitForExit();

                File.Delete(Globals.Static.regeditLocation);

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

                Fiddler.FiddlerApplication.BeforeRequest += delegate(Fiddler.Session oS)
                {
                    string requestHeaders = requestHeaders = oS.oRequest.headers.ToString().Trim().ToLower();
                    if (requestHeaders.Contains("get /ontime2013web/api/v2/incidents") && requestHeaders.Contains("/template"))
                    {
                        Globals.OnTime.IssueID = requestHeaders.Substring(36, requestHeaders.IndexOf("/template") - 36);
                    }
                };

                //Fiddler.FiddlerApplication.AfterSessionComplete += delegate(Fiddler.Session oS) { };

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
                System.Windows.Forms.MessageBox.Show(exc.Message);
            }
        }
    }
}
