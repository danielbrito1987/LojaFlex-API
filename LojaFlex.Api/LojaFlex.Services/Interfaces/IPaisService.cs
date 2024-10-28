using LojaFlex.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaFlex.Services.Interfaces
{
    public interface IPaisService
    {
        Task<IEnumerable<PaisDto>> GetAllAsync();
        Task<PaisDto?> GetByIdAsync(int id);
        Task AddAsync(PaisDto pais);
        Task<string> UpdateAsync(PaisDto pais);
        Task<string> DeleteAsync(int id);
    }
}
