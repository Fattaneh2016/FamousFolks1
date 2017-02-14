using FamousFolks.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace FamousFolks.Controllers
{
    public class FolksController : Controller
    {
        private FamousFolksEntities db = new FamousFolksEntities();

        // GET: Folks
        public ActionResult Index(string searchTerm = null)
        {

            //var innerJoinResult = db.Folks.Join(// outer sequence 
            //          db.Expertises,  // inner sequence 
            //          str1 => str1,    // outerKeySelector
            //          str2 => str2,  // innerKeySelector
            //          (str1, str2) => str1);

            //foreach (var str in innerJoinResult)
            //{
            //    Console.WriteLine("{0} ", str);
            //}



            //var query = db.Folks
            //    .Where(r => searchTerm == null || r.LastName.StartsWith(searchTerm))
            //    .OrderBy(r => r.LastName)
            //    .Take(100)
            //.Select(r => new FolksListViewModel
            //{
            //    Id = r.ID,
            //    FirstName = r.FirstName,
            //    LastName = r.LastName,
            //    BirthLocation = r.BirthLocation,
            //    Bio = r.Bio,
            //    FolkCount = r.Expertises.Count()
            //});


            var query = db.Folks
                .Where(r => searchTerm == null || r.LastName.StartsWith(searchTerm))
                .OrderBy(r => r.LastName)
                .Take(100)
            .Select(r => new FolksListViewModel
            {
                Id = r.ID,
                FirstName = r.FirstName,
                LastName = r.LastName,
                BirthLocation = r.BirthLocation,
                Bio = r.Bio
            });

            return View(query);

            //return View(db.Folks.ToList());

        }



        // GET: Folks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Folk folk = db.Folks.Find(id);
            if (folk == null)
            {
                return HttpNotFound();
            }
            return View(folk);
        }

        // GET: Folks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Folks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,BirthLocation,Bio")] Folk folk)
        {
            if (ModelState.IsValid)
            {
                db.Folks.Add(folk);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(folk);
        }

        // GET: Folks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Folk folk = db.Folks.Find(id);
            if (folk == null)
            {
                return HttpNotFound();
            }
            return View(folk);
        }

        // POST: Folks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,BirthLocation,Bio")] Folk folk)
        {
            if (ModelState.IsValid)
            {
                db.Entry(folk).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(folk);
        }

        // GET: Folks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Folk folk = db.Folks.Find(id);
            if (folk == null)
            {
                return HttpNotFound();
            }
            return View(folk);
        }

        // POST: Folks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Folk folk = db.Folks.Find(id);
            db.Folks.Remove(folk);
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
