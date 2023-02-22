using FirstMVCApp.Models;
using FirstMVCApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FirstMVCApp.Controllers
{
    public class AnnouncementsController : Controller
    {
        private readonly AnnouncementsRepository _repository;
        public AnnouncementsController(AnnouncementsRepository repository) 
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var announcements = _repository.GetAnnouncements();
            return View("Index", announcements);
        }
    }
}
