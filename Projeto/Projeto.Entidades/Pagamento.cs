using Projeto.Entidades.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entidades
{
    public class Pagamento
    {
        public int idPagamento { get; set; }
        public SituacaoPagamento situacao { get; set; }
        public FormaPagamento forma { get; set; }
        public int parcelas { get; set; }

        public Pedido pedido { get; set; }
    }
}
