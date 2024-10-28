using LojaFlex.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaFlex.Services.Interfaces
{
    public interface IEspecieService
    {
        Task<IEnumerable<EspecieDto>> GetAllAsync();
        Task<EspecieDto?> GetByIdAsync(int id);
        Task AddAsync(EspecieDto especie);
        Task<string> UpdateAsync(EspecieDto especie);
        Task<string> DeleteAsync(int id);
    }
}
