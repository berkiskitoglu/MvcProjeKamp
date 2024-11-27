using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKamp.Controllers
{
    public class StatisticsController : Controller
    {
        Context context = new Context();
        public ActionResult Index()
        {
            // Toplam Kategori Sayısı
            var CategoryCount = context.Categories.Count();
            ViewBag.CategoryCount = CategoryCount;

            // Başlık Tablosunda Yazılım Kategorisine Ait Başlık Sayısı
            var SoftwareHeadingCount = context.Headings.Count(x => x.CategoryID == context.Categories.Where(y => y.CategoryName == "Yazılım").Select(c => c.CategoryID).FirstOrDefault());
            ViewBag.SoftwareHeadingCount = SoftwareHeadingCount;

            //Yazar Adında 'a' Harfi Geçen Yazar Sayısı
            var WriterInA = context.Writers.Count(x => x.WriterName.Contains("a"));
            ViewBag.WriterInA = WriterInA;

            //En fazla Başlığa Sahip Kategori Adı
            var MaximumHeadingCategoryName = context.Categories.Join(context.Headings, x => x.CategoryID, y => y.CategoryID, (x, y) => x).GroupBy(x => x.CategoryName).OrderByDescending(g => g.Count()).Select(g => g.Key).FirstOrDefault();
            ViewBag.MaximumHeadingCategoryName = MaximumHeadingCategoryName;

            //Kategori tablosunda durumu true olan kategoriler ile false olan kategoriler arasındaki sayısal fark
            var TrueFalseDifference = (context.Categories.Where(x => x.CategoryStatus == true).Count() - context.Categories.Where(x => x.CategoryStatus == false).Count());
            ViewBag.TrueFalseDifference = TrueFalseDifference;
            return View();
                }
        

            }
        }