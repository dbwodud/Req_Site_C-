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
        static void Main(string[] args)
        {
            SuyongsoParshing site = new SuyongsoParshing();
            site.Tag_find(site.request_Site("https://www.suyongso.com/anidong"), "hx");
            site.sub_Site(33,35);
            site.print_sub_Url();
            site.batch_req(site);
            site.print_Url();
        }
    }
}
