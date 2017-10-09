using Projeto.Entidades.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entidades
{
    public class TipoLente
    {
        public int idTipoLente { get; set; }
        public TipoProducao tipoProducao { get; set; }
        public TipoVisao tipoVisao { get; set; }
        public Material material { get; set; }
        public string descricao { get; set; }
        public string indice { get; set; }
    }
}
