using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Okul.BL.Abstract;
using Okul.Domain;
using System;
using System.Collections.Generic;
using WebUI.Areas.Admin.Models.Dtos;

namespace WebUI.Areas.Admin.Controllers
{
    //[Area("Admin")]
    //public class OgretmenController : Controller
    //{
    //    private readonly OkulDbContext _context;

    //    public OgretmenController(OkulDbContext context)
    //    {
    //        _context = context;
    //    }

    //    // GET: Admin/Ogretmen
    //    public async Task<IActionResult> Index()
    //    {
    //        var okulDbContext = _context.Ogretmenler.Include(o => o.Brans);
    //        return View(await okulDbContext.ToListAsync());
    //    }

    //    // GET: Admin/Ogretmen/Details/5
    //    public async Task<IActionResult> Details(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return NotFound();
    //        }

    //        var ogretmen = await _context.Ogretmenler
    //            .Include(o => o.Brans)
    //            .FirstOrDefaultAsync(m => m.Id == id);
    //        if (ogretmen == null)
    //        {
    //            return NotFound();
    //        }

    //        return View(ogretmen);
    //    }

    //    // GET: Admin/Ogretmen/Create
    //    public IActionResult Create()
    //    {
    //        ViewData["BransId"] = new SelectList(_context.Branslar, "Id", "Id");
    //        return View();
    //    }

    //    // POST: Admin/Ogretmen/Create
    //    // To protect from overposting attacks, enable the specific properties you want to bind to.
    //    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> Create([Bind("Adi,Soyadi,TcNo,Email,Gsm,Cinsiyet,DogumTarihi,Maas,BransId,Id,CreateDate")] Ogretmen ogretmen)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            _context.Add(ogretmen);
    //            await _context.SaveChangesAsync();
    //            return RedirectToAction(nameof(Index));
    //        }
    //        ViewData["BransId"] = new SelectList(_context.Branslar, "Id", "Id", ogretmen.BransId);
    //        return View(ogretmen);
    //    }

    //    // GET: Admin/Ogretmen/Edit/5
    //    public async Task<IActionResult> Edit(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return NotFound();
    //        }

    //        var ogretmen = await _context.Ogretmenler.FindAsync(id);
    //        if (ogretmen == null)
    //        {
    //            return NotFound();
    //        }
    //        ViewData["BransId"] = new SelectList(_context.Branslar, "Id", "Id", ogretmen.BransId);
    //        return View(ogretmen);
    //    }

    //    // POST: Admin/Ogretmen/Edit/5
    //    // To protect from overposting attacks, enable the specific properties you want to bind to.
    //    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> Edit(int id, [Bind("Adi,Soyadi,TcNo,Email,Gsm,Cinsiyet,DogumTarihi,Maas,BransId,Id,CreateDate")] Ogretmen ogretmen)
    //    {
    //        if (id != ogretmen.Id)
    //        {
    //            return NotFound();
    //        }

    //        if (ModelState.IsValid)
    //        {
    //            try
    //            {
    //                _context.Update(ogretmen);
    //                await _context.SaveChangesAsync();
    //            }
    //            catch (DbUpdateConcurrencyException)
    //            {
    //                if (!OgretmenExists(ogretmen.Id))
    //                {
    //                    return NotFound();
    //                }
    //                else
    //                {
    //                    throw;
    //                }
    //            }
    //            return RedirectToAction(nameof(Index));
    //        }
    //        ViewData["BransId"] = new SelectList(_context.Branslar, "Id", "Id", ogretmen.BransId);
    //        return View(ogretmen);
    //    }

    //    // GET: Admin/Ogretmen/Delete/5
    //    public async Task<IActionResult> Delete(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return NotFound();
    //        }

    //        var ogretmen = await _context.Ogretmenler
    //            .Include(o => o.Brans)
    //            .FirstOrDefaultAsync(m => m.Id == id);
    //        if (ogretmen == null)
    //        {
    //            return NotFound();
    //        }

    //        return View(ogretmen);
    //    }

    //    // POST: Admin/Ogretmen/Delete/5
    //    [HttpPost, ActionName("Delete")]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> DeleteConfirmed(int id)
    //    {
    //        var ogretmen = await _context.Ogretmenler.FindAsync(id);
    //        _context.Ogretmenler.Remove(ogretmen);
    //        await _context.SaveChangesAsync();
    //        return RedirectToAction(nameof(Index));
    //    }

    //    private bool OgretmenExists(int id)
    //    {
    //        return _context.Ogretmenler.Any(e => e.Id == id);
    //    }
    //}

    [Area("Admin")]

    [Authorize]
    public class OgretmenController : Controller
    {
        private readonly IOgretmenManager manager;
        private readonly IBransManager BransManager;
        private readonly IMapper mapper;

        public OgretmenController(IOgretmenManager manager,
            IBransManager BransManager,
            IMapper mapper)
        {
            this.manager = manager;
            this.BransManager = BransManager;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            List<Ogretmen> Ogretmenler = new List<Ogretmen>();
            Ogretmenler = manager.GetAll(null);

            if (Ogretmenler.Count == 0)
                Ogretmenler.Add(new Ogretmen());

            return View(Ogretmenler);
        }

        public IActionResult Create()
        {
            OgretmenCreateDto createDto = new OgretmenCreateDto();

            createDto.OgretmenDto = new OgretmenDto();
            //createDto.brans = 

            //new SelectList(fruits, "Id", "bransAdi");
            var branslar = BransManager.GetAll(null);
            var bransSelect = mapper.Map<List<Brans>, List<BransModel>>(branslar);
            createDto.Brans = new SelectList(bransSelect, "Id", "BransAdi");

            return View(createDto);
        }

        [HttpPost]
        public IActionResult Create(OgretmenCreateDto dto)
        {

            if (ModelState.IsValid)
            {
                // Kayit sirasinda amele yontemi 

                //Ogretmen og = new Ogretmen();
                //og.Adi = dto.Adi;
                //og.Soyadi = dto.Soyadi;
                //og.TcNo = dto.TcNo;
                //og.Gsm = dto.Gsm;
                //og.Cinsiyet = dto.Cinsiyet;

                var Ogretmen = mapper.Map<OgretmenDto, Ogretmen>(dto.OgretmenDto);
                Ogretmen.BransId = dto.OgretmenDto.BransId;
                try
                {
                    manager.CheckForTckimlik(Ogretmen.TcNo);
                    manager.CheckForGsm(Ogretmen.Gsm);
                    manager.Add(Ogretmen);

                    return RedirectToAction("Index", "Ogretmen", new { Areas = "Admin" });
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError("", ex.Message);
                }

            }

            return View(dto);
        }
    }
}
