using Projeto.DAL.Persistencia;
using Projeto.Entidades;
using Projeto.WEB.Models.Cliente;
using Projeto.WEB.Models.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Projeto.WEB.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}