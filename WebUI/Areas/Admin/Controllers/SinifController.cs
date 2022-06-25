using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Okul.BL.Abstract;
using Okul.Domain;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Admin")]
    public class SinifController : Controller
    {

        //Sadece Constructer icerisinde set edilebilir

        private readonly ISinifManager manager;

        public SinifController(ISinifManager manager)
        {

            this.manager = manager;
        }
        public IActionResult Index()
        {
            var Siniflar = manager.GetAll(null);



            return View(Siniflar);
        }


        [HttpGet]
        public IActionResult Create()
        {
            Sinif entity = new Sinif();
            return View(entity);
        }

        [HttpPost]
        public IActionResult Create(Sinif Sinif)
        {
            if (ModelState.IsValid)
            {
                //repository.Insert(Sinif);
                if (!manager.CheckForSinifName(Sinif.SinifAdi))
                {
                    manager.Add(Sinif);
                    return RedirectToAction("Index", "Sinif");

                }
                ModelState.AddModelError("", "Bu Sinif daha once tanimlanmistir.");

            }


            return View();
        }

        public IActionResult Update(int id)
        {
            var entity = manager.Find(id);
            return View(entity);
        }

        [HttpPost]
        public IActionResult Update(Sinif Sinif)
        {
            if (ModelState.IsValid)
            {
                manager.Update(Sinif);
                return RedirectToAction("Index", "Sinif");
            }

            return View();
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var entity = manager.Find(id);
            return View(entity);
        }

        [HttpPost]
        public IActionResult Delete(Sinif Sinif)
        {
            manager.Delete(Sinif);
            return RedirectToAction("Index", "Sinif");

        }
    }
}