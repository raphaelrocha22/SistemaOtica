using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entidades
{
    public class Armacao
    {
        public int idArmacao { get; set; }
        public string modelo { get; set; }
        public string marca { get; set; }
        public string referecia { get; set; }
        public double horizontal { get; set; }
        public double vertical { get; set; }
        public double diagonalMaior { get; set; }
        public double ponte { get; set; }
        public double valor { get; set; }
    }
}
