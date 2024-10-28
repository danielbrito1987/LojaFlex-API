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
    public class FamiliaRepository : BaseRepository<Familia>, IFamiliaRepository
    {
        private readonly MaramarDbContext _context;

        public FamiliaRepository(MaramarDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
