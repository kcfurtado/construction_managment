using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ConstrucaoCivil.Models;
using PagedList;
using ConstrucaoCivil.Helpers;

namespace ConstrucaoCivil.Controllers
{

    public class FuncionariosController : Controller
    {
        private ConstrucaoCivEntities db = new ConstrucaoCivEntities();

        // GET: Funcionarios
        public ActionResult Index(int page = 1, int pageSize = 7)
        {
            List<tblFuncionario> funcionarios = db.tblFuncionario.ToList();
            PagedList<tblFuncionario> model = new PagedList<tblFuncionario>(funcionarios, page, pageSize);
            return View(model);
        }

        // GET: Funcionarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblFuncionario tblFuncionario = db.tblFuncionario.Find(id);
            if (tblFuncionario == null)
            {
                return HttpNotFound();
            }
            return View(tblFuncionario);
        }

        // GET: Funcionarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Funcionarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_func,nome,bi,nif,cidade,localidade,data_nascenca,funcao,telefone,email,conta_bancaria,salario,username,password,ehAdmin")] tblFuncionario tblFuncionario)
        {
            if (ModelState.IsValid)
            {
                var passwordHasher = new CustomPasswordHasher();
                var password = tblFuncionario.password;
                tblFuncionario.password = passwordHasher.HashPassword(password);
                tblFuncionario.createdAt = DateTime.Now;
                tblFuncionario.updatedAt = DateTime.Now;
                tblFuncionario.nivel = 1;
                db.tblFuncionario.Add(tblFuncionario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblFuncionario);
        }

        // GET: Funcionarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblFuncionario tblFuncionario = db.tblFuncionario.Find(id);
            if (tblFuncionario == null)
            {
                return HttpNotFound();
            }
            return View(tblFuncionario);
        }

        // POST: Funcionarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_func,nome,bi,nif,cidade,localidade,data_nascenca,funcao,telefone,email,conta_bancaria,salario,username,password,ehAdmin,nivel")] tblFuncionario tblFuncionario)
        {
            if (ModelState.IsValid)
            {
                tblFuncionario.updatedAt = DateTime.Now;
                db.Entry(tblFuncionario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblFuncionario);
        }

        // GET: Funcionarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblFuncionario tblFuncionario = db.tblFuncionario.Find(id);
            if (tblFuncionario == null)
            {
                return HttpNotFound();
            }
            return View(tblFuncionario);
        }

        // POST: Funcionarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblFuncionario tblFuncionario = db.tblFuncionario.Find(id);
            db.tblFuncionario.Remove(tblFuncionario);
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
