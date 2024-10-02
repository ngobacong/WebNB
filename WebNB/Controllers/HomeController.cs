using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System.Diagnostics;
using WebNB.Models;
using System.Data;
using System.IO;
using WebNB.Services;

namespace WebNB.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ApplicationDbContext _context;

        //public HomeController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //[HttpPost]
        //public IActionResult ImportExcel(IFormFile file)
        //{
        //    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        //    if (file != null && file.Length > 0)
        //    {
        //        using (var package = new ExcelPackage(file.OpenReadStream()))
        //        {
        //            var worksheet = package.Workbook.Worksheets["Sheet1"]; // Lấy sheet đầu tiên
        //            int rowCount = worksheet.Dimension.Rows;
        //            int colCount = worksheet.Dimension.Columns;

        //            // Vòng lặp qua các dòng để lấy dữ liệu
        //            for (int row = 2; row <= rowCount; row++) // Bỏ qua tiêu đề ở hàng 1
        //            {
        //                var col1 = worksheet.Cells[row, 1].Value?.ToString();
        //                var col2 = worksheet.Cells[row, 2].Value?.ToString();
        //                var col3 = worksheet.Cells[row, 3].Value?.ToString();
        //                var col4 = worksheet.Cells[row, 4].Value?.ToString();
        //                var col5 = worksheet.Cells[row, 5].Value?.ToString();
        //                var col6 = worksheet.Cells[row, 6].Value?.ToString();
        //                var col7 = worksheet.Cells[row, 7].Value?.ToString();
        //                var col8 = worksheet.Cells[row, 8].Value?.ToString();
        //                var col9 = worksheet.Cells[row, 9].Value?.ToString();
        //                var col10 = worksheet.Cells[row, 10].Value?.ToString();
        //                var col11 = worksheet.Cells[row, 11].Value?.ToString();
        //                var col12 = worksheet.Cells[row, 12].Value?.ToString();
        //                //... Đọc thêm các cột khác nếu cần

        //                // Tạo đối tượng lưu dữ liệu vào cơ sở dữ liệu
        //                var newData = new Import_GiaCLS
        //                {
        //                    c1 = col1,
        //                    c2 = col2,
        //                    c3 = col3,
        //                    c4 = col4,
        //                    c5 = col5,
        //                    c6 = col6,
        //                    c7 = col7,
        //                    c8 = col8,
        //                    c9 = col9,
        //                    c10 = col10,
        //                    c11 = col11,
        //                    c12 = col12,
        //                };

        //                // Lưu dữ liệu vào cơ sở dữ liệu
        //                _context.Import_GiaCLS.Add(newData);
        //            }

        //            _context.SaveChanges(); // Lưu tất cả vào database
        //        }
        //    }

        //    return RedirectToAction("Index", "Gia_CLS"); // Chuyển hướng sau khi import
        //}
    }
}
