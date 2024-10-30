using LojaFlex.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaFlex.Services.Interfaces
{
    public interface IDashboardService
    {
        Task<DashboardDto> GetDashboard();
    }
}
