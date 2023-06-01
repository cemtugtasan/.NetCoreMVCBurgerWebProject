using FastFoodProject.Application.DTOs.FoodDTOs.EatDTOs;
using FastFoodProject.Application.IServices.IFoodServices;
using FastFoodProject.Domain.Entities.FoodEntities;
using FastFoodProject.Domain.IRepositories.IFoodRepositories;
using System.Linq.Expressions;

namespace FastFoodProject.Application.Services.FoodService
{
	public class EatService : IEatService
    {
        public readonly IEatRepository EatRepository;

        public EatService(IEatRepository eatRepository)
        {
            EatRepository = eatRepository;
        }

        public async Task<bool> EatCreate(EatCreateDto eatCreateDto)
        {
            Eat eat = new Eat
            {
                Name = eatCreateDto.Name,
                Price = eatCreateDto.Price,
                CreateDate = eatCreateDto.CreateDate,
                ImagePath = eatCreateDto.ImagePath,
                IsActive = eatCreateDto.IsActive,
            };
            return await EatRepository.Create(eat);
        }

        public async Task<bool> EatDelete(int eatId)
        {
            Eat eat = await EatRepository.GetById(eatId);
            return await EatRepository.Delete(eat);
        }

        public async Task<IEnumerable<EatListDto>> EatList(Expression<Func<Eat, bool>> filter = null)
        {
            IEnumerable<Eat> eatList = await EatRepository.GetFilteredAll(filter);
            List<EatListDto> eats = eatList.Select(x => new EatListDto
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                ImagePath = x.ImagePath,

            }).ToList();
            return eats;
        }

        public async Task<bool> EatUpdate(EatUpdateDto eatUpdateDto)
        {
            Eat eat = await EatRepository.GetById(eatUpdateDto.Id);
            eat.Name = eatUpdateDto.Name;
            eat.Price = eatUpdateDto.Price;
            eat.UpdateDate = eatUpdateDto.UpdateDate;
            eat.ImagePath = eatUpdateDto.ImagePath;
            return await EatRepository.Update(eat);
        }

        public async Task<EatCreateDto> GetByEatId(int eatId)
        {
            Eat eat = await EatRepository.GetById(eatId);
            EatCreateDto eatCreateDto = new EatCreateDto
            {
                Name = eat.Name,
                Price = eat.Price,
                ImagePath = eat.ImagePath,
            };
            return eatCreateDto;
        }
    }
}
