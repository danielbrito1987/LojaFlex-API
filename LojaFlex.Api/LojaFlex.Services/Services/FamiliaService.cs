using AutoMapper;
using LojaFlex.Domain.Models;
using LojaFlex.Infra.Interfaces;
using LojaFlex.Services.DTO;
using LojaFlex.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaFlex.Services.Services
{
    public class FamiliaService : IFamiliaService
    {
        private readonly IFamiliaRepository _repository;
        private readonly IMapper _mapper;

        public FamiliaService(IFamiliaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FamiliaDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<FamiliaDto>>(await _repository.GetAllAsync());
        }

        public async Task<FamiliaDto?> GetByIdAsync(int id)
        {
            return _mapper.Map<FamiliaDto>(await _repository.GetByIdAsync(id));
        }

        public async Task AddAsync(FamiliaDto familia)
        {
            await _repository.AddAsync(_mapper.Map<Familia>(familia));
            await _repository.SaveAsync();
        }

        public async Task<string> UpdateAsync(FamiliaDto familia)
        {
            var assuntoExpcted = await _repository.GetByIdAsync(familia.IdFamilia);

            if (assuntoExpcted != null)
            {
                _repository.Update(_mapper.Map<Familia>(familia));
                await _repository.SaveAsync();

                return "OK";
            }
            else
            {
                return "Erro ao alterar a família! Não existe família associado ao código.";
            }
        }

        public async Task<string> DeleteAsync(int id)
        {
            var assunto = await _repository.GetByIdAsync(id);

            if (assunto != null)
            {
                _repository.Delete(assunto);
                await _repository.SaveAsync();

                return "OK";
            }
            else
            {
                return "Erro ao excluir a família! Não existe família associada ao código.";
            }
        }
    }
}
