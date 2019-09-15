using emanetV2.Admin.Models;
using emanetV2.Model;
using emanetV2.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace emanetV2.Admin.Controllers
{
    [Authorize]
    public class AnimalTypeController : Controller
    {
        // GET: AnimalType
        private readonly IAnimalTypeService _animalTypeService;

        public AnimalTypeController(IAnimalTypeService animalTypeService)
        {
            _animalTypeService = animalTypeService;
        }
        public ActionResult Index()
        {
            AnimalTypeListViewModel viewModel = new AnimalTypeListViewModel()
            {
                AnimalTypes = _animalTypeService.GetAllAdmin()
            };
            return View(viewModel);

        }

        public ActionResult New()
        {

            return View();
        }
        [HttpPost]
        public ActionResult New(AnimalTypeNewViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            AnimalType newAnimalType = new AnimalType()
            {

                Name = viewModel.Name,
                StatusId = viewModel.StatusId

            };
            _animalTypeService.New(newAnimalType);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            var editedAnimalType = _animalTypeService.GetAdmin(id);
            if (editedAnimalType == null)
                return RedirectToAction("Index");

            AnimalTypeEditViewModel viewModel = new AnimalTypeEditViewModel()
            {
                Id = editedAnimalType.Id,
                Name = editedAnimalType.Name,
                StatusId = editedAnimalType.StatusId,

            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Edit(AnimalTypeEditViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            // viewModel to AnimalType entity
            AnimalType editedAnimalType = new AnimalType()
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                StatusId = viewModel.StatusId,
            };
            _animalTypeService.Edit(editedAnimalType);
            return RedirectToAction("Index");

        }

        public ActionResult Publish(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            _animalTypeService.Publish(id);
            return RedirectToAction("Index");
        }

        public ActionResult Draft(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            _animalTypeService.Draft(id);
            return RedirectToAction("Index");
        }

        public ActionResult Remove(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            _animalTypeService.Remove(id);
            return RedirectToAction("Index");
        }
    }
}