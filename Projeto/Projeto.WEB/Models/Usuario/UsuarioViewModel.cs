using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto.WEB.Models.Usuario
{
    public class UsuarioViewModel
    {
        public int idUsuario { get; set; }
        public string nome { get; set; }
        public string login { get; set; }
        public string senha { get; set; }
        public string senhaConfirm { get; set; }
        public DateTime dataCadastro { get; set; }
        public bool ativo { get; set; }

    }
}