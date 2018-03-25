using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JudgeApps.Models;
using JudgeApps.ViewModel;

namespace JudgeApps.Controllers
{
    public class JudgesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JudgesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Judge
        public ActionResult Index()
        {
            var judges = _context.Judges.ToList();
            return View(judges);
        }

        public ActionResult New()
        {
            var judges = new Judge();
            return View("JudgeForm", judges);
        }

        public ActionResult Edit(int id)
        {
            var judge = _context.Judges.SingleOrDefault(m => m.Id == id);

            if (judge == null)
                return HttpNotFound();

            return View("JudgeForm", judge);
        }

        //public Action AssignBooth - cannot use New since different field. viewModel maybe? - judge, booth

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Judge judge)
        {
            //var jury = _context.Judges.SingleOrDefault(j => j.Id == judge.Id);

            if (!ModelState.IsValid)
            {
                return View("JudgeForm", judge);
            }

            if (judge.Id == 0)
            {
                _context.Judges.Add(judge);
            }

            else
            {
                var juryInDb = _context.Judges.Single(j => j.Id == judge.Id);

                juryInDb.Title = judge.Title;
                juryInDb.Name = judge.Name;
                juryInDb.Affiliation = judge.Affiliation;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Judges");
        }

        public ActionResult Details(int id)
        {
            var judge = _context.Judges.Single(j => j.Id == id);

            var viewModel = new JudgeBoothMarkViewModel
            {
                Judge = judge,
                JudgeBoothMarks = _context.JudgeBoothMark.ToList(),
                Booths = _context.Booths.ToList()
            };
            return View(viewModel);
        }

    }
}