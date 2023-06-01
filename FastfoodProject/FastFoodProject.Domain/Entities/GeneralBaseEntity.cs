namespace FastFoodProject.Domain.Entities
{
	public class GeneralBaseEntity
	{
		public DateTime CreateDate { get; set; }
		public DateTime UpdateDate { get; set; }
		public bool IsActive { get; set; }
	}
}
