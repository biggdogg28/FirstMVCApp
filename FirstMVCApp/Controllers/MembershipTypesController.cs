using FirstMVCApp.Models;
using FirstMVCApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FirstMVCApp.Controllers
{
    public class MembershipTypesController : Controller
    {
        private readonly MembershipTypesRespository _repository;
        public MembershipTypesController(MembershipTypesRespository respository)
        {
            _repository = respository;
        }
        public IActionResult Index()
        {
            var membershipTypes = _repository.GetMembershipTypes();
            return View("Index", membershipTypes);
        }

        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(IFormCollection collection)
        {
            MembershipTypeModel membershipType = new MembershipTypeModel();
            TryUpdateModelAsync(membershipType);
            _repository.Add(membershipType);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(Guid id)
        {
            MembershipTypeModel member = _repository.GetMembershipTypesById(id);
            return View("Edit", member);
        }

        [HttpPost]
        public IActionResult Edit(Guid id, IFormCollection collection)
        {
            MembershipTypeModel membershipType = new();
            TryUpdateModelAsync(membershipType);
            _repository.Update(membershipType);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            MembershipTypeModel membershipType = _repository.GetMembershipTypesById(id);
            return View("Delete", membershipType);
        }

        [HttpPost]
        public IActionResult Delete(Guid id, IFormCollection collection)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Details(Guid id)
        {
            MembershipTypeModel membershipType = _repository.GetMembershipTypesById(id);
            return View("Details", membershipType);
        }
    }
}
