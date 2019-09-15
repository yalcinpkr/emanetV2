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
    public class PublicationController : Controller
    {
        // GET: Publication
        private readonly IPublicationService _publicationService;
        private readonly IAnimalSizeService _animalSizeService;
        private readonly IAnimalTypeService _animalTypeService;

        public PublicationController(IPublicationService publicationService, IAnimalSizeService animalSizeService, IAnimalTypeService animalTypeService)
        {
            _publicationService = publicationService;
            _animalSizeService = animalSizeService;
            _animalTypeService = animalTypeService;
        }

        public ActionResult Index()
        {
            PublicationListViewModel viewModel = new PublicationListViewModel()
            {
                Publications = _publicationService.GetAllAdmin()
            };
            return View(viewModel);
        }
        public ActionResult Edit(int? id)
        {
            ViewBag.AnimalSizeId = new SelectList(_animalSizeService.GetAllWeb(), "Id", "Name");
            ViewBag.AnimalTypeId = new SelectList(_animalTypeService.GetAllWeb(), "Id", "Name");

            if (id == null)
                return RedirectToAction("Index");
            var editedPublication = _publicationService.GetAdmin(id);
            if (editedPublication == null)
                return RedirectToAction("Index");

            PublicationEditViewModel viewModel = new PublicationEditViewModel()
            {
                Id = editedPublication.Id,
                Title = editedPublication.Title,
                Description = editedPublication.Description,
                Slug = editedPublication.Slug,
                Note = editedPublication.Note,
                AnimalSizeId = editedPublication.AnimalSizeId,
                AnimalTypeId = editedPublication.AnimalTypeId,
                StatusId = editedPublication.StatusId,

            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Edit(PublicationEditViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            // viewModel to Publication entity
            Publication editedPublication = new Publication()
            {
                Id = viewModel.Id,
                Title = viewModel.Title,
                Description = viewModel.Description,
                Slug = viewModel.Slug,
                Note = viewModel.Note,
                AnimalSizeId = viewModel.AnimalSizeId,
                AnimalTypeId = viewModel.AnimalTypeId,
                StatusId = viewModel.StatusId,
            };
            _publicationService.Edit(editedPublication);
            return RedirectToAction("Index");

        }


        public ActionResult Publish(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            _publicationService.Publish(id);
            return RedirectToAction("Index");
        }

        public ActionResult Draft(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            _publicationService.Draft(id);
            return RedirectToAction("Index");
        }

        public ActionResult Remove(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            _publicationService.Remove(id);
            return RedirectToAction("Index");
        }
    }
}