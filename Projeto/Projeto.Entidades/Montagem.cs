using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entidades
{
    public class Montagem
    {
        public int idMontagem { get; set; }
        public double valor { get; set; }

        public Armacao armacao { get; set; }
    }
}
