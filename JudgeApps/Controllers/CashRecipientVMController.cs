using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JudgeApps.Models;

namespace JudgeApps.Controllers
{
    public class CashRecipientVmController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CashRecipientVmController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: CashRecipientVM
        public ActionResult Index()
        {
            var recipient = _context.CashRecipientVms.ToList();
            return View(recipient);
        }

        // GET: CashRecipientVM/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CashRecipientVM/Create
        public ActionResult Create()
        {
            List<CashRecipientVm> model = new List<CashRecipientVm>();
            // add any existing objects that your editing
            model = _context.CashRecipientVms.ToList();
            return View(model);
        }

        // POST: CashRecipientVM/Create
        [HttpPost]
        public ActionResult Create(IEnumerable<CashRecipientVm> recipients)
        {
            try
            {
                // TODO: Add insert logic here


                foreach (var r in recipients)
                {
                    _context.CashRecipientVms.Add(r);
                }

                _context.SaveChanges();
                List<CashRecipientVm> model = new List<CashRecipientVm>();
                // add any existing objects that your editing
                model = _context.CashRecipientVms.ToList();
                return View("Index", model);
            }
            catch
            {
                return HttpNotFound();
            }
        }

        // GET: CashRecipientVM/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CashRecipientVM/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CashRecipientVM/Delete/5
        public ActionResult Delete(int id)
        {

            CashRecipientVm model = _context.CashRecipientVms.Find(id);
            
            return View("Index", model);
        }

        // POST: CashRecipientVM/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                CashRecipientVm remove = _context.CashRecipientVms.Find(id);
                _context.CashRecipientVms.Remove(remove);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Index");
            }
        }

        public PartialViewResult Recipient()
        {
            return PartialView("_Recipient", new CashRecipientVm());
        }
    }
}
