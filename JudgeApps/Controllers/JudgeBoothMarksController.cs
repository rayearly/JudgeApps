using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JudgeApps.Models;
using JudgeApps.ViewModel;

namespace JudgeApps.Controllers
{
    public class JudgeBoothMarksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JudgeBoothMarksController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: JudgeBoothMarks
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BoothAssignment(int id)
        {
            var judge = _context.Judges.Single(j => j.Id == id);

            var viewModel = new JudgeBoothMarkViewModel
            {
                Judge = judge,
                JudgeBoothMarks = _context.JudgeBoothMark.ToList(),
                Booths = _context.Booths.ToList()
            };

            return View("BoothAssignmentForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Judge judge)
        {
            var viewModel = new JudgeBoothMarkViewModel
            {
                Judge = judge,
                JudgeBoothMarks = _context.JudgeBoothMark.ToList(),
                Booths = _context.Booths.ToList()
            };

            if (!ModelState.IsValid)
            {
                return View("BoothAssignmentForm", viewModel);
            }

            if (judge.Id == 0)
            {
                _context.Judges.Add(judge);
            }
            else
            {
                foreach (var booth in judge.JudgeBoothMark)
                {
                    booth.JudgeId = judge.Id;
                    _context.JudgeBoothMark.Add(booth);
                }
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Judges");
        }

        public PartialViewResult DropDownBoothPartialViewResult()
        {
            return PartialView("_DropDownBooth", new JudgeBoothMarkViewModel());
        }
    }
}