using Microsoft.AspNetCore.Mvc;
using Okul.BL.Abstract;
using Okul.Domain;
namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BransController : Controller
    {

        //Sadece Constructer icerisinde set edilebilir

        private readonly IBransManager manager;

        public BransController(IBransManager manager)
        {

            this.manager = manager;
        }
        public IActionResult Index()
        {
            var branslar = manager.GetAll(null);

            //ViewBag.Urunler = new List<Urun> { new Urun {Id=1 ,Fiyat=10,UrunAdi="Elma" },
            //                                    new Urun {Id=1 ,Fiyat=10,UrunAdi="Armut" },
            //                                    new Urun {Id=1 ,Fiyat=10,UrunAdi="Seftali" },
            //                                      new Urun {Id=1 ,Fiyat=10,UrunAdi="Karpuz" }}; 



            return View(branslar);
        }


        [HttpGet]
        public IActionResult Create()
        {
            Brans entity = new Brans();
            return View(entity);
        }

        [HttpPost]
        public IActionResult Create(Brans brans)
        {
            if (ModelState.IsValid)
            {
                //repository.Insert(brans);
                if (!manager.CheckForBransName(brans.BransAdi))
                {
                    manager.Add(brans);
                    return RedirectToAction("Index", "Brans");

                }
                ModelState.AddModelError("", "Bu brans daha once tanimlanmistir.");

            }


            return View();
        }

        public IActionResult Update(int id)
        {
            var entity = manager.Find(id);
            return View(entity);
        }

        [HttpPost]
        public IActionResult Update(Brans brans)
        {
            if (ModelState.IsValid)
            {
                manager.Update(brans);
                return RedirectToAction("Index", "Brans");
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
        public IActionResult Delete(Brans brans)
        {
            manager.Delete(brans);
            return RedirectToAction("Index", "Brans");

        }
    }
}
