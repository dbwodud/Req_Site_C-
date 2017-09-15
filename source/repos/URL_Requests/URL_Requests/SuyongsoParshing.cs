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

        private string FileDir = "C:\\Users\\JOCHONCHON\\Pictures\\Saved Pictures\\test\\";
        private int file_name = 1;
        private List<string> list_Url = new List<string>();
        private List<string> sub_Url = new List<string>();
        public void print_sub_Url()
        {
            for (int i = 0; i < sub_Url.Count; i++)
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

        public void Tag_find(StreamReader objReader, string find)
        {
            string sLine = "";

            while (sLine != null)
            {
                try
                {
                    sLine = objReader.ReadLine();
                    if (sLine.IndexOf(find) > -1)
                    {
                        list_Url.Add(sLine);
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

        public void sub_Site(int x, int y)
        {
            for (int i = 0; i < list_Url.Count; i++)
            {
                try
                {
                    sub_Url.Add("https:" + list_Url[i].Substring(x, y));
                }
                catch (System.IndexOutOfRangeException)
                {
                    continue;
                }
            }
            list_Url.Clear();
        }

        public void download_img(string img_Url)
        {
            WebClient client = new WebClient();

            client.DownloadFile(img_Url, (FileDir + file_name) + ".jpg");
            file_name++;
        }
        public void batch_req(SuyongsoParshing main_class)
        {
            for (int i = 0; i < sub_Url.Count; i++)
            {
                try
                {
                    main_class.Tag_find(main_class.request_Site(sub_Url[i]), "xe_content");
                }
                catch (System.UriFormatException)
                {
                    continue;
                }
            }
        }
        public void print_Url()
        {
            for(int i = 0; i < list_Url.Count; i++)
            {
                Console.WriteLine(list_Url[i]);
            }
        }
    }
}
