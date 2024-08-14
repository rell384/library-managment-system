using library_managment_system.Models;
using library_managment_system.Repository;
using Microsoft.AspNetCore.Mvc;

namespace library_managment_system.Controllers
{
    public class PersonController : Controller
    {
        IPersonRepo _PersonRepo;
        public PersonController(IPersonRepo PersonRepo)
        {
            _PersonRepo = PersonRepo;
        }
        // GET: Person/AddPerson
        public ActionResult AddPerson()
        {
            return View();
        }

        // POST: Person/AddPerson
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPerson(Person model)
        {
            if (ModelState.IsValid)
            {
                _PersonRepo.Insert(model);

                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
    }
}
