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
    public class OgretmenController : Controller
    {

        private readonly IOgretmenManager manager;
        private readonly ISinifManager sinifManager;
        private readonly IMapper mapper;

        public OgretmenController(IOgretmenManager manager,
            ISinifManager sinifManager,
            IMapper mapper)
        {
            this.manager = manager;
            this.sinifManager = sinifManager;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            List<Ogretmen> ogretmenler = new List<Ogretmen>();
            ogretmenler = manager.GetAll(null);


            ogretmenler.Add(new Ogretmen());

            return View(ogretmenler);
        }

        public IActionResult Create()
        {
            OgretmenCreateDto createDto = new OgretmenCreateDto();

            createDto.OgretmenDto = new OgretmenDto();
            //createDto.Sinif = 

            //new SelectList(fruits, "Id", "SinifAdi");
            var siniflar = sinifManager.GetAll(null);
            var sinifSelect = mapper.Map<List<Sinif>, List<SinifModel>>(siniflar);
            createDto.Sinif = new SelectList(sinifSelect, "Id", "SinifAdi");

            return View(createDto);
        }

        [HttpPost]
        public IActionResult Create(OgretmenCreateDto dto)
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

                var ogretmen = mapper.Map<OgretmenDto, Ogretmen>(dto.OgretmenDto);
                ogretmen.SinifId = 1;
                try
                {

                    manager.Add(ogretmen);

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
