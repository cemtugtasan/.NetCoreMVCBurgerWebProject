using FastFoodProject.Application.DTOs.MemberDTOs;

namespace FastFoodProject.Presentation.ViewModels.MembersVms.AdminVms
{
	public class AdminDetailVm
	{
		public string? UserName { get; set; }
		public DateTime CreateDate { get; set; }
		public AdminDetailVm(AdminDto adminDto)
		{
			UserName= adminDto.UserName;
			CreateDate = adminDto.CreateDate;
		}
	}
}
