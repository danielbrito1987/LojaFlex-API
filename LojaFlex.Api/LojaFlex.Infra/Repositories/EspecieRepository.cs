using LojaFlex.Domain.Models;
using LojaFlex.Infra.Context;
using LojaFlex.Infra.Interfaces;
using LojaFlex.Infra.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaFlex.Infra.Repositories
{
    public class EspecieRepository : BaseRepository<Especie>, IEspecieRepository
    {
        private readonly MaramarDbContext _context;

        public EspecieRepository(MaramarDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
