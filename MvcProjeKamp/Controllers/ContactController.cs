using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MvcProjeKamp.Controllers
{
    public class ContactController : Controller
    {
        ContactManager contactManager = new ContactManager(new EfContactDal());
        ContactValidator validationRules = new ContactValidator();
        Context context = new Context();
        public ActionResult Index()
        {
            

            var contactvalues = contactManager.GetContactList();            
            return View(contactvalues);

            
        }

        public PartialViewResult ContactAside()
        {
            var contactCount = context.Contacts.Count();
            ViewBag.contactCount = contactCount;
            return PartialView();
        }
        public ActionResult GetContactDetails(int id)
        {
            var contactvalues = contactManager.GetByID(id);
            return View(contactvalues);
        }
        
    }
}