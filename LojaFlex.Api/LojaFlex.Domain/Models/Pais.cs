using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaFlex.Domain.Models
{
    public class Pais
    {
        public int IdPais { get; set; }
        public string DscPais { get; set; }
        public string? Sigla { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }
    }
}
