using VxTel.Api.Domain.DTO;
using VxTel.Api.Domain.Entity;
using VxTel.Api.Domain.Interface.Implementation;

namespace VxTel.Api.Test.Application.Service
{
    public class BaseServiceTest <D, E>
        where D : BaseDTO
        where E : BaseEntity
    {
        public async Task Service_Insert_OK(IBaseService<D, E> baseService, D dto)
        {
            // Insere registro
            var result = await baseService.InsertAsync(dto);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(dto, Is.EqualTo(result));
            });
        }

        public async Task Service_Update_OK(IBaseService<D, E> baseService, D dto, D newDto)
        {
            // Atualiza o registro existente
            // Recupera registro atualizado (AsNoTracking)
            await baseService.UpdateAsync(newDto);
            var resultNewDto = await baseService.FindByIdAsync(newDto.Id);

            Assert.Multiple(() =>
            {
                Assert.That(dto, Is.Not.EqualTo(resultNewDto));        // O registro atualizado não será igual ao registro inserido inicialmente
                Assert.That(dto, Is.Not.EqualTo(newDto));                // O registro atualizado será igual ao resultado da inserção inicial
                Assert.That(newDto, Is.EqualTo(resultNewDto));             // O registro atualizado será igual ao resultado da atualização
            });
        }

        public async Task Service_Delete_OK(IBaseService<D, E> baseService, D dto)
        {
            // Insere novo registro
            var resultDto = await baseService.InsertAsync(dto);

            // Remove o registro
            await baseService.DeleteAsync(resultDto.Id);
            var resultNewDto = await baseService.FindByIdAsync(dto.Id);

            Assert.That(resultNewDto, Is.Null);
        }

        public async Task Service_Exists_OK(IBaseService<D, E> baseService, D dto)
        {
            // Insere novo registro
            var resultDto = await baseService.InsertAsync(dto);

            // Valida a existência do registro
            var resultExist = await baseService.ExistAsync(resultDto.Id);

            Assert.That(resultExist, Is.True);
        }

        public async Task Service_NoExists_OK(IBaseService<D, E> baseService, D dto)
        {
            // Valida a existência do registro
            var resultExist = await baseService.ExistAsync(dto.Id);

            Assert.That(resultExist, Is.False);
        }

        public async Task Service_FindById_OK(IBaseService<D, E> baseService, D dto)
        {
            // Insere novo registro
            var resultDto = await baseService.InsertAsync(dto);

            // Remove o registro
            var resultNewDto = await baseService.FindByIdAsync(dto.Id);

            Assert.Multiple(() =>
            {
                Assert.That(resultNewDto, Is.Not.Null);
                Assert.That(resultNewDto, Is.EqualTo(resultDto));
            });
        }

        public async Task Service_FindAll_OK(IBaseService<D, E> baseService, List<D> listDto)
        {
            // Insere os novos registros
            listDto.ForEach(async (item) => await baseService.InsertAsync(item));

            // Remove o registro
            var resultListDto = await baseService.FindAllAsync();
            Assert.Multiple(() =>
            {
                Assert.That(resultListDto, Is.Not.Null);
                CollectionAssert.AllItemsAreNotNull(resultListDto.ToList());
                CollectionAssert.AllItemsAreUnique(resultListDto.ToList());
            });
        }
    }
}
