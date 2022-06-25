using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Okul.BL.Abstract;
using Okul.Domain;
using System.Collections.Generic;
using WebUI.Areas.Admin.Models.Dtos;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class OgretmenController : Controller
    {
        private readonly IOgretmenManager manager;
        private readonly IMapper mapper;
        private readonly IBransManager BransManager;

        public OgretmenController(IOgretmenManager manager, IMapper mapper, IBransManager BransManager)
        {
            this.manager = manager;
            this.mapper = mapper;
            this.BransManager = BransManager;
        }
        public IActionResult Index()
        {
            var Ogretmenler = manager.GetAll(null);
            return View(Ogretmenler);
        }


        [HttpGet]
        public IActionResult Create()
        {
            var Ogretmen = new OgretmenCreateDto();
            var Branslar = BransManager.GetAll(null);
            List<BransModel> BranslarSelecList = new();
            foreach (var item in Branslar)
            {
                BranslarSelecList.Add(new BransModel { BransId = item.Id, BransAdi = item.BransAdi });
            }

            ViewBag.Branslar = new SelectList(BranslarSelecList, "BransId", "BransAdi");
            return View(Ogretmen);
        }

        [HttpPost]
        public IActionResult Create(OgretmenCreateDto input)
        {
            if (ModelState.IsValid)
            {
                // Amele yontem 

                //Ogretmen Ogretmen = new Ogretmen();
                //Ogretmen.Adi= input.Adi;
                //Ogretmen.Soyadi = input.Soyadi;
                var Ogretmen = mapper.Map<OgretmenCreateDto, Ogretmen>(input);


                manager.Add(Ogretmen);
                RedirectToAction("Index", "Ogretmen");
            }
            return View();
        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            var Ogretmen = manager.Find(id);
            var updateDto = mapper.Map<Ogretmen, OgretmenCreateDto>(Ogretmen);

            var Branslar = BransManager.GetAll(null);
            List<BransModel> BransModels = new();
            foreach (var item in Branslar)
            {
                BransModels.Add(new BransModel { BransId = item.Id, BransAdi = item.BransAdi });
            }

            var BransSelectList = new SelectList(BransModels, "BransId", "BransAdi");

            ViewBag.Branslar = BransSelectList;
            return View(updateDto);
        }



        [HttpPost]
        public IActionResult Update(OgretmenCreateDto input)
        {

            if (ModelState.IsValid)
            {
                var Ogretmen = mapper.Map<OgretmenCreateDto, Ogretmen>(input);

                manager.Update(Ogretmen);
                return RedirectToAction("Index", "Ogretmen");


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
        public IActionResult Delete(Ogretmen input)
        {



            manager.Delete(input);
            return RedirectToAction("Index", "Ogretmen");


        }



    }
}
