using Projeto.Entidades.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entidades
{
    public class Dioptria
    {
        public int idDioptria { get; set; }
        public double esf { get; set; }
        public double cil { get; set; }
        public double eixo { get; set; }
        public double adicao { get; set; }
        public double dnp { get; set; }
        public double altura { get; set; }
        public double prisma1 { get; set; }
        public BasePrisma base1 { get; set; }
        public double prisma2 { get; set; }
        public BasePrisma base2 { get; set; }
    }
}
