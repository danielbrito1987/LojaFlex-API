using AutoMapper;
using LojaFlex.Api.Commands;
using LojaFlex.Domain.Models;
using LojaFlex.Services.DTO;

namespace LojaFlex.Api.Setup
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Pais, PaisDto>().ReverseMap();
            CreateMap<Familia, FamiliaDto>().ReverseMap();
            CreateMap<Especie, EspecieDto>().ReverseMap();
            CreateMap<Produto, ProdutoDto>().ReverseMap();

            CreateMap<PaisDto, CreatePaisCommand>().ReverseMap();
            CreateMap<PaisDto, UpdatePaisCommand>().ReverseMap();
            CreateMap<EspecieDto, CreateEspecieCommand>().ReverseMap();
            CreateMap<EspecieDto, UpdateEspecieCommand>().ReverseMap();
            CreateMap<FamiliaDto, CreateFamiliaCommand>().ReverseMap();
            CreateMap<FamiliaDto, UpdateFamiliaCommand>().ReverseMap();
            CreateMap<ProdutoDto, CreateProdutoCommand>().ReverseMap();
            CreateMap<ProdutoDto, UpdateProdutoCommand>().ReverseMap();
        }
    }
}
