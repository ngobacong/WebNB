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
    }
}
