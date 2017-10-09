using Projeto.Entidades.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto.WEB.Models.Cliente
{
    public class ClienteViewModel
    {
        public string nome { get; set; }
        public string email { get; set; }
        public DateTime dataCadastro { get; set; }
        public string cpfCnpj { get; set; }
        public TipoCliente tipo { get; set; }

        public string rua { get; set; }
        public string numero { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }
        public string pais { get; set; }
        public string cep { get; set; }

        public int ddd { get; set; }
        public int telefone { get; set; }
    }
}