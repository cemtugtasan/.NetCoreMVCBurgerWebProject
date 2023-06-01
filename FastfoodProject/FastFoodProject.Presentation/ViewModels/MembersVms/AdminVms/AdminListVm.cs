using FastFoodProject.Application.DTOs.MemberDTOs;

namespace FastFoodProject.Presentation.ViewModels.MembersVms.AdminVms
{
	public class AdminListVm
	{
		public string? UserName { get; set; }
		public DateTime CreateDate { get; set; }
		public AdminListVm(AdminDto adminDto)
		{
			UserName = adminDto.UserName;
			CreateDate = adminDto.CreateDate;
		}
	}
}
