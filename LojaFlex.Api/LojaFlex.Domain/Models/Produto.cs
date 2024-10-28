using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaFlex.Domain.Models
{
    public class Produto
    {
        public int IdProduto { get; set; }
        public int Sku { get; set; }
        public string NomeProduto { get; set; }
        public string? DscProduto { get; set; }
        public string? DscColetor { get; set; }
        public string? DscLugar { get; set; }
        public string? DscColeta { get; set; }
        public string? Qualidade { get; set; }
        public string? Tamanho { get; set; }
        public string? DscNote { get; set; }
        public string? VideoLink1 { get; set; }
        public string? VideoLink2 { get; set; }
        public string? VideoLink3 { get; set; }
        public string? VideoLink4 { get; set; }
        public string? VideoLink5 { get; set; }
        public string? VideoLink6 { get; set; }
        public int IdPais { get; set; }
        public int IdEspecie { get; set; }
        public int IdFamilia { get; set; }
        public string? WoWp { get; set; }
        public decimal? Valor { get; set; }
        public int? QtdEstoque { get; set; }
        public int? StatusEstoque { get; set; }

        public virtual Pais Pais { get; set; }
        public virtual Especie Especie { get; set; }
        public virtual Familia Familia { get; set; }
    }
}
