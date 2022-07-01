using VxTel.Api.Domain.DTO;
using VxTel.Api.Domain.Entity;
using VxTel.Api.Domain.Interface.Implementation;

namespace VxTel.Api.Test.Application.Service
{
    public class BaseServiceTest <D, E>
        where D : BaseDTO
        where E : BaseEntity
    {
        private readonly IBaseService<D, E> baseService;

        public BaseServiceTest(IBaseService<D, E> baseService)
        {
            this.baseService = baseService;
        }

        public async Task Service_Insert_OK(D dto)
        {
            // Insere registro
            var result = await baseService.InsertAsync(dto);

            Assert.IsNotNull(result);
            Assert.AreEqual(result, dto);
        }

        public async Task Service_Update_OK(D dto, D newDto)
        {
            // Insere novo registro
            // Recupera registro atualizado (AsNoTracking)
            var resultDto = await baseService.InsertAsync(dto);
            var resultDtoInit = await baseService.FindByIdAsync(dto.Id);

            // Atualiza o registro existente
            // Recupera registro atualizado (AsNoTracking)
            dto = newDto;
            await baseService.UpdateAsync(dto);
            var resultNewDto = await baseService.FindByIdAsync(dto.Id);

            Assert.AreNotEqual(resultDtoInit, dto);       // O registro atualizado não será igual ao registro inserido inicialmente
            Assert.AreEqual(resultDto, dto);              // O registro atualizado será igual ao resultado da inserção inicial
            Assert.AreEqual(resultNewDto, dto);           // O registro atualizado será igual ao resultado da atualização
        }

        public async Task Service_Delete_OK(D dto)
        {
            // Insere novo registro
            var resultDto = await baseService.InsertAsync(dto);

            // Remove o registro
            await baseService.DeleteAsync(resultDto.Id);
            var resultNewDto = await baseService.FindByIdAsync(dto.Id);

            Assert.IsNull(resultNewDto);
        }

        public async Task Service_Exists_OK(D dto)
        {
            // Insere novo registro
            var resultDto = await baseService.InsertAsync(dto);

            // Valida a existência do registro
            var resultExist = await baseService.ExistAsync(resultDto.Id);

            Assert.IsTrue(resultExist);
        }

        public async Task Service_NoExists_OK(D dto)
        {
            // Valida a existência do registro
            var resultExist = await baseService.ExistAsync(dto.Id);

            Assert.IsFalse(resultExist);
        }

        public async Task Service_FindById_OK(D dto)
        {
            // Insere novo registro
            var resultDto = await baseService.InsertAsync(dto);

            // Remove o registro
            var resultNewDto = await baseService.FindByIdAsync(dto.Id);

            Assert.IsNotNull(resultNewDto);
            Assert.AreEqual(resultDto, resultNewDto);
        }

        public async Task Service_FindAll_OK(List<D> listDto)
        {
            // Insere os novos registros
            listDto.ForEach(async (item) => await baseService.InsertAsync(item));

            // Remove o registro
            var resultListDto = await baseService.FindAllAsync();

            Assert.IsNotNull(resultListDto);
            CollectionAssert.AllItemsAreNotNull(resultListDto.ToList());
            CollectionAssert.AllItemsAreUnique(resultListDto.ToList());
        }
    }
}
