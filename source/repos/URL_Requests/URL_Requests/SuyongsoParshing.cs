using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace URL_Requests
{
    public class SuyongsoParshing
    {
        private string[] arr_Url = new string[20];
        private string[] sub_Url = new string[20];
        private string site_Url;

        public SuyongsoParshing(string url) => site_Url = url;
        public void print_sub_Url()
        {
            for(int i = 0; i < 20; i++)
            {
                Console.WriteLine(sub_Url[i]);
            }
        }
        public StreamReader request_Site()
        {
            WebRequest req_Site = WebRequest.Create(site_Url);
            Stream objStream;
            objStream = req_Site.GetResponse().GetResponseStream();

            StreamReader objReader = new StreamReader(objStream);

            return objReader;
        }

        public void print_Site(StreamReader objReader)
        {
            string sLine = "";
            int i = 0;

            while (sLine != null)
            {
                try
                {
                    sLine = objReader.ReadLine();
                    if (sLine.IndexOf("hx") > -1)
                    {

                        arr_Url[i] = sLine;
                        i++;
                    }
                    else
                    {
                        continue;
                    }
                }
                catch (System.IndexOutOfRangeException)
                {
                    continue;
                }
                catch (System.NullReferenceException)
                {
                    continue;
                }
            }
        }

        public void sub_Site()
        {
            for (int x = 0; x < 20; x++)
            {
                try
                {
                    sub_Url[x] = "https:" + arr_Url[x].Substring(33, 35);
                }
                catch (System.IndexOutOfRangeException)
                {
                    continue;
                }
            }
        }
    }
}
