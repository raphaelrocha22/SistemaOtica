using Projeto.Entidades.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entidades
{
    public class Lente
    {
        public int idLente { get; set; }
        public Olho olho { get; set; }
        public int diametro { get; set; }
        public double valor { get; set; }

        public Dioptria dioptria { get; set; }
        public TipoLente tipoLente { get; set; }
    }
}
