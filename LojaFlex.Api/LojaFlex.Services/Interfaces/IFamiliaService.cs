using LojaFlex.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaFlex.Services.Interfaces
{
    public interface IFamiliaService
    {
        Task<IEnumerable<FamiliaDto>> GetAllAsync();
        Task<FamiliaDto?> GetByIdAsync(int id);
        Task AddAsync(FamiliaDto autor);
        Task<string> UpdateAsync(FamiliaDto autor);
        Task<string> DeleteAsync(int id);
    }
}
