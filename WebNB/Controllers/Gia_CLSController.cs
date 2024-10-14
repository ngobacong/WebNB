using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System.Net;
using WebNB.Models;
using WebNB.Models.Entities;
using WebNB.Services;

namespace WebNB.Controllers
{
    public class Gia_CLSController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Gia_CLSController(ApplicationDbContext context) 
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //tạo biến show data và sắp xếp data
            var Gia_CLSs = _context.Gia_CLS.OrderByDescending(p => p.STT).ToList();   
            return View(Gia_CLSs);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Ma,Ten,DVT,Gia_TH,Gia_BH,LoaiVP,NhomVP,NhomVP_BHYT,QD366,Ten43,GhiChuKt")]Gia_CLS cLS)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cLS);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }    
            return View(cLS);
        }


        public IActionResult Edit(int? id) 
        {
            var gia_cls = _context.Gia_CLS.Find(id);

            if (gia_cls == null)
            {
                return RedirectToAction("Index", "Gia_CLS");
            }

            var gia_clsdto = new Gia_CLSDto()
            {
                Ma = gia_cls.Ma,
                Ten = gia_cls.Ten,
                DVT = gia_cls.DVT,
                Gia_TH = gia_cls.Gia_TH,
                Gia_BH = gia_cls.Gia_BH,
                LoaiVP = gia_cls.LoaiVP,
                NhomVP = gia_cls.NhomVP,
                NhomVP_BHYT = gia_cls.NhomVP_BHYT,
                QD366 = gia_cls.QD366,
                Ten43 = gia_cls.Ten43,
                GhiChuKt = gia_cls.GhiChuKt,
            };

            ViewData["STT"] = gia_cls.STT;

            return View(gia_clsdto);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Gia_CLSDto gia_CLSDto)
        {
            var gia_cls = _context.Gia_CLS.Find(id);

            if (gia_cls == null)
            {
                return RedirectToAction("Index", "Gia_CLS");
            }

            if (!ModelState.IsValid) 
            {
                ViewData["STT"] = gia_cls.STT;

                return View(gia_CLSDto);
            }

            gia_cls.Ma = gia_CLSDto.Ma;
            gia_cls.Ten = gia_CLSDto.Ten;
            gia_cls.DVT = gia_CLSDto.DVT;
            gia_cls.Gia_TH = gia_CLSDto.Gia_TH;
            gia_cls.Gia_BH = gia_CLSDto.Gia_BH;
            gia_cls.LoaiVP = gia_CLSDto.LoaiVP;
            gia_cls.NhomVP = gia_CLSDto.NhomVP;
            gia_cls.NhomVP_BHYT = gia_CLSDto.NhomVP_BHYT;
            gia_cls.QD366 = gia_CLSDto.QD366;
            gia_cls.Ten43 = gia_CLSDto.Ten43;
            gia_cls.GhiChuKt = gia_CLSDto.GhiChuKt;

            _context.SaveChanges();

            return RedirectToAction("Index", "Gia_CLS");
        }

        public IActionResult Delete(int id)
        {
            var gia_cls = _context.Gia_CLS.Find(id);
            if (gia_cls == null)
            {
                return RedirectToAction("Index", "Gia_CLS");
            }

            _context.Gia_CLS.Remove(gia_cls);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // Action để hiển thị view import Excel
        [HttpGet]
        public IActionResult ImportExcel()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ImportExcel(IFormFile file)
        {
            //Kiểm tra có chọn file hay không.
            if (file == null || file.Length == 0)
            {
                ViewBag.ErrorMessage = "Chọn file import đê";
                return View();
            }

            // Kiểm tra định dạng file (chỉ cho phép .xls và .xlsx)
            var filefileExtension = Path.GetExtension(file.FileName);
            if (filefileExtension != ".xls" && filefileExtension != ".xlsx")
            {
                ViewBag.Message = "Không đúng định dạng. Chọn file .xls hoặc .xlsx nhé!";
                return View();
            }
            try
            {
                //Đọc file Excel
                using (var pakage = new ExcelPackage(file.OpenReadStream()))
                {
                    var worksheet = pakage.Workbook.Worksheets[0]; //Lấy workshet đầu tiên
                    // Kiểm tra xem file Excel có dữ liệu hay không
                    if (worksheet.Dimension == null || worksheet.Dimension.Rows == 0)
                    {
                        ViewBag.ErrorMessage = "File không có dữ liệu.";
                        return View();
                    }
                    var rowCount = worksheet.Dimension.Rows;

                    var students = new List<Gia_CLS>();
                    for (int row = 2; row <= rowCount; row++) // Bắt đầu từ hàng 2 để bỏ qua tiêu đề
                    {
                        // Lấy giá trị từ ô
                        //var STT = worksheet.Cells[row, 1].Text; 
                        var Ma = worksheet.Cells[row, 1].Text;
                        var Ten = worksheet.Cells[row, 2].Text;
                        var DVT = worksheet.Cells[row, 3].Text;
                        var Gia_TH = worksheet.Cells[row, 4].Text;
                        var Gia_BH = worksheet.Cells[row, 5].Text;
                        var LoaiVP = worksheet.Cells[row, 6].Text;
                        var NhomVP = worksheet.Cells[row, 7].Text;
                        var NhomVP_BHYT = worksheet.Cells[row, 8].Text;
                        var QD366 = worksheet.Cells[row, 9].Text;
                        var Ten43 = worksheet.Cells[row, 10].Text;
                        var GhiChuKt = worksheet.Cells[row, 11].Text;
                        var Gia_Cls = new Gia_CLS
                        {
                            //STT = int.TryParse(STTTest, out int STT) ? STT : 0,
                            Ma = string.IsNullOrWhiteSpace(Ma) ? "" : Ma,
                            Ten = string.IsNullOrWhiteSpace(Ten) ? "" : Ten,
                            DVT = string.IsNullOrWhiteSpace(DVT) ? "" : DVT,
                            Gia_TH = int.TryParse(Gia_TH, out int Gia_THs) ? Gia_THs : 0,
                            Gia_BH = int.TryParse(Gia_BH, out int Gia_BHs) ? Gia_BHs : 0,
                            LoaiVP = string.IsNullOrWhiteSpace(LoaiVP) ? "" : LoaiVP,
                            NhomVP = string.IsNullOrWhiteSpace(NhomVP) ? "" : NhomVP,
                            NhomVP_BHYT = string.IsNullOrWhiteSpace(NhomVP_BHYT) ? "" : NhomVP_BHYT,
                            QD366 = string.IsNullOrWhiteSpace(QD366) ? "" : QD366,
                            Ten43 = string.IsNullOrWhiteSpace(Ten43) ? "" : Ten43,
                            GhiChuKt = string.IsNullOrWhiteSpace(GhiChuKt) ? "" : GhiChuKt,
                        };
                        students.Add(Gia_Cls);
                    }
                    // Lưu vào cơ sở dữ liệu
                    await _context.Gia_CLS.AddRangeAsync(students);
                    await _context.SaveChangesAsync();
                }
                ViewBag.SuccessMessage = "File Excel đã được import thành công!";
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Có lỗi xảy ra trong quá trình xử lý file: " + ex.Message;
                return View();
            }

        }
    }
}
