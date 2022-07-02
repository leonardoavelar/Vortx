﻿using AutoMapper;
using VxTel.Api.Application.Service;
using VxTel.Api.Domain.DTO;
using VxTel.Api.Domain.Entity;
using VxTel.Api.Infrastructure.Repository;
using VxTel.Api.Test.Integration;

namespace VxTel.Api.Test.Application.Service
{
    [TestClass]
    public class ChamadaServiceTest : BaseServiceTest<ChamadaDTO, Chamada>
    {
        private readonly ChamadaDTO chamada;
        private readonly ChamadaDTO novaChamada;
        private readonly List<ChamadaDTO> listChamada;

        public ChamadaServiceTest(IMapper mapper)
            : base(new ChamadaService(mapper, new ChamadaRepository(DatabaseContextExtension.GetDatabaseContextTestAsync())))
        {
            chamada = new ChamadaDTO(1, "031", 987654321, "011", 123456789, DateTime.Now, DateTime.Now, DateTime.Now, new TimeSpan(), 0);

            novaChamada = new ChamadaDTO(1, "021", 987654321, "011", 654915651, DateTime.Now, DateTime.Now, DateTime.Now, new TimeSpan(0, 30, 0), 15);

            listChamada = new List<ChamadaDTO>()
            {
                new ChamadaDTO(16, "031", 987654321, "011", 987654165, DateTime.Now, DateTime.Now, DateTime.Now, new TimeSpan(), 0),
                new ChamadaDTO(12, "031", 987654321, "011", 312156544, DateTime.Now, DateTime.Now, DateTime.Now, new TimeSpan(), 0),
                new ChamadaDTO(15, "031", 987654321, "011", 156987156, DateTime.Now, DateTime.Now, DateTime.Now, new TimeSpan(), 0)
        };
        }

        [TestMethod]
        public async Task Service_Insert_OK()
        {
            await base.Service_Insert_OK(chamada);
        }

        [TestMethod]
        public async Task Service_Update_OK()
        {
            await base.Service_Update_OK(chamada, novaChamada);
        }

        [TestMethod]
        public async Task Service_Delete_OK()
        {
            await base.Service_Delete_OK(chamada);
        }

        [TestMethod]
        public async Task Service_Exists_OK()
        {
            await base.Service_Exists_OK(chamada);
        }

        [TestMethod]
        public async Task Service_NoExists_OK()
        {
            await base.Service_NoExists_OK(chamada);
        }

        [TestMethod]
        public async Task Service_FindById_OK()
        {
            await base.Service_FindById_OK(chamada);
        }

        [TestMethod]
        public async Task Service_FindAll_OK()
        {
            await base.Service_FindAll_OK(listChamada);
        }
    }
}
