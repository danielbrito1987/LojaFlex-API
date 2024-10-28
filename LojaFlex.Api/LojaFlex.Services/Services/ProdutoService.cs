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
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _repository;
        private IMapper _mapper;

        public ProdutoService(IProdutoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProdutoDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<ProdutoDto>>(await _repository.GetAllAsync());
        }

        public async Task<ProdutoDto?> GetByIdAsync(int id)
        {
            return _mapper.Map<ProdutoDto>(await _repository.GetByIdAsync(id));
        }

        public async Task AddAsync(ProdutoDto produto)
        {
            await _repository.AddAsync(_mapper.Map<Produto>(produto));
            await _repository.SaveAsync();
        }

        public async Task<string> UpdateAsync(ProdutoDto produto)
        {
            var assuntoExpcted = await _repository.GetByIdAsync(produto.IdProduto);

            if (assuntoExpcted != null)
            {
                _repository.Update(_mapper.Map<Produto>(produto));
                await _repository.SaveAsync();

                return "OK";
            }
            else
            {
                return "Erro ao alterar o produto! Não existe produto associado ao código.";
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
                return "Erro ao excluir o produto! Não existe produto associado ao código.";
            }
        }
    }
}
