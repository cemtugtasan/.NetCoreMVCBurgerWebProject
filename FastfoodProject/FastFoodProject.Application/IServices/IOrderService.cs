using FastFoodProject.Application.DTOs.OrderDTOs;
using FastFoodProject.Domain.Entities;
using System.Linq.Expressions;

namespace FastFoodProject.Application.IServices
{
	public interface IOrderService
	{
		Task<bool> OrderCreate(OrderCreateDto orderCreateDto);
		Task<bool> OrderUpdate(OrderUpdateDto orderUpdateDto);
		Task<bool> OrderDelete(int orderId);
		Task<IEnumerable<OrderListDto>> OrderList(Expression<Func<Order, bool>> filter = null);
		Task<OrderCreateDto> GetByOrderId(int orderId);
		Task<decimal> GetTotalPriceFromOrder(Order order);
	}
}
