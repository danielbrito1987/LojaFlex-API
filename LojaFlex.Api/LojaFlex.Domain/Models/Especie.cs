using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaFlex.Domain.Models
{
    public class Especie
    {
        public int IdEspecie { get; set; }
        public string DscEspecie { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }
    }
}
