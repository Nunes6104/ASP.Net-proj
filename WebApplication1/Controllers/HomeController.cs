using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Aula_1()
        {
            ViewBag.escola = "Istec";
            ViewData["turma"] = "Turma A";
            TempData["disciplina"] = "Tecnologias de Internet III";

            Aluno ze = new Aluno() {Num = 1, Nome = "Zé", Turma = "A" };
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