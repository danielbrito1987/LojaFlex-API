using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaFlex.Domain.Models
{
    public class Familia
    {
        public int IdFamilia { get; set; }
        public string DscFamilia { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }
    }
}
