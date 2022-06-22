using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Okul.DAL.Abstract;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Admin")]
    public class SinifController : Controller
    {
        private readonly ISinifRepository repository;

        public SinifController(ISinifRepository repository)
        {
            this.repository = repository;
        }
        public IActionResult Index()
        {

            var siniflar = repository.GetAll();
            return View(siniflar);
        }
    }
}