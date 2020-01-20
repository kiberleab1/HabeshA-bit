using HabeshaBit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HabeshaBit.Controllers
{
    public class SearchController : Controller
    {
        
        // POST: Search
        public string Index(string query)
        {
            return query;
        }
     
    }
}