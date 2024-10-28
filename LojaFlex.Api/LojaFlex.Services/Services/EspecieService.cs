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
    public class EspecieService : IEspecieService
    {
        private readonly IEspecieRepository _repository;
        private readonly IMapper _mapper;

        public EspecieService(IEspecieRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EspecieDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<EspecieDto>>(await _repository.GetAllAsync());
        }

        public async Task<EspecieDto?> GetByIdAsync(int id)
        {
            return _mapper.Map<EspecieDto>(await _repository.GetByIdAsync(id));
        }

        public async Task AddAsync(EspecieDto especie)
        {
            await _repository.AddAsync(_mapper.Map<Especie>(especie));
            await _repository.SaveAsync();
        }

        public async Task<string> UpdateAsync(EspecieDto especie)
        {
            var assuntoExpcted = await _repository.GetByIdAsync(especie.IdEspecie);

            if (assuntoExpcted != null)
            {
                _repository.Update(_mapper.Map<Especie>(especie));
                await _repository.SaveAsync();

                return "OK";
            }
            else
            {
                return "Erro ao alterar a espécie! Não existe espécie associado ao código.";
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
                return "Erro ao excluir a espécie! Não existe espécie associado ao código.";
            }
        }
    }
}
