using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace URL_Requests
{
    class Program
    {
        WebRequest Req_site(string url)
        {
            WebRequest GetUrl = WebRequest.Create(url);
            return GetUrl;
        }
        static void Main(string[] args)
        {
            SuyongsoParshing site = new SuyongsoParshing("https://www.suyongso.com/anidong");
            site.print_Site(site.request_Site());
            site.sub_Site();
            site.print_sub_Url();


        }
    }
}
