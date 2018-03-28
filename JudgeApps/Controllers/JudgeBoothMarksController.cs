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
        public ActionResult Save(Judge jvm, int id)
        {
            var viewModel = new JudgeBoothMarkViewModel
            {
                Judge = jvm,
                JudgeBoothMarks = _context.JudgeBoothMark.ToList(),
                Booths = _context.Booths.ToList()
            };

            if (!ModelState.IsValid)
            {
                return View("BoothAssignmentForm", viewModel);
            }

            if (jvm.Id == 0)
            {
                //_context.JudgeBoothMark.Add(jvm);
            }
            else
            {
                
                //foreach (var booth in jvm.Booths)
                //{
                    //var i = 0;
                   // while (i < jvm.Booths.Count)
                   // {
                        // Add booths into judgeboothmarks booth
                    //    jvm.JudgeBoothMarks[i].Booth = booth;
                    //}
                    
                //}

                foreach (var booth in jvm.JudgeBoothMark)
                {
                    booth.JudgeId = jvm.Id;
                    //booth.BoothId = 3;
                    _context.JudgeBoothMark.Add(booth);
                }
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Judges");
        }

        private void LoadPossibleRoles()
        {
            var availableRoles = _context.Booths.ToList();

            var selectItems = new List<SelectListItem>();

            foreach (var role in availableRoles)
            {
                var listItem = new SelectListItem();
                listItem.Value = role.Id.ToString();
                listItem.Text = role.BoothId;
                selectItems.Add(listItem);
            }
            ViewBag.PossibleRoles = selectItems;
        }


        public ActionResult DropDownBoothPartialViewResult()
        {
            //var viewModel = new JudgeBoothMarkViewModel
            //{
            //JudgeBoothMarks = _context.JudgeBoothMark.ToList(),
            //Booths = _context.Booths.ToList()
            //};
            LoadPossibleRoles();
            return PartialView("_DropDownBooth", new Booth());
        }
    }
}