using Projeto.Entidades.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entidades
{
    public class Cliente
    {
        public int idCliente { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public DateTime dataCadastro { get; set; }
        public string cpfCnpj { get; set; }
        public TipoCliente tipoCliente { get; set; }

        public Endereco endereco { get; set; }
        public List<Telefone> telefones { get; set; }

    }
}
