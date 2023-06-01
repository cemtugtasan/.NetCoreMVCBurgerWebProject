using FastFoodProject.Application.DTOs.FoodDTOs.ExtraDTOs;
using FastFoodProject.Application.IServices.IFoodServices;
using FastFoodProject.Domain.Entities.FoodEntities;
using FastFoodProject.Domain.IRepositories.IFoodRepositories;
using System.Linq.Expressions;

namespace FastFoodProject.Application.Services.FoodService
{
	public class ExtraService : IExtraService
    {
        private readonly IExtraRepository _extraRepository;

        public ExtraService(IExtraRepository extraRepository)
        {
            _extraRepository = extraRepository;
        }

        public async Task<bool> ExtraCreate(ExtraCreateDto extraCreateDto)
        {
            Extra extra = new Extra
            {
                Name = extraCreateDto.Name,
                Price = extraCreateDto.Price,
                ImagePath = extraCreateDto.ImagePath,
                CreateDate = extraCreateDto.CreateDate,
                IsActive = extraCreateDto.IsActive,
            };
            return await _extraRepository.Create(extra);
        }

        public async Task<bool> ExtraDelete(int extraId)
        {
            Extra extra = await _extraRepository.GetById(extraId);
            return await _extraRepository.Delete(extra);
        }

        public async Task<IEnumerable<ExtraListDto>> ExtraList(Expression<Func<Extra, bool>> filter = null)
        {
            IEnumerable<Extra> extraList = await _extraRepository.GetFilteredAll(filter);
            List<ExtraListDto> extras = extraList.Select(x => new ExtraListDto
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                ImagePath = x.ImagePath,

            }).ToList();
            return extras;
        }

        public async Task<bool> ExtraUpdate(ExtraUpdateDto extraUpdateDto)
        {
            Extra extra = await _extraRepository.GetById(extraUpdateDto.Id);
            extra.Name = extraUpdateDto.Name;
            extra.Price = extraUpdateDto.Price;
            extra.UpdateDate = extraUpdateDto.UpdateDate;
            extra.ImagePath = extraUpdateDto.ImagePath;

            return await _extraRepository.Update(extra);

        }

        public async Task<ExtraCreateDto> GetByExtraId(int extraId)
        {
            Extra extra = await _extraRepository.GetById(extraId);
            ExtraCreateDto extraCreateDto = new ExtraCreateDto
            {
                Name = extra.Name,
                Price = extra.Price,
                ImagePath = extra.ImagePath,
            };
            return extraCreateDto;
        }
    }
}
