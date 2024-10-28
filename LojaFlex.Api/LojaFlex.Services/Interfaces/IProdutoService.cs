using LojaFlex.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaFlex.Services.Interfaces
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutoDto>> GetAllAsync();
        Task<ProdutoDto?> GetByIdAsync(int id);
        Task AddAsync(ProdutoDto autor);
        Task<string> UpdateAsync(ProdutoDto autor);
        Task<string> DeleteAsync(int id);
    }
}
