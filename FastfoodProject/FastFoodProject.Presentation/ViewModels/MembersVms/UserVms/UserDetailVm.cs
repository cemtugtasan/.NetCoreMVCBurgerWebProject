using FastFoodProject.Application.DTOs.MemberDTOs;

namespace FastFoodProject.Presentation.ViewModels.MembersVms.UserVms
{
	public class UserDetailVm
	{
		public string? UserName { get; set; }
		public DateTime CreateDate { get; set; }
		public bool IsActive { get; set; }
		
		public UserDetailVm(UserDto userDto)
		{
			
			UserName = userDto.UserName;
			IsActive = userDto.IsActive;
			CreateDate = userDto.CreateDate;
		}
	}
}
