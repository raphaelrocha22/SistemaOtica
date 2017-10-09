using Projeto.Entidades.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entidades
{
    public class Pedido
    {
        public int idPedido { get; set; }
        public DateTime dataPedido { get; set; }
        public DateTime dataPrevistaEntrega { get; set; }
        public DateTime dataEntrega { get; set; }
        public StatusPedido statusPedido { get; set; }

        public Pagamento pagamento { get; set; }
        public Armacao armacao { get; set; }
        public Montagem montagem { get; set; }
        public Cliente cliente { get; set; }
        public Antirreflexo antirreflexo { get; set; }
        public Coloracao coloracao { get; set; }
        public List<Lente> lente { get; set; }
    }
}
