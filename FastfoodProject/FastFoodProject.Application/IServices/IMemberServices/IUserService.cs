using FastFoodProject.Application.DTOs.MemberDTOs;

namespace FastFoodProject.Application.IServices.IMemberServices
{
	public interface IUserService
	{
		Task<bool> UserCreate(UserDto userDto);
		Task<bool> UserUpdate(UserDto userDto);
		Task<bool> UserDelete(string userId);
	}
}
