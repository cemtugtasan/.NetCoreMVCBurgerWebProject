using FastFoodProject.Application.DTOs.OrderDTOs;
using FastFoodProject.Application.IServices;
using FastFoodProject.Domain.Entities;
using FastFoodProject.Domain.IRepositories;
using System.Linq.Expressions;

namespace FastFoodProject.Application.Services
{

	public class OrderService : IOrderService
	{
		private readonly IOrderRepository _orderRepository;

		public OrderService(IOrderRepository orderRepository)
		{
			_orderRepository = orderRepository;
		}

		public async Task<OrderCreateDto> GetByOrderId(int orderId)
		{
			Order order = await _orderRepository.GetById(orderId);
			OrderCreateDto dto = new OrderCreateDto
			{
				Name = order.Name,
				TotalPrice = order.TotalPrice,
				Menus = order.Menus,
				Drinks = order.Drinks,
				Eats = order.Eats,
				Extras = order.Extras,
			};
			return dto;
		}

		public async Task<decimal> GetTotalPriceFromOrder(Order order)
		{
			decimal totalPrice = 0;
			foreach (var menu in order.Menus)
			{
				totalPrice += menu.Price;
			}
			foreach (var eat in order.Eats)
			{
				totalPrice += eat.Price;
			}
			foreach (var drink in order.Drinks)
			{
				totalPrice += drink.Price;
			}
			foreach (var extra in order.Extras)
			{
				totalPrice += extra.Price;
			}
			return totalPrice;
		}

		public async Task<bool> OrderCreate(OrderCreateDto orderCreateDto)
		{
			Order order = new Order
			{
				Name = orderCreateDto.Name,
				CreateDate = orderCreateDto.CreateDate,
				Drinks = orderCreateDto.Drinks,
				Eats = orderCreateDto.Eats,
				Extras = orderCreateDto.Extras,
				IsActive = orderCreateDto.IsActive,
				Menus = orderCreateDto.Menus,
				TotalPrice = orderCreateDto.TotalPrice,
			};
			return await _orderRepository.Create(order);
		}

		public async Task<bool> OrderDelete(int orderId)
		{
			Order order = await _orderRepository.GetById(orderId);
			return await _orderRepository.Delete(order);
		}

		public async Task<IEnumerable<OrderListDto>> OrderList(Expression<Func<Order, bool>> filter = null)
		{
			List<Order> orderList = _orderRepository.GetFilteredAll(filter).Result.ToList();
			List<OrderListDto> orders = orderList.Select(x => new OrderListDto
			{
				Id = x.Id,
				Name = x.Name,
				TotalPrice = x.TotalPrice,
				Drinks = x.Drinks,
				Eats = x.Eats,
				Extras = x.Extras,
				Menus = x.Menus,
			}).ToList();
			return orders;
		}

		public async Task<bool> OrderUpdate(OrderUpdateDto orderUpdateDto)
		{
			Order order = await _orderRepository.GetById(orderUpdateDto.Id);
			order.Drinks = orderUpdateDto.Drinks;
			order.UpdateDate = orderUpdateDto.UpdateDate;
			order.TotalPrice = orderUpdateDto.TotalPrice;			
			order.Eats = orderUpdateDto.Eats;
			order.Extras = orderUpdateDto.Extras;
			order.Menus = orderUpdateDto.Menus;	
			
			return await _orderRepository.Update(order);
		}
	}
}
