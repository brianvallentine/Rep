using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Repertorio.Models;

namespace Repertorio.Controllers
{
    public class RepertorioListsController : Controller
    {
        private RepertorioDBContext db = new RepertorioDBContext();

        // GET: RepertorioLists
        public ActionResult Index()
        {
            return View(db.RepertoriosList.ToList());
        }

        // GET: RepertorioLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepertorioList repertorioList = db.RepertoriosList.Find(id);
            if (repertorioList == null)
            {
                return HttpNotFound();
            }
            return View(repertorioList);
        }

        // GET: RepertorioLists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RepertorioLists/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DsFaixa,DsArtista,CdDificuldade")] RepertorioList repertorioList)
        {
            if (ModelState.IsValid)
            {
                db.RepertoriosList.Add(repertorioList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(repertorioList);
        }

        // GET: RepertorioLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepertorioList repertorioList = db.RepertoriosList.Find(id);
            if (repertorioList == null)
            {
                return HttpNotFound();
            }
            return View(repertorioList);
        }

        // POST: RepertorioLists/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DsFaixa,DsArtista,CdDificuldade")] RepertorioList repertorioList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(repertorioList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(repertorioList);
        }

        // GET: RepertorioLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepertorioList repertorioList = db.RepertoriosList.Find(id);
            if (repertorioList == null)
            {
                return HttpNotFound();
            }
            return View(repertorioList);
        }

        // POST: RepertorioLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RepertorioList repertorioList = db.RepertoriosList.Find(id);
            db.RepertoriosList.Remove(repertorioList);
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
