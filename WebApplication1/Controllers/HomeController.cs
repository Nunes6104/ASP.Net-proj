using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult EditAluno(int ? num)
        {
            BD bd= new BD();
            Aluno aluno = bd.GetAlunos().Where(x => x.Num == (num?? -1)).FirstOrDefault();
            if (aluno != null)
            {
                return View(aluno);
            }
            else
            {
                return RedirectToAction("Alunos", new { message = "Num não existe" });
            }
        }
        [HttpPost]
        public ActionResult EditAluno(Aluno editado)
        {
                BD bd = new BD();
                Aluno aluno = bd.GetAlunos().Where(x => x.Num == editado.Num).FirstOrDefault();
                if (aluno != null)
                {
                    aluno.Nome = editado.Nome;
                    aluno.Turma = editado.Turma;
                    bd.gravar();
                    return RedirectToAction("Alunos", new { message = "Alterado com sucesso" });
                }
                else
                {
                    return RedirectToAction("Alunos", new { message = "Num não existe" });
                }
        }

        public ActionResult DeleteAluno(int ? num)
        {
            BD bd = new BD();
            Aluno del = bd.GetAlunos().Where(x => x.Num == (num ?? - 1)).FirstOrDefault();
            if (del != null)
            {
                return View(del);
            }
            else
            {
                return RedirectToAction("Alunos", new { message = "Num não existe" });
            }
        }
        [HttpPost]
        [ActionName("DeleteAluno")]
        public ActionResult Delete(int? num)
        {
            BD bd = new BD();
            Aluno del = bd.GetAlunos().Where(x => x.Num == (num ?? -1)).FirstOrDefault();
            if (del != null)
            {
                bd.GetAlunos().Remove(del);
                bd.gravar();
                return RedirectToAction("Alunos", new { message = "Apagado com sucesso" });
            }
            else
            {
                return RedirectToAction("Alunos", new { message = "Num não existe" });
            }
        }

        public ActionResult CreateAluno()
        {
            List<Turma> turmas = new List<Turma>() 
            {
                new Turma() { clsTurma = "A" },
                new Turma() { clsTurma = "B" },
                new Turma() { clsTurma = "C" },
                new Turma()  {clsTurma = "D" }
            };
            ViewBag.turmas = new SelectList(turmas, "clsTurma", "clsTurma");
            Aluno aluno = new Aluno();
            return View(aluno);
        }
        [HttpPost]
        public ActionResult CreateAluno(Aluno novo)
        {
            List<Turma> turmas = new List<Turma>()
            {
                new Turma() { clsTurma = "A" },
                new Turma() { clsTurma = "B" },
                new Turma() { clsTurma = "C" },
                new Turma()  {clsTurma = "D" }
            };
            ViewBag.turmas = new SelectList(turmas, "clsTurma", "clsTurma");

            if (ModelState.IsValid)
            {
                BD bd = new BD();
                bd.GetAlunos().Add(novo);
                bd.gravar();
                return RedirectToAction("Alunos", new { message = "Registo Inserido com sucesso" });
            }
            else return View(novo);
        }

        public ActionResult DetailsAluno(int? num)
        {
            BD bd = new BD();
            Aluno aluno = bd.GetAlunos().Where(x => x.Num == (num ?? -1)).FirstOrDefault();
            if (aluno != null)
            {
                return View(aluno);
            }
            else
            {
                return RedirectToAction("Alunos", new { message = "Num não existe" });
            }
        }
        public ActionResult Alunos(String message)
        {
            ViewBag.message = message;
            BD bd = new BD();
            List<Aluno> alunos = bd.GetAlunos();
            return View(alunos);
        }

        public ActionResult Exames(int ? num)
        {
            BD bd = new BD();
            List<Exam> exames = bd.GetExames();
            if (num != null)
            {
                exames = exames.Where(x => x.Num == (num ?? -1)).ToList<Exam>();
            }
            return PartialView(exames);
        }

        public ActionResult Dobro(int ? num)
        {
            return Json(new { Dobro = 2 * num ?? 0 }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Aula_1()
        {
            ViewBag.escola = "Istec";
            ViewData["turma"] = "Turma A";
            TempData["disciplina"] = "Tecnologias de Internet III";

            Aluno ze = new Aluno() {Num = 1, Nome = "Zé", Turma = "A" };
            return View(ze);
        }

        [HttpPost]
        public ActionResult Aula_1(int? txtnum)
        {
            Aluno ze = new Aluno() { Num = 1, Nome = "Zé", Turma = "A" };
            ViewBag.dobro = 2 * txtnum ?? 0;
            return View(ze);
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}