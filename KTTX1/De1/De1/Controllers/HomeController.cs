using De1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace De1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
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

        public ActionResult KetQua(Hang h)
        {
            return View(h);
        }

        public ActionResult TinhHang()
        {
            ViewBag.MaHang = Request["MaHang"];
            ViewBag.TenHang = Request["TenHang"];
            int SoLuong = Convert.ToInt32(Request["SoLuong"]);
            float DonGia = float.Parse(Request["DonGia"]);
            float ThanhTien = 0;
            if(SoLuong >= 100)
            {
                ThanhTien = (float)(SoLuong * DonGia * 0.9);
            } else
            {
                ThanhTien = SoLuong * DonGia;
            }
            ViewBag.ThanhTien = ThanhTien;
            return View();
        }

    }
}