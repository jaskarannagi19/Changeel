using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Toad.Web.Controllers
{
    public class BaseController : Controller
    {
        private int getCurrenChangeId()
        {
            return 1;
        }
        // GET: Base
        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            //Our code goes here
            //Our code goes here
            //Our code goes here
            //Our code goes here
            //Our code goes here
            //Have this line to call base class initialize method.  

            int UrlId = getCurrenChangeId();
            //check if the user opening the site for the first time 
            if (requestContext.HttpContext.Session["URLHistory"] != null)
            {
                //The session variable exists. So the user has already visited this site and sessions is still alive. Check if this page is already visited by the user
                List<int> HistoryURLs = (List<int>)requestContext.HttpContext.Session["URLHistory"];
                if (HistoryURLs.Exists((element => element == UrlId)))
                {
                    //If the user has already visited this page in this session, then we can ignore this visit. No need to update the counter.
                    requestContext.HttpContext.Session["VisitedURL"] = 0;
                }
                else
                {
                    //if the user is visting this page for the first time in this session, then count this visit and also add this page to the list of visited pages(URLHistory variable)
                    HistoryURLs.Add(UrlId);
                    requestContext.HttpContext.Session["URLHistory"] = HistoryURLs;

                    //Make a note of the page Id to update the database later 
                    requestContext.HttpContext.Session["VisitedURL"] = UrlId;
                }
            }
            else
            {
                //if there is no session variable already created, then the user is visiting this page for the first time in this session. Then create a session variable and take the count of the page Id
                List<int> HistoryURLs = new List<int>();
                HistoryURLs.Add(UrlId);
                requestContext.HttpContext.Session["URLHistory"] = HistoryURLs;
                requestContext.HttpContext.Session["VisitedURL"] = UrlId;
            }




            int PageId;
            if (int.TryParse(HttpContext.Session["VisitedURL"].ToString(), out PageId))
            {
                if (PageId > 0)
                {
                   // UpdatePageViews(PagetId);
                }
            }





            base.Initialize(requestContext);
        }

    }
}