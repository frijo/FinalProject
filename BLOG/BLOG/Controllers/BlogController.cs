using BLOG.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BLOG.Controllers
{
    public class BlogController : Controller
    {
        //
        // GET: /Blog/
        private Application_Db db= new Application_Db();
        public ActionResult Index()
        {
            List<BLOGS> Blog = db.Blogs.ToList();
            ViewBag.Blogs = Blog;
            
            return View();
        }
        public ActionResult IndexUser()
        {
            List<BLOGS> Blog = db.Blogs.ToList();
            ViewBag.Blogs = Blog;

            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(DateTime Date, String Title = "", String Content = "")
        {
            BLOGS nuevo = new BLOGS();

            nuevo.Title = Title;
            nuevo.Date = Date;
            nuevo.Content = Content;
            if (ModelState.IsValid)
            {

                db.Blogs.Add(nuevo);
                db.SaveChanges();


                return RedirectToAction("Index");
            }


            return View();
        }

        public ActionResult Edit(int id=0)
        {
            BLOGS blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            ViewBag.blog = blog;
            return View();
        }
        [HttpPost]
        public ActionResult Edit(DateTime Date, int id=0,String Title = "", String Content = "")
        {
            

            if (ModelState.IsValid)
            {
                BLOGS blog = db.Blogs.Find(id);
                blog.Date = Date;
                blog.Title = Title;
                blog.Content = Content;
                db.Entry(blog).State = EntityState.Modified;
                db.SaveChanges();


                return RedirectToAction("Index");
            }


            return View();
        }



        public ActionResult Delete(int id = 0)
        {
            BLOGS blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            ViewBag.blog = blog;
            return View();
        }


       [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id=0)
        {


            if (ModelState.IsValid)
            {
                BLOGS blog = db.Blogs.Find(id);

                db.Blogs.Remove(blog);
                db.SaveChanges();       


                return RedirectToAction("Index");
            }


            return View();
        }

    }
}
