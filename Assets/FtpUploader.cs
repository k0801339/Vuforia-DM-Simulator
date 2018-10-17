using UnityEngine;
using System.Collections;
using System;
using System.Net;
using System.IO;
using UnityEngine.UI;

public class FtpUploader : MonoBehaviour
{
    public string FTPHost = "ftp://140.114.76.108:2121/3dinn/src/";
    public string FTPUserName = "team1";
    public string FTPPassword = "y3Pkn";
    //public string FTPHost = "ftp://ftp.dlptest.com/";
    //public string FTPUserName = "dlpuser@dlptest.com";
    //public string FTPPassword = "e73jzTRTNqCN9PYAAjjn";
    public string FilePath;

    public void UploadFile(byte[] fileContents)
    {
        FilePath = Application.persistentDataPath + "/Input.png";
        Debug.Log("Upload Path: " + FilePath);

        // Get the object used to communicate with the server.
        FtpWebRequest request = (FtpWebRequest)WebRequest.Create(FTPHost + new FileInfo(FilePath).Name);
        request.Method = WebRequestMethods.Ftp.UploadFile;

        // This example assumes the FTP site uses anonymous logon.
        request.Credentials = new NetworkCredential(FTPUserName, FTPPassword);

        // Copy the contents of the file to the request stream.
        //byte[] fileContents;
        //using (StreamReader sourceStream = new StreamReader(FilePath))
        //{
        //    fileContents = System.Text.Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
        //}

        request.ContentLength = fileContents.Length;
        Debug.Log("Start Uploading");
        using (Stream requestStream = request.GetRequestStream())
        {
            requestStream.Write(fileContents, 0, fileContents.Length);
        }
        Debug.Log("End Uploading");
    }
    public string DownloadFile()
    {
        FilePath = Application.persistentDataPath + "/Match.txt";
        Debug.Log("Try to find .ans file in Path: " + FilePath);

        FtpWebRequest request = (FtpWebRequest)WebRequest.Create(FTPHost);
        request.Method = WebRequestMethods.Ftp.ListDirectory;

        request.Credentials = new NetworkCredential(FTPUserName, FTPPassword);
        StreamReader streamReader = new StreamReader(request.GetResponse().GetResponseStream());
        string filename = streamReader.ReadLine();
        string matchidx = "";
        while(filename!=null)
        {
            //Debug.Log(filename);
            if(filename.Contains(".ans"))
            {
                matchidx = filename.Substring(0, filename.IndexOf(".ans"));
                Debug.Log(matchidx);
                Text showmatch = GameObject.Find("Screenshot").GetComponentInChildren<Text>();
                showmatch.text = "IKEA chair: No. " + matchidx;
                showmatch.enabled = true;
                break;
            }
            filename = streamReader.ReadLine();
        }

        request = null;
        streamReader = null;
        Debug.Log("End download");
        return matchidx.PadLeft(4, '0');
    }
}