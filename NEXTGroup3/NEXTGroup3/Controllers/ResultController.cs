using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NEXTGroup3.Controllers
{
    public class ResultController : Controller
    {
        // GET: ResultController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ResultController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ResultController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ResultController/Create
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

        // GET: ResultController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ResultController/Edit/5
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

        // GET: ResultController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ResultController/Delete/5
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
