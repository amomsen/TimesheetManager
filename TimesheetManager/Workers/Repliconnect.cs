using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using TimesheetManager.Library;

namespace TimesheetManager.Workers
{
    public static class Repliconnect
    {
        public static string RunQuery(string Query)
        {
            string ApiUrl = "http://app.symplexity.co.za:82/TimeSheet/remoteAPI/remoteapi.ashx/8.27.32/testmode";
            HttpWebRequest ApiRequest = (HttpWebRequest)HttpWebRequest.Create(ApiUrl) as HttpWebRequest;
            ApiRequest.UserAgent = "Overseer";
            ApiRequest.Method = "POST";
            ApiRequest.ContentType = "application/json";
            ApiRequest.Headers.Add("X-Replicon-Security-Context", "User");
            ApiRequest.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(new ASCIIEncoding().GetBytes(Globals.Credentials.Username + ":" + Globals.Credentials.Password)));
            StreamWriter writer = new StreamWriter(ApiRequest.GetRequestStream());

            writer.Write(Query);
            writer.Close();

            HttpWebResponse response = ApiRequest.GetResponse() as HttpWebResponse;

            StreamReader reader = new StreamReader(response.GetResponseStream());
            string responseBody = reader.ReadToEnd();

            reader.Close();
            response.Close();

            return responseBody;
        }
        public static void RunInsert(string Query)
        {
            string ApiUrl = "http://app.symplexity.co.za:82/TimeSheet/remoteAPI/remoteapi.ashx";
            HttpWebRequest ApiRequest = (HttpWebRequest)HttpWebRequest.Create(ApiUrl) as HttpWebRequest;
            ApiRequest.UserAgent = "Overseer";
            ApiRequest.Method = "POST";
            ApiRequest.ContentType = "application/json";
            ApiRequest.Headers.Add("X-Replicon-Security-Context", "User");
            ApiRequest.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(new ASCIIEncoding().GetBytes(Globals.Credentials.Username + ":" + Globals.Credentials.Password)));
            StreamWriter writer = new StreamWriter(ApiRequest.GetRequestStream());

            writer.Write(Query);
            writer.Close();

            HttpWebResponse response = ApiRequest.GetResponse() as HttpWebResponse;

            StreamReader reader = new StreamReader(response.GetResponseStream());
            string responseBody = reader.ReadToEnd();

            reader.Close();
            response.Close();

            //return responseBody;
        }

    }
}
