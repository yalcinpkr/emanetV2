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
    public class AnimalSizeController : Controller
    {
        // GET: AnimalSize
        private readonly IAnimalSizeService _animalSizeService;
        public AnimalSizeController(IAnimalSizeService animalSizeService)
        {
            _animalSizeService = animalSizeService;
        }
        public ActionResult Index()
        {
            AnimalSizeListViewModel viewModel = new AnimalSizeListViewModel()
            {
                AnimalSizes = _animalSizeService.GetAllAdmin()
            };
            return View(viewModel);

        }

        public ActionResult New()
        {
            return View();
        }
        [HttpPost]
        public ActionResult New(AnimalSizeNewViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            AnimalSize newAnimalType = new AnimalSize()
            {

                Name = viewModel.Name,
                StatusId = viewModel.StatusId

            };
            _animalSizeService.New(newAnimalType);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            var editedAnimalSize = _animalSizeService.GetAdmin(id);
            if (editedAnimalSize == null)
                return RedirectToAction("Index");

            AnimalSizeEditViewModel viewModel = new AnimalSizeEditViewModel()
            {
                Id = editedAnimalSize.Id,
                Name = editedAnimalSize.Name,
                StatusId = editedAnimalSize.StatusId,


            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Edit(AnimalSizeEditViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            // viewModel to AnimalType entity
            AnimalSize editedAnimalSize = new AnimalSize()
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                StatusId = viewModel.StatusId,
            };
            _animalSizeService.Edit(editedAnimalSize);
            return RedirectToAction("Index");

        }

        public ActionResult Publish(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            _animalSizeService.Publish(id);
            return RedirectToAction("Index");
        }

        public ActionResult Draft(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            _animalSizeService.Draft(id);
            return RedirectToAction("Index");
        }

        public ActionResult Remove(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            _animalSizeService.Remove(id);
            return RedirectToAction("Index");
        }
    }
}
