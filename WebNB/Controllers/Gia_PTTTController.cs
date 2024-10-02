using Microsoft.AspNetCore.Mvc;
using WebNB.Models;
using WebNB.Models.Entities;
using WebNB.Services;

namespace WebNB.Controllers
{
    public class Gia_PTTTController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Gia_PTTTController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var gia_Pttts = _context.Gia_PTTT.OrderByDescending(p => p.STT).ToList();
            return View(gia_Pttts);
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
            [Bind("Ma,Ten,DVT,Gia_TH,Gia_BH,LoaiVP,NhomVP,NhomVP_BHYT,QD366,Ten43,MaGiuong,GhiChuKt")] Gia_PTTT gia_PTTT)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gia_PTTT);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(gia_PTTT);
        }

        public IActionResult Edit(int? id)
        {
            var gia_Pttt = _context.Gia_PTTT.Find(id);

            if (gia_Pttt == null)
            {
                return RedirectToAction("Index", "Gia_Pttt");
            }

            var gia_PtttDto = new Gia_PtttDto()
            {
                Ma = gia_Pttt.Ma,
                Ten = gia_Pttt.Ten,
                DVT = gia_Pttt.DVT,
                Gia_TH = gia_Pttt.Gia_TH,
                Gia_BH = gia_Pttt.Gia_BH,
                LoaiVP = gia_Pttt.LoaiVP,
                NhomVP = gia_Pttt.NhomVP,
                NhomVP_BHYT = gia_Pttt.NhomVP_BHYT,
                QD366 = gia_Pttt.QD366,
                Ten43 = gia_Pttt.Ten43,
                //MaGiuong = gia_Pttt.MaGiuong,
                GhiChuKt = gia_Pttt.GhiChuKt,
            };

            ViewData["STT"] = gia_Pttt.STT;

            return View(gia_Pttt);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Gia_PtttDto gia_PtttDto)
        {
            var gia_Pttt = _context.Gia_PTTT.Find(id);

            if (gia_Pttt == null)
            {
                return RedirectToAction("Index", "Gia_PTTT");
            }

            if (!ModelState.IsValid)
            {
                ViewData["STT"] = gia_Pttt.STT;

                return View(gia_PtttDto);
            }

            gia_Pttt.Ma = gia_PtttDto.Ma;
            gia_Pttt.Ten = gia_PtttDto.Ten;
            gia_Pttt.DVT = gia_PtttDto.DVT;
            gia_Pttt.Gia_TH = gia_PtttDto.Gia_TH;
            gia_Pttt.Gia_BH = gia_PtttDto.Gia_BH;
            gia_Pttt.LoaiVP = gia_PtttDto.LoaiVP;
            gia_Pttt.NhomVP = gia_PtttDto.NhomVP;
            gia_Pttt.NhomVP_BHYT = gia_PtttDto.NhomVP_BHYT;
            gia_Pttt.QD366 = gia_PtttDto.QD366;
            gia_Pttt.Ten43 = gia_PtttDto.Ten43;
            //gia_Pttt.MaGiuong = gia_PtttDto.MaGiuong;
            gia_Pttt.GhiChuKt = gia_PtttDto.GhiChuKt;

            _context.SaveChanges();

            return RedirectToAction("Index", "Gia_PTTT");
        }

        public IActionResult Delete(int id)
        {
            var gia_Pttt = _context.Gia_PTTT.Find(id);
            if (gia_Pttt == null)
            {
                return RedirectToAction("Index", "Gia_PTTT");
            }

            _context.Gia_PTTT.Remove(gia_Pttt);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
