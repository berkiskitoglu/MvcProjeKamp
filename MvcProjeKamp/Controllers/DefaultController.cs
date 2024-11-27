using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKamp.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        ContentManager contentManager = new ContentManager(new EfContentDal());
       public ActionResult Headings()
        {
            var headinglist = headingManager.GetHeadingList();
            return View(headinglist);
        }
        public PartialViewResult Index(int id)
        {
            var contentlist = contentManager.GetListByHeadingID(id);
            return PartialView(contentlist);
        }
        public ActionResult SweetAlert()
        {
            return View();
        }
    }
}