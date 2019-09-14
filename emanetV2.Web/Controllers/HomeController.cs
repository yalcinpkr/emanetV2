using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace emanetV2.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPublicationService _publicationService;



        public HomeController(IPublicationService publicationService)
        {
            _publicationService = publicationService;
        }


        [Route]
        public ActionResult Index()
        {
            HomepageViewModel viewModel = new HomepageViewModel()
            {
                LastPublications = _publicationService.GetLastTenPublicationWeb()
            };
            return View(viewModel);
        }


        [Route("ilanlar")]

        public ActionResult PublicationList()
        {
            PublicationListViewModel viewModel = new PublicationListViewModel()
            {
                Publications = _publicationService.GetAllWeb()
            };

            return View(viewModel);
        }


        [Route("ilanlar/{publicationSlug}")]
        public ActionResult PublicationDetail(int publication)
        {
            // Find Publication via slug
            PublicationDetailViewModel viewModel = new PublicationDetailViewModel();

            return View(viewModel);
        }

        [Route("hakkimizda")]
        public ActionResult About()
        {
            return View();
        }

        [Route("iletisim")]
        public ActionResult Contact()
        {
            return View();
        }
    }
}