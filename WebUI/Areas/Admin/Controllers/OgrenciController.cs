using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Okul.BL.Abstract;
using Okul.Domain;
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
        private readonly IMapper mapper;
        private readonly ISinifManager sinifManager;

        public OgrenciController(IOgrenciManager manager, IMapper mapper, ISinifManager sinifManager)
        {
            this.manager = manager;
            this.mapper = mapper;
            this.sinifManager = sinifManager;
        }
        public IActionResult Index()
        {
            var ogrenciler = manager.GetAll(null);
            return View(ogrenciler);
        }


        [HttpGet]
        public IActionResult Create()
        {
            var ogrenci = new OgrenciCreateDto();
            var siniflar = sinifManager.GetAll(null);
            List<SinifModel> SiniflarSelecList = new();
            foreach (var item in siniflar)
            {
                SiniflarSelecList.Add(new SinifModel { SinifId = item.Id, SinifAdi = item.SinifAdi });
            }

            ViewBag.Siniflar = new SelectList(SiniflarSelecList, "SinifId", "SinifAdi");
            return View(ogrenci);
        }

        [HttpPost]
        public IActionResult Create(OgrenciCreateDto input)
        {
            if (ModelState.IsValid)
            {
                // Amele yontem 

                //Ogrenci ogrenci = new Ogrenci();
                //ogrenci.Adi= input.Adi;
                //ogrenci.Soyadi = input.Soyadi;
                var ogrenci = mapper.Map<OgrenciCreateDto, Ogrenci>(input);


                manager.Add(ogrenci);
                RedirectToAction("Index", "Ogrenci");
            }
            return View();
        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            var ogrenci = manager.Find(id);
            var updateDto = mapper.Map<Ogrenci, OgrenciCreateDto>(ogrenci);

            var siniflar = sinifManager.GetAll(null);
            List<SinifModel> sinifModels = new();
            foreach (var item in siniflar)
            {
                sinifModels.Add(new SinifModel { SinifId = item.Id, SinifAdi = item.SinifAdi });
            }

            var sinifSelectList = new SelectList(sinifModels, "SinifId", "SinifAdi");

            ViewBag.Siniflar = sinifSelectList;
            return View(updateDto);
        }



        [HttpPost]
        public IActionResult Update(OgrenciCreateDto input)
        {

            if (ModelState.IsValid)
            {
                var ogrenci = mapper.Map<OgrenciCreateDto, Ogrenci>(input);

                manager.Update(ogrenci);
                return RedirectToAction("Index", "Ogrenci");


            }


            ModelState.AddModelError("", "TcKimlik numarasi yanliş girilmiş");


            return View();
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var entity = manager.Find(id);
            return View(entity);
        }



        [HttpPost]
        public IActionResult Delete(Ogrenci input)
        {



            manager.Delete(input);
            return RedirectToAction("Index", "Ogrenci");


        }



    }
}
