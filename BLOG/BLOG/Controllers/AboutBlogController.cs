using BLOG.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BLOG.Controllers
{
    public class AboutBlogController : Controller
    {
        //
        // GET: /AboutBlog/

        private Application_Db db = new Application_Db();

        public ActionResult Index()
        {

            List<InformationBlog> InfoBlog = db.InformationBlogs.ToList();
            ViewBag.InfoBlogs = InfoBlog;
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(String NameBlog, String Detail)
        {
            InformationBlog nuevo = new InformationBlog();
            nuevo.Name = NameBlog;
            nuevo.Detail = Detail;

            if (ModelState.IsValid)
            {

                db.InformationBlogs.Add(nuevo);
                db.SaveChanges();


                //return RedirectToAction("Login");
            }

            return View();
        }



        public ActionResult Edit(int id=0)
        {
            InformationBlog blog = db.InformationBlogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            ViewBag.Info_Blogs = blog;
            return View();
        }
        [HttpPost]
        public ActionResult Edit(int id = 0, String NameBlog = "", String Detail = "")
        {
            if (ModelState.IsValid)
            {
                InformationBlog blog = db.InformationBlogs.Find(id);
                blog.Name = NameBlog;
                blog.Detail = Detail;

                db.Entry(blog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
