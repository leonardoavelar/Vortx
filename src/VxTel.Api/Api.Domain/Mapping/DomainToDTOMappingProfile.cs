using AutoMapper;
using VxTel.Api.Domain.DTO;
using VxTel.Api.Domain.Entity;

namespace VxTel.Api.Domain.Mapping
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Produto, ProdutoDTO>().ReverseMap();
            CreateMap<Tarifa, TarifaDTO>().ReverseMap();
        }
    }
}
