using CsQuery;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ForexPivot.Controllers
{
    public class pivotCell
    {
        public string name;
        public string S3;
        public string S2;
        public string S1;
        public string pivotPoints;
        public string R1;
        public string R2;
        public string R3;
        public pivotCell ()
        {
            name = "";
            S3 = "";
            S2 = "";
            S1 = "";
            pivotPoints = "";
            R1 = "";
            R2 = "";
            R3 = "";
        }
    }
    public class PivotController : Controller
    {
        // GET: Pivot
        public ActionResult Index(string id)
        {
            ArrayList data_summery = new ArrayList();
            string[] flag_list = { "EURUSD", "USDJPY","GBPUSD","USDCHF","USDCAD","EURJPY","AUDUSD","NZDUSD","EURGBP","EURCHF","GBPJPY","GBPCHF"};
            WebClient webClient = new WebClient();
            webClient.Headers.Add("user-agent", "Only a test!");
            webClient.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
            const string strUrl = "https://www.investing.com/technical/pivot-points";
            string parameters = "period="+ id;
            string pageContent = webClient.UploadString(strUrl, parameters);
            CQ dom = pageContent;
            CQ table = dom.Find(".closedTbl").Eq(0);
            CQ tbody = table.Find("tbody").Eq(0);
            for ( int i = 0;i < tbody.Children("tr").Length; i++)
            {
                CQ tr = tbody.Children("tr").Eq(i);
                pivotCell cellData = new pivotCell();
                CQ cTitle = tr.Children("td").Eq(0).Find("a").Eq(0);
                cellData.name = cTitle.Text().Replace("/","");
                cellData.S3 = tr.Children("td").Eq(1).Text();
                cellData.S2 = tr.Children("td").Eq(2).Text();
                cellData.S1 = tr.Children("td").Eq(3).Text();
                cellData.pivotPoints = tr.Children("td").Eq(4).Text();
                cellData.R1 = tr.Children("td").Eq(5).Text();
                cellData.R2 = tr.Children("td").Eq(6).Text();
                cellData.R3 = tr.Children("td").Eq(7).Text();
                if (flag_list.Contains(cellData.name))
                {
                    data_summery.Add(cellData);
                }
            }
            ViewBag.selval = id;
            ViewBag.data = data_summery;
            return View();
        }
    }
}