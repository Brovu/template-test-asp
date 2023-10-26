using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Template_Test.Models;

namespace Template_Test.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index(string filter, string filter2)
        {
            Template_63132843Entities2 db = new Template_63132843Entities2();

            List<SinhVien> list = db.SinhViens.Where(m => m.tenSV.ToLower().Contains(filter.ToLower())).ToList();
            List<SinhVien> list2 = db.SinhViens.Where(m => m.maSV.ToLower().Contains(filter2.ToLower())).ToList();

            if (!string.IsNullOrEmpty(filter) && list.Count == 0)
            {
                ViewBag.Message = "Không tìm thấy kết quả theo tên!";
            }

            if (!string.IsNullOrEmpty(filter2) && list2.Count == 0)
            {
                ViewBag.Message = "Không tìm thấy kết quả theo mã sinh viên!";
            }

            if (list2.Count > 0)
            {
                return View(list2);
            }
            else if (list.Count > 0)
            {
                return View(list);
            }

            return View(db.SinhViens.ToList());

        }
    }
}