using Projeto.Entidades.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entidades
{
    public class Coloracao
    {
        public int idColoracao { get; set; }
        public TipoColoracao tipo { get; set; }
        public string cor { get; set; }
        public double valor { get; set; }
    }
}
