using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UI.Web.Controllers
{
    public class ConseillerController : Controller
    {
        IServiceConseiller scons;
        public ConseillerController(IServiceConseiller scons)
        {
            this.scons = scons;
        }

        // GET: ConseillerController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ConseillerController/Details/5
        public ActionResult Details(int id)
        {
            return View(scons.GetById(id));
        }

        // GET: ConseillerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ConseillerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ConseillerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ConseillerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ConseillerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ConseillerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
