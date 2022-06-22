using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Okul.BL.Abstract;
using Okul.Domain;
using System;
using System.Collections.Generic;
using WebUI.Areas.Admin.Models;
using WebUI.Areas.Admin.Models.Dtos;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class OgrenciController : Controller
    {
        private readonly IOgrenciManager manager;
        private readonly ISinifManager sinifManager;
        private readonly IMapper mapper;

        public OgrenciController(IOgrenciManager manager,
            ISinifManager sinifManager,
            IMapper mapper)
        {
            this.manager = manager;
            this.sinifManager = sinifManager;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            List<Ogrenci> ogrenciler = new List<Ogrenci>();
            ogrenciler = manager.GetAll(null);

            if (ogrenciler.Count == 0)
                ogrenciler.Add(new Ogrenci());

            return View(ogrenciler);
        }

        public IActionResult Create()
        {
            OgrenciCreateDto createDto = new OgrenciCreateDto();

            createDto.OgrenciDto = new OgrenciDto();
            //createDto.Sinif = 

            //new SelectList(fruits, "Id", "SinifAdi");
            var siniflar = sinifManager.GetAll(null);
            var sinifSelect = mapper.Map<List<Sinif>, List<SinifModel>>(siniflar);
            createDto.Sinif = new SelectList(sinifSelect, "Id", "SinifAdi");

            return View(createDto);
        }

        [HttpPost]
        public IActionResult Create(OgrenciCreateDto dto)
        {

            if (ModelState.IsValid)
            {
                // Kayit sirasinda amele yontemi 

                //Ogrenci og = new Ogrenci();
                //og.Adi = dto.Adi;
                //og.Soyadi = dto.Soyadi;
                //og.TcNo = dto.TcNo;
                //og.Gsm = dto.Gsm;
                //og.Cinsiyet = dto.Cinsiyet;

                var ogrenci = mapper.Map<OgrenciDto, Ogrenci>(dto.OgrenciDto);
                ogrenci.SinifId = 1;
                try
                {
                    manager.CheckForTckimlik(ogrenci.TcNo);
                    manager.CheckForGsm(ogrenci.Gsm);
                    manager.Add(ogrenci);

                    return RedirectToAction("Index", "Ogrenci", new { Areas = "Admin" });
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
