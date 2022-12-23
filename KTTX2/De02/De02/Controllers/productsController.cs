using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using De02.Models;

namespace De02.Controllers
{
    public class productsController : Controller
    {
        private Model1 db = new Model1();

        // GET: products
        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.SapTheoTen = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.SapTheoGia = sortOrder == "Gia" ? "gia_desc" : "Gia";

            var products = db.products.Select(p => p);

            if(!String.IsNullOrEmpty(searchString))
            {
                products = db.products.Where(p => p.proname.Contains(searchString));
            }
            
            switch(sortOrder)
            {
                case "name_desc":
                    products = products.OrderByDescending(p => p.proname);
                        break;
                case "Gia":
                    products = products.OrderBy(p => p.price);
                    break;
                case "gia_desc":
                    products = products.OrderByDescending(p => p.price);
                    break;
                default:
                    products = products.OrderBy(p => p.proname);
                    break;
            }
            return View(products.ToList());
        }

        // GET: products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product product = db.products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: products/Create
        public ActionResult Create()
        {
            ViewBag.catid = new SelectList(db.categories, "catid", "catname");
            return View();
        }

        // POST: products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "proid,proname,price,stock,image,description,catid")] product product)
        {
            if (ModelState.IsValid)
            {
                product.image = "";
                var f = Request.Files["imageFile"];
                if(f != null && f.ContentLength > 0)
                {
                    string fileName = System.IO.Path.GetFileName(f.FileName);

                    string uploadPath = Server.MapPath("~/wwwroot/PhoneImages/" + fileName);

                    f.SaveAs(uploadPath);
                    product.image = fileName;
                }
                db.products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.catid = new SelectList(db.categories, "catid", "catname", product.catid);
            return View(product);
        }

        // GET: products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product product = db.products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.catid = new SelectList(db.categories, "catid", "catname", product.catid);
            return View(product);
        }

        // POST: products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "proid,proname,price,stock,image,description,catid")] product product)
        {
            if (ModelState.IsValid)
            {
                var f = Request.Files["imageFile"];
                if( f!= null && f.ContentLength > 0)
                {
                    string fileName = System.IO.Path.GetFileName(f.FileName);

                    string uploadPath = Server.MapPath("~/wwwroot/PhoneImages/" + fileName);

                    f.SaveAs(uploadPath);

                    product.image = fileName;
                }
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.catid = new SelectList(db.categories, "catid", "catname", product.catid);
            return View(product);
        }

        // GET: products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product product = db.products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            product product = db.products.Find(id);
            db.products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
