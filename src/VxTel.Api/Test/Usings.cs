global using NUnit.Framework;
using AutoMapper;
using VxTel.Api.Domain.Mapping;

IMapper mapper;

var config = new MapperConfiguration(opts =>
{
    opts.AddProfile(new DomainToDTOMappingProfile());
});

mapper = config.CreateMapper();