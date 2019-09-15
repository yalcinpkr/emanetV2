using emanetV2.Admin.Models;
using emanetV2.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace emanetV2.Admin.Controllers
{
    [Authorize]
    public class MemberController : Controller
    {
        // GET: Member
        private readonly IMemberService _memberService;
        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;

        }
        public ActionResult Index()
        {
            MemberListViewModel viewModel = new MemberListViewModel()
            {
                Members = _memberService.GetAllAdmin()
            };
            return View(viewModel);
        }
        public ActionResult Publish(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            _memberService.Publish(id);
            return RedirectToAction("Index");
        }

        public ActionResult Draft(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            _memberService.Draft(id);
            return RedirectToAction("Index");
        }

        public ActionResult Remove(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            _memberService.Remove(id);
            return RedirectToAction("Index");
        }
    }
}