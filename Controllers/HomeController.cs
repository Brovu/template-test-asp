using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Template_Test.Models;
using PagedList;
using System.Web.UI;

namespace Template_Test.Controllers
{
    public class HomeController : Controller
    {

        Template_63132843Entities2 db = new Template_63132843Entities2();

        public ActionResult TimKiem()
        {

            return View();
        }

        public ActionResult GioiThieu()
        {

            return View();
        }


        //Controller Sinh Viên

        public ActionResult DanhSach(int? page)
        {

            int pageSize = 2;
            int pageNumber = (page ?? 1);

            var sinhViens = new Template_63132843Entities2().SinhViens.ToList().ToPagedList(pageNumber, pageSize);
            return View(sinhViens);
        }

        public ActionResult ThemMoi()
        {

            return View(new SinhVien());
        }

        [HttpPost]
        public ActionResult ThemMoi(SinhVien sv, HttpPostedFileBase anhSV)
        {
            if (db.SinhViens.Any(x => x.maSV == sv.maSV))
            {
                ModelState.AddModelError("maSV", "Sinh viên này đã tồn tại");
                return View(sv);
            }
            if (anhSV.ContentLength > 0)
            {
                string rootFolder = Server.MapPath("/Images/");
                string path = rootFolder + anhSV.FileName;
                anhSV.SaveAs(path);
                sv.anhSV = "/Images/" + anhSV.FileName;
            }
            db.SinhViens.Add(sv);
            db.SaveChanges();
            return RedirectToAction("DanhSach");
        }

        public ActionResult Sua(string id)
        {
            SinhVien model = db.SinhViens.Find(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Sua(SinhVien model, HttpPostedFileBase anhSV2)
        {
            if (ModelState.IsValid)
            {
                var updateSV = db.SinhViens.Find(model.maSV);

                if (updateSV != null)
                {
                    updateSV.tenSV = model.tenSV;
                    updateSV.hoSV = model.hoSV;
                    updateSV.ngaySinh = model.ngaySinh;
                    updateSV.gioiTinh = model.gioiTinh;
                    updateSV.maLop = model.maLop;
                    updateSV.diaChi = model.diaChi;

                    if (anhSV2 != null && anhSV2.ContentLength > 0)
                    {
                        string rootFolder = Server.MapPath("/Images/");
                        string path = rootFolder + anhSV2.FileName;
                        anhSV2.SaveAs(path);
                        updateSV.anhSV = "/Images/" + anhSV2.FileName;
                    }

                    db.SaveChanges();
                    return RedirectToAction("DanhSach");
                }
            }

            return View(model);
        }

        public ActionResult Xoa(string id)
        {
            var model = db.SinhViens.Find(id);
            db.SinhViens.Remove(model);
            db.SaveChanges();
            return RedirectToAction("DanhSach");
        }

        public ActionResult ChiTiet(string id)
        {
            var model = db.SinhViens.Find(id);
            return View(model);
        }

        //Trang Tìm Kiếm
        public ActionResult TimKiem(string filter)
        {
            List<SinhVien> list = db.SinhViens.Where(m => m.tenSV.ToLower().Contains(filter.ToLower()) == true || m.maSV.ToLower().Contains(filter.ToLower())).ToList();

            /*List<News> listNews = (from m in db.News
                                   join typeNews in db.TypeNews on m.idType equals typeNews.ID
                                   where (m.Title.ToLower().Contains(filter.ToLower()) == true || m.Date.ToString().Contains(filter) & (m.idType == id | id == null))
                                   select m
                                 ).ToList();*/

            if (!string.IsNullOrEmpty(filter) && list.Count == 0)
            {
                ViewBag.Message = "Không tìm thấy kết quả!";
            }

            if (list.Count == 0)
            {
                return View(db.SinhViens.ToList());
            }

            return View(list);
        }



    }
}