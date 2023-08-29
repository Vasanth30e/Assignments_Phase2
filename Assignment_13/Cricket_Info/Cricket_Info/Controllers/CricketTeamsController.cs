using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cricket_Info.Data;
using Cricket_Info.Models;

namespace Cricket_Info.Controllers
{
    public class CricketTeamsController : Controller
    {
        private CricketTeamDbContext db = new CricketTeamDbContext();

        // GET: CricketTeams
        public ActionResult Index()
        {
            return View(db.CricketTeams.ToList());
        }

        // GET: CricketTeams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CricketTeam cricketTeam = db.CricketTeams.Find(id);
            if (cricketTeam == null)
            {
                return HttpNotFound();
            }
            return View(cricketTeam);
        }

        // GET: CricketTeams/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CricketTeams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Team,NOWC")] CricketTeam cricketTeam)
        {
            if (ModelState.IsValid)
            {
                db.CricketTeams.Add(cricketTeam);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cricketTeam);
        }

        // GET: CricketTeams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CricketTeam cricketTeam = db.CricketTeams.Find(id);
            if (cricketTeam == null)
            {
                return HttpNotFound();
            }
            return View(cricketTeam);
        }

        // POST: CricketTeams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Team,NOWC")] CricketTeam cricketTeam)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cricketTeam).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cricketTeam);
        }

        // GET: CricketTeams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CricketTeam cricketTeam = db.CricketTeams.Find(id);
            if (cricketTeam == null)
            {
                return HttpNotFound();
            }
            return View(cricketTeam);
        }

        // POST: CricketTeams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CricketTeam cricketTeam = db.CricketTeams.Find(id);
            db.CricketTeams.Remove(cricketTeam);
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
