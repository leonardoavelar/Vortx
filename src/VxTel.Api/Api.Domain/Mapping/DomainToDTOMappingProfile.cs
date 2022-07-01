using AutoMapper;
using VxTel.Api.Domain.DTO;
using VxTel.Api.Domain.Entity;

namespace VxTel.Api.Domain.Mapping
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Chamada, ChamadaDTO>().ReverseMap();
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
            CreateMap<Consumo, ConsumoDTO>().ReverseMap();
            CreateMap<Contrato, ContratoDTO>().ReverseMap();
            CreateMap<Produto, ProdutoDTO>().ReverseMap();
            CreateMap<Tarifa, TarifaDTO>().ReverseMap();
            CreateMap<TelefoneCliente, TelefoneClienteDTO>().ReverseMap();
        }
    }
}
