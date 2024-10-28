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
    public class PaisService : IPaisService
    {
        private readonly IPaisRepository _repository;
        private readonly IMapper _mapper;

        public PaisService(IPaisRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PaisDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<PaisDto>>(await _repository.GetAllAsync());
        }

        public async Task<PaisDto?> GetByIdAsync(int id)
        {
            return _mapper.Map<PaisDto>(await _repository.GetByIdAsync(id));
        }

        public async Task AddAsync(PaisDto pais)
        {
            await _repository.AddAsync(_mapper.Map<Pais>(pais));
            await _repository.SaveAsync();
        }

        public async Task<string> UpdateAsync(PaisDto pais)
        {
            var assuntoExpcted = await _repository.GetByIdAsync(pais.IdPais);

            if (assuntoExpcted != null)
            {
                _repository.Update(_mapper.Map<Pais>(pais));
                await _repository.SaveAsync();

                return "OK";
            }
            else
            {
                return "Erro ao alterar o país! Não existe país associado ao código.";
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
                return "Erro ao excluir o país! Não existe país associado ao código.";
            }
        }
    }
}
