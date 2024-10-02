using Microsoft.AspNetCore.Mvc;
using WebNB.Models;
using WebNB.Models.Entities;
using WebNB.Services;

namespace WebNB.Controllers
{
    public class Gia_GIUONGController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Gia_GIUONGController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var gia_Giuongs = _context.Gia_GIUONG.OrderByDescending(p => p.STT).ToList();
            return View(gia_Giuongs);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Ma,Ten,DVT,Gia_TH,Gia_BH,LoaiVP,NhomVP,NhomVP_BHYT,QD366,Ten43,MaGiuong,GhiChuKt")] Gia_GIUONG gia_GIUONG)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gia_GIUONG);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(gia_GIUONG);
        }

        public IActionResult Edit(int? id)
        {
            var gia_Giuong = _context.Gia_GIUONG.Find(id);

            if (gia_Giuong == null)
            {
                return RedirectToAction("Index", "Gia_GIUONG");
            }

            var gia_GiuongDto = new Gia_GiuongDto()
            {
                Ma = gia_Giuong.Ma,
                Ten = gia_Giuong.Ten,
                DVT = gia_Giuong.DVT,
                Gia_TH = gia_Giuong.Gia_TH,
                Gia_BH = gia_Giuong.Gia_BH,
                LoaiVP = gia_Giuong.LoaiVP,
                NhomVP = gia_Giuong.NhomVP,
                NhomVP_BHYT = gia_Giuong.NhomVP_BHYT,
                QD366 = gia_Giuong.QD366,
                Ten43 = gia_Giuong.Ten43,
                MaGiuong = gia_Giuong.MaGiuong,
                GhiChuKt = gia_Giuong.GhiChuKt,
            };

            ViewData["STT"] = gia_Giuong.STT;

            return View(gia_GiuongDto);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Gia_GiuongDto gia_GiuongDto)
        {
            var gia_Giuong = _context.Gia_GIUONG.Find(id);

            if (gia_Giuong == null)
            {
                return RedirectToAction("Index", "Gia_GIUONG");
            }

            if (!ModelState.IsValid)
            {
                ViewData["STT"] = gia_Giuong.STT;

                return View(gia_GiuongDto);
            }

            gia_Giuong.Ma = gia_GiuongDto.Ma;
            gia_Giuong.Ten = gia_GiuongDto.Ten;
            gia_Giuong.DVT = gia_GiuongDto.DVT;
            gia_Giuong.Gia_TH = gia_GiuongDto.Gia_TH;
            gia_Giuong.Gia_BH = gia_GiuongDto.Gia_BH;
            gia_Giuong.LoaiVP = gia_GiuongDto.LoaiVP;
            gia_Giuong.NhomVP = gia_GiuongDto.NhomVP;
            gia_Giuong.NhomVP_BHYT = gia_GiuongDto.NhomVP_BHYT;
            gia_Giuong.QD366 = gia_GiuongDto.QD366;
            gia_Giuong.Ten43 = gia_GiuongDto.Ten43;
            gia_Giuong.MaGiuong = gia_GiuongDto.MaGiuong;
            gia_Giuong.GhiChuKt = gia_GiuongDto.GhiChuKt;

            _context.SaveChanges();

            return RedirectToAction("Index", "Gia_GIUONG");
        }

        public IActionResult Delete(int id)
        {
            var gia_Giuong = _context.Gia_GIUONG.Find(id);
            if (gia_Giuong == null)
            {
                return RedirectToAction("Index", "Gia_GIUONG");
            }

            _context.Gia_GIUONG.Remove(gia_Giuong);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
