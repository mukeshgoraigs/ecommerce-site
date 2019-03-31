using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

/// <summary>
/// Summary description for SendMessageData
/// </summary>
public class SendMessageData
{
	public SendMessageData()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static void sendMessage(string msg, string mobile)
    {
        string api = "http://sms.parkentechnology.com/httpapi/httpapi?";
        string token = "bcf7c2004cd574d786cf5b3586f41f62";
        string senderid = "UBANYA";
        string rmobile = mobile;
        string route = "2";
        string msgtype = "1";
        string sms = msg;

        string cont = "token=" + token + "&sender=" + senderid + "&number=" + rmobile + "&route=" + route + "&type=" + msgtype + "&sms=" + sms;
        string apiurl = api + "" + cont;

        try
        {
            //Create the request and send data to Ozeki NG SMS Gateway Server by        HTTP connection
            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(apiurl);

            //Get response from Ozeki NG SMS Gateway Server and read the answer
            HttpWebResponse myResp = (HttpWebResponse)myReq.GetResponse();
            System.IO.StreamReader respStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());
            string responseString = respStreamReader.ReadToEnd();
            respStreamReader.Close();
            myResp.Close();
        }
        catch (Exception ex) { }
    }
}