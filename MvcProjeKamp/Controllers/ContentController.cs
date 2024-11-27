using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKamp.Controllers
{
    
    public class ContentController : Controller
    {
        ContentManager contentManager = new ContentManager(new EfContentDal());
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetAllContent(string p)
        {
            p = "";
            var values = contentManager.GetContentList(p);
            
            

            return View(values.ToList());
        }
        public ActionResult ContentByHeading(int id)
        {
            var contentvalues = contentManager.GetListByHeadingID(id);
            return View(contentvalues);
        }
    }
}