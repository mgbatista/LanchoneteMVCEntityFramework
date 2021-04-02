using LanchoneteMVC2.Dal;
using LanchoneteMVC2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LanchoneteMVC2.Controllers
{
    public class RefeicaoController : Controller
    {
        private LanchoneteContext db = new LanchoneteContext();
        // GET: Refeicao
        //Lista Refeições
        public ActionResult Index()
        {
            return View(db.Refeicoes.ToList());
        }

        //Cadastra Refeição
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Refeicao  refeicao)
        {
            if (ModelState.IsValid)
            {
                db.Refeicoes.Add(refeicao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(refeicao);
        }

        ///Edita Refeicao e puxa por pk
        public ActionResult Edit(int id)
        {
            return View(db.Refeicoes.First(d => d.Id == id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Refeicao refeicao)
        {
            if (ModelState.IsValid)
            {
                Refeicao refeicaoUpdate = db.Refeicoes.First(d => d.Id == refeicao.Id);
                refeicaoUpdate.Descricao = refeicao.Descricao;
                refeicaoUpdate.Valor = refeicao.Valor;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(refeicao);
        }

        //Detalhes de um certo cadastro puxa pela primary key (id)
        public ActionResult Details(int id)
        {
            return View(db.Refeicoes.First(d => d.Id == id));
        }

        //Deleta puxa pela primary key (id)
        public ActionResult Delete(int id)
        {
            return View(db.Refeicoes.First(d => d.Id == id));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            var refeicao = db.Refeicoes.First(d => d.Id == id);
            db.Refeicoes.Remove(refeicao);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}