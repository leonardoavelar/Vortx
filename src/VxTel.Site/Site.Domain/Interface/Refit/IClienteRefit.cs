﻿using Microsoft.AspNetCore.Mvc;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;
using VxTel.Site.Domain.DTO;

namespace VxTel.Site.Domain.Interface.Refit
{
    public interface IClienteRefit 
    {
        [Get("/Cliente")]
        Task<IEnumerable<ClienteDTO>> Get();

        [Get("/Cliente/{id}")]
        Task<ClienteDTO> Get(int id);

        [Post("/Cliente")]
        Task<ClienteDTO> Post([FromBody] ClienteDTO dto);

        [Put("/Cliente/{id}")]
        Task Put(int id, [FromBody] ClienteDTO dto);

        [Delete("/Cliente/{id}")]
        Task Delete(int id);
    }
}