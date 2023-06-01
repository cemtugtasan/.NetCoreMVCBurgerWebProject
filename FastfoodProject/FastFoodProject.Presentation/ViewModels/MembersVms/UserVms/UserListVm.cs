using FastFoodProject.Application.DTOs.MemberDTOs;

namespace FastFoodProject.Presentation.ViewModels.MembersVms.UserVms
{
	public class UserListVm
	{
		public string Id { get; set; }
		public string? UserName { get; set; }
		public DateTime CreateDate { get; set; }
		public bool IsActive { get; set; }
		public UserListVm(UserDto userDto)
		{
			Id = userDto.Id;
			UserName = userDto.UserName;
			IsActive = userDto.IsActive;
			CreateDate = userDto.CreateDate;
		}
	}
}
