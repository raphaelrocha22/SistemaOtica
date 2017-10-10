using Projeto.DAL.Persistencia;
using Projeto.Entidades;
using Projeto.WEB.Models.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeto.WEB.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastro(ClienteViewModel model)
        {
            try
            {
                var c = new Cliente();
                c.endereco = new Endereco();
                c.telefones = new List<Telefone>();

                c.nome = model.nome;
                c.email = model.email;
                c.dataCadastro = DateTime.Now;
                c.cpfCnpj = model.cpfCnpj;
                c.tipoCliente = model.tipo;

                c.endereco.rua = model.rua;
                c.endereco.numero = model.numero;
                c.endereco.complemento = model.complemento;
                c.endereco.bairro = model.bairro;
                c.endereco.cidade = model.cidade;
                c.endereco.estado = model.estado;
                c.endereco.cep = model.cep;

                var t = new Telefone();
                t.ddd = model.ddd;
                t.numero = model.telefone;

                c.telefones.Add(t);

                var d = new ClienteDAL();
                d.Cadastrar(c);

                ViewBag.Mensagem = "Cliente cadastrado com sucesso";

            }
            catch (Exception e)
            {
                ViewBag.Mensagem = $"Erro: {e.Message}";
            }

            return View(new ClienteViewModel());
        }

        public ActionResult Consulta()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Consulta(ClienteViewModel model)
        {
            
            var lista = new List<ClienteViewModel>();

            try
            {
                var c = new Cliente();
                c.endereco = new Endereco();

                c.idCliente = model.idCliente;
                c.nome = model.nome;
                c.email = model.email;
                c.cpfCnpj = model.cpfCnpj;
                c.endereco.bairro = model.bairro;

                var d = new ClienteDAL();
                foreach (var item in d.Consultar(c))
                {
                    var m = new ClienteViewModel();
                    m.idCliente = item.idCliente;
                    m.nome = item.nome;
                    m.email = item.email;
                    m.tipo = item.tipoCliente;
                    m.cpfCnpj = item.cpfCnpj;
                    m.bairro = item.endereco.bairro;

                    lista.Add(m);
                }               

            }
            catch (Exception e)
            {
                throw;
            }

            return PartialView("_Consulta",lista);
        }
    }
}