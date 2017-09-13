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
        private string FileDir = "C:\\Users\\JOCHONCHON\\Pictures\\Saved Pictures\\test\\";
        public void print_sub_Url()
        {
            for(int i = 0; i < 20; i++)
            {
                Console.WriteLine(sub_Url[i]);
            }
        }
        public StreamReader request_Site(string url_site)
        {
            WebRequest req_Site = WebRequest.Create(url_site);
            Stream objStream;
            objStream = req_Site.GetResponse().GetResponseStream();

            StreamReader objReader = new StreamReader(objStream);

            return objReader;
        }

        public void tag_find(StreamReader objReader,string find)
        {
            string sLine = "";
            int i = 0;

            while (sLine != null)
            {
                try
                {
                    sLine = objReader.ReadLine();
                    if (sLine.IndexOf(find) > -1)
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

        public void sub_Site(int x,int y)
        {
            for (int i = 0; i < 20; i++)
            {
                try
                {
                    sub_Url[x] = "https:" + arr_Url[x].Substring(x, y);
                }
                catch (System.IndexOutOfRangeException)
                {
                    continue;
                }
            }
        }
        public void req_batch(SuyongsoParshing x)
        {
            for (int i = 0; i < 20; i++)
            {
                x.request_Site(sub_Url[i]);
            }
        }
        public void download_img(string img_Url)
        {
            WebClient client = new WebClient();
            for(int i = 0; i < 10; i++)
            {
                client.DownloadFile(img_Url,(FileDir + i.ToString()));
            }
        }

    }
}
