using bainaycuatkvien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using System.IO;
using System.Web.UI.WebControls;
using System.Web.UI;
using OfficeOpenXml;

namespace bainaycuatkvien.Controllers
{
    public class AdminController : Controller
    {
        QLSieuThiEMarketEntities db = new QLSieuThiEMarketEntities();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Dangnhap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Dangnhap(FormCollection collection)
        {
            //Gan cac gia tri nguoi dung nhap lieu cac bien
            var tendn = collection["username"];
            var matkhau = collection["password"];
            if (String.IsNullOrEmpty(tendn))
            {
                ViewData["Loi1"] = "Phải nhập tên đăng nhập!";
            }
            else if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi2"] = "Phải nhập mật khẩu!";
            }
            else
            {
                //Gan gia tri cho doi tuong duoc tao moi
                NHANVIEN ad = db.NHANVIENs.SingleOrDefault(n => n.Username == tendn && n.Password == matkhau);
                if (ad != null)
                {
                    Session["Ten"] = ad.TenNV;
                    Session["Taikhoanadmin"] = ad;
                    return RedirectToAction("Index", "Admin");
                }
                else
                    ViewBag.Thongbao = "Tên đăng nhập hoặc mật khẩu không đúng!";
            }
            return View();
        }


        public ActionResult HangHoa()
        {
            return View(db.HANGHOAs.ToList());
        }

        public ActionResult addHangHoa()
        {
            ViewBag.MaHH = new SelectList(db.HANGHOAs.ToList().OrderBy(n => n.TenHH), "MaHH", "TenHH");
            ViewBag.MaNH = new SelectList(db.NHOMHANGs.ToList().OrderBy(n => n.TenNH), "MaNH", "TenNH");
            ViewBag.MaNCC = new SelectList(db.NHACUNGCAPs.ToList().OrderBy(n => n.TenNCC), "MaNCC", "TenNCC");
            return View();
        }


        



        [HttpPost]
        [ValidateInput(false)]
        public ActionResult addHangHoa(HANGHOA hanghoa)
        {
            ViewBag.MaHH = new SelectList(db.HANGHOAs.ToList().OrderBy(n => n.MaHH), "MaHH", "TenHH");
            ViewBag.MaNH = new SelectList(db.NHOMHANGs.ToList().OrderBy(n => n.MaNH), "MaNH", "TenNH");
            ViewBag.MaNCC = new SelectList(db.NHACUNGCAPs.ToList().OrderBy(n => n.MaNCC), "MaNCC", "TenNCC");
            
            db.HANGHOAs.Add(hanghoa);
            db.SaveChanges();
            return View();
            

        }


        


        public ActionResult Xoahanghoa(string id)
        {
            //Lay ra doi tuong sach can xoa theo ma
            HANGHOA hanghoa = db.HANGHOAs.SingleOrDefault(n => n.MaHH == id);
            ViewBag.MaHH = hanghoa.MaHH;
            if (hanghoa == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(hanghoa);
        }
        [HttpPost, ActionName("Xoahanghoa")]
        public ActionResult Xacnhanxoahanghoa(string id)
        {
            //Lay ra doi tuong sach can xoa theo ma
            HANGHOA hanghoa = db.HANGHOAs.SingleOrDefault(n => n.MaHH == id);
            ViewBag.MaHH = hanghoa.MaHH;
            if (hanghoa == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.HANGHOAs.Remove(hanghoa);
            db.SaveChanges();
            return RedirectToAction("HangHoa");
        }

        public ActionResult NhaCungCap(string id, int? page) 
        {
            
            int pageNumber = (page ?? 1 );
            int pageSize = 10;
            //return View(db.SACHes.ToList());
            return View(db.NHACUNGCAPs.ToList().OrderBy(n => n.MaNCC).ToPagedList(pageNumber, pageSize));
        }









        public ActionResult KhachHang()
        {
            return View(db.KHACHHANGs.ToList());
        }

        public ActionResult addKhachHang()
        {
            ViewBag.MaKH = new SelectList(db.KHACHHANGs.ToList().OrderBy(n => n.TenKH), "MaKH", "TenKH");
            ViewBag.MaMucHang = new SelectList(db.MUCHANGKHACHHANGs.ToList().OrderBy(n => n.TenMucHang), "MaMucHang", "TenMucHang");
            return View();
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult addKhachHang(KHACHHANG khachhang)
        {
            ViewBag.MaKH = new SelectList(db.KHACHHANGs.ToList().OrderBy(n => n.TenKH), "MaKH", "TenKH");
            ViewBag.MaMucHang = new SelectList(db.MUCHANGKHACHHANGs.ToList().OrderBy(n => n.TenMucHang), "MaMucHang", "TenMucHang");

            db.KHACHHANGs.Add(khachhang);
            db.SaveChanges();
            return View();
        }






        public ActionResult Xoakhachhang(string id)
        {
            //Lay ra doi tuong sach can xoa theo ma
            KHACHHANG khachhang = db.KHACHHANGs.SingleOrDefault(n => n.MaKH == id);
            ViewBag.MaKH = khachhang.MaKH;
            if (khachhang == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(khachhang);
        }
        [HttpPost, ActionName("Xoakhachhang")]
        public ActionResult Xacnhanxoakhachhang(string id)
        {
            //Lay ra doi tuong sach can xoa theo ma
            KHACHHANG khachhang = db.KHACHHANGs.SingleOrDefault(n => n.MaKH == id);
            ViewBag.MaKH = khachhang.MaKH;
            if (khachhang == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.KHACHHANGs.Remove(khachhang);
            db.SaveChanges();
            return RedirectToAction("KhachHang");
        }


        public ActionResult NhanVien()
        {
            return View(db.NHANVIENs.ToList());
        }

        public ActionResult addNhanVien()
        {
            ViewBag.MaQuyen = new SelectList(db.PHANQUYENs.ToList().OrderBy(n => n.TenQuyen), "MaQuyen", "TenQuyen");
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult addNhanVien(NHANVIEN nhanvien)
        {
            ViewBag.MaQuyen = new SelectList(db.PHANQUYENs.ToList().OrderBy(n => n.TenQuyen), "MaQuyen", "TenQuyen");

            db.NHANVIENs.Add(nhanvien);
            db.SaveChanges();
            return View();
        }
        

        public ActionResult CaLamViec()
        {
            return View(db.CALAMVIECs.ToString());
        }



        public ActionResult xuatHangHoa()
        {
            return View();
        }
        
    }

}
