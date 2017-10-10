using Projeto.DAL.Persistencia;
using Projeto.Entidades;
using Projeto.WEB.Models.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Projeto.WEB.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastro(UsuarioViewModel model)
        {
            try
            {
                var u = new Usuario();
                u.nome = model.nome;
                u.login = model.login;
                u.senha = model.senhaConfirm;
                u.dataCadastro = DateTime.Now;
                u.ativo = true;

                var d = new UsuarioDAL();
                d.Cadastrar(u);

                ViewBag.Mensagem = "Usuario cadastrado com sucesso";

            }
            catch (Exception e)
            {

                ViewBag.Mensagem = "Erro não esperado, por favor entre em contato com o administrador do sistema. Erro: " + e.Message;
            }

            return View(new UsuarioViewModel());
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UsuarioViewModel model)
        {
            try
            {
                var d = new UsuarioDAL();
                Usuario u = d.Consultar(model.login, model.senha);

                if (u != null)
                {
                    var ticket = new FormsAuthenticationTicket(u.nome, false, 60);
                    var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));
                    Response.Cookies.Add(cookie);

                    Session.Add("usuario", u);

                    return RedirectToAction("Index", "Sistema", new { area = "AreaRestrita" });
                }
                else
                {
                    ViewBag.Mensagem = "Acesso negado, usuário ou senha incorretos";
                }

            }
            catch (Exception e)
            {
                ViewBag.Mensagem = "Erro não esperado, por favor entre em contato com o administrador do sistema. Erro: " + e.Message;
            }

            return View();
        }

    }
}