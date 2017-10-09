using Projeto.DAL.Persistencia;
using Projeto.Entidades;
using Projeto.Entidades.Enum;
using Projeto.WEB.Models.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeto.WEB.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(ClienteViewModel model)
        {
            try
            {

                var c = new Cliente();
                c.endereco = new Endereco();
                c.telefones = new List<Telefone>();

                c.nome = model.nome;
                c.email = model.email;
                c.dataCadastro = model.dataCadastro;
                c.cpfCnpj = model.cpfCnpj;
                c.tipo = model.tipo;

                c.endereco.rua = model.rua;
                c.endereco.numero = model.numero;
                c.endereco.complemento = model.complemento;
                c.endereco.bairro = model.bairro;
                c.endereco.cidade = model.cidade;
                c.endereco.estado = model.estado;
                c.endereco.pais = model.pais;
                c.endereco.cep = model.cep;

                var t = new Telefone();
                t.ddd = model.ddd;
                t.numero = model.telefone;

                c.telefones.Add(t);

                var d = new ClienteDAL();
                d.Cadastrar(c);

            }
            catch (Exception e)
            {

                throw;
            }

            return View();
        }
    }
}