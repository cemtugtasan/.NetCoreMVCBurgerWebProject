namespace FastFoodProject.Application.DTOs.MemberDTOs
{
	public class AdminDto
	{
		public string Id { get; set; }
		public string? UserName { get; set; }
		public string? Password { get; set; }
		public DateTime CreateDate => DateTime.Now;
		public bool IsActive { get; set; }
		
	}
}
