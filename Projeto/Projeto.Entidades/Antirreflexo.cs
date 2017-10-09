using Projeto.Entidades.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entidades
{
    public class Antirreflexo
    {
        public int idAntirreflexo { get; set; }
        public TipoAntirreflexo tipo { get; set; }
        public double valor { get; set; }
    }
}
