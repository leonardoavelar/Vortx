﻿using VxTel.Api.Domain.DTO;
using VxTel.Api.Domain.Interface.Service;
using VxTel.Api.Domain.Interface.UseCase;

namespace VxTel.Api.Application.UseCase
{
    public class ClienteUseCase : IClienteUseCase
    {
        private readonly IClienteService _clienteService;

        public ClienteUseCase(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public async Task<ClienteDTO> RetornaClienteContrato(int id)
        {
            var result = await _clienteService.RetornaClienteContrato(id);
            return result;
        }
    }
}
