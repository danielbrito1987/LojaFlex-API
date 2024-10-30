using LojaFlex.Services.DTO;
using LojaFlex.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaFlex.Services.Services
{
    public class DashboardService : IDashboardService
    {
        public DashboardService() { }

        public async Task<DashboardDto> GetDashboard()
        {
            return new DashboardDto
            {
                QtdClientes = 1500,
                QtdPedidos = 10,
                QtdProdutos = 5854
            };
        }
    }
}
