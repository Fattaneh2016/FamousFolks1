using FamousFolks.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace FamousFolks.Controllers
{
    public class FolksExpertisesController : Controller
    {
        private FamousFolksEntities db = new FamousFolksEntities();

        // GET: FolksExpertises
        public ActionResult Index()
        {
            return View(db.FolksExpertises.ToList());
        }

        // GET: FolksExpertises/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FolksExpertise folksExpertise = db.FolksExpertises.Find(id);
            if (folksExpertise == null)
            {
                return HttpNotFound();
            }
            return View(folksExpertise);
        }

        // GET: FolksExpertises/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FolksExpertises/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdFolkExp,ExpId,Id")] FolksExpertise folksExpertise)
        {
            if (ModelState.IsValid)
            {
                db.FolksExpertises.Add(folksExpertise);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(folksExpertise);
        }

        // GET: FolksExpertises/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FolksExpertise folksExpertise = db.FolksExpertises.Find(id);
            if (folksExpertise == null)
            {
                return HttpNotFound();
            }
            return View(folksExpertise);
        }

        // POST: FolksExpertises/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdFolkExp,ExpId,Id")] FolksExpertise folksExpertise)
        {
            if (ModelState.IsValid)
            {
                db.Entry(folksExpertise).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(folksExpertise);
        }

        // GET: FolksExpertises/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FolksExpertise folksExpertise = db.FolksExpertises.Find(id);
            if (folksExpertise == null)
            {
                return HttpNotFound();
            }
            return View(folksExpertise);
        }

        // POST: FolksExpertises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FolksExpertise folksExpertise = db.FolksExpertises.Find(id);
            db.FolksExpertises.Remove(folksExpertise);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
