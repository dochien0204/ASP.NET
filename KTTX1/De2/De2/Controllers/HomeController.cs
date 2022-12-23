using De2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace De2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Cau1()
        {
            return View();
        }

        public ActionResult Cau2()
        {
            return View();
        }

        public ActionResult KetQua(SanPham sp)
        {
            ViewBag.MaSP = sp.MaSP;
            ViewBag.TenSP = sp.TenSP;
            ViewBag.DonGia = sp.DonGia;
            ViewBag.SoLuong = sp.SoLuong;
            if (sp.SoLuong >= 100)
                ViewBag.ThanhTien = 1000;
            else
            {
                ViewBag.ThanhTien = 0;
            }
            return View();
        }
    }
}