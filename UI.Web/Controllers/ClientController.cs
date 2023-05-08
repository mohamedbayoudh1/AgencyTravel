using ApplicationCore.Domain;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UI.Web.Controllers
{
    public class ClientController : Controller
    {
        IServiceClient sc;
        IServiceConseiller scons;
        public ClientController(IServiceClient sc, IServiceConseiller scons)
        {
            this.sc = sc;
            this.scons = scons;
        }

        // GET: ClientController
        public ActionResult Index(string login)
        {
            if(login== null)
            return View(sc.GetMany());
            else
                return View(sc.GetMany(c=>c.Login.Contains(login)));
        }

        // GET: ClientController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClientController/Create
        public ActionResult Create()
        {
            ViewBag.ConseillerFk = new SelectList(scons.GetMany(), "ConseillerId", "Prenom");
            return View();
        }

        // POST: ClientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Client collection,IFormFile PhotoImg)
        {
            try
            {
                //Sauvegarder l'image
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", PhotoImg.FileName);
                Stream stream = new FileStream(path, FileMode.Create);
                PhotoImg.CopyTo(stream);
                collection.Photo = PhotoImg.FileName;

                //Sauvegarder la collection
                sc.Add(collection);
                sc.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClientController/Edit/5
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

        // GET: ClientController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClientController/Delete/5
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
