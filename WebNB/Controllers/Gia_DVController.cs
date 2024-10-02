using Microsoft.AspNetCore.Mvc;
using WebNB.Models;
using WebNB.Models.Entities;
using WebNB.Services;

namespace WebNB.Controllers
{
    public class Gia_DVController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Gia_DVController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var gia_DVs = _context.Gia_DV.OrderByDescending(p => p.STT).ToList();
            return View(gia_DVs);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Ma,Ten,DVT,Gia_TH,Gia_BH,LoaiVP,NhomVP,NhomVP_BHYT,QD366,Ten43,MaGiuong,GhiChuKt")] Gia_DV gia_DV)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gia_DV);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(gia_DV);
        }

        public IActionResult Edit(int? id)
        {
            var gia_Dv = _context.Gia_DV.Find(id);

            if (gia_Dv == null)
            {
                return RedirectToAction("Index", "Gia_DV");
            }

            var gia_DvDto = new Gia_DVDto()
            {
                Ma = gia_Dv.Ma,
                Ten = gia_Dv.Ten,
                DVT = gia_Dv.DVT,
                Gia_TH = gia_Dv.Gia_TH,
                Gia_BH = gia_Dv.Gia_BH,
                LoaiVP = gia_Dv.LoaiVP,
                NhomVP = gia_Dv.NhomVP,
                NhomVP_BHYT = gia_Dv.NhomVP_BHYT,
                QD366 = gia_Dv.QD366,
                Ten43 = gia_Dv.Ten43,
                MaGiuong = gia_Dv.MaGiuong,
                GhiChuKt = gia_Dv.GhiChuKt,
            };

            ViewData["STT"] = gia_Dv.STT;

            return View(gia_DvDto);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Gia_DVDto gia_DvDto)
        {
            var gia_dv = _context.Gia_DV.Find(id);

            if (gia_dv == null)
            {
                return RedirectToAction("Index", "Gia_DV");
            }

            if (!ModelState.IsValid)
            {
                ViewData["STT"] = gia_dv.STT;

                return View(gia_DvDto);
            }

            gia_dv.Ma = gia_DvDto.Ma;
            gia_dv.Ten = gia_DvDto.Ten;
            gia_dv.DVT = gia_DvDto.DVT;
            gia_dv.Gia_TH = gia_DvDto.Gia_TH;
            gia_dv.Gia_BH = gia_DvDto.Gia_BH;
            gia_dv.LoaiVP = gia_DvDto.LoaiVP;
            gia_dv.NhomVP = gia_DvDto.NhomVP;
            gia_dv.NhomVP_BHYT = gia_DvDto.NhomVP_BHYT;
            gia_dv.QD366 = gia_DvDto.QD366;
            gia_dv.Ten43 = gia_DvDto.Ten43;
            gia_dv.MaGiuong = gia_DvDto.MaGiuong;
            gia_dv.GhiChuKt = gia_DvDto.GhiChuKt;

            _context.SaveChanges();

            return RedirectToAction("Index", "Gia_DV");
        }

        public IActionResult Delete(int id)
        {
            var gia_dv = _context.Gia_DV.Find(id);
            if (gia_dv == null)
            {
                return RedirectToAction("Index", "Gia_DV");
            }

            _context.Gia_DV.Remove(gia_dv);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
