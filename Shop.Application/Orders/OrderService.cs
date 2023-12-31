﻿using Shop.Contracts;
using Shop.Application.Orders.DTOs;
using Shop.Domain.OrderAgg;
using Shop.Domain.OrderAgg.Repository;

namespace Shop.Application.Orders;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _repository;
    private readonly ISmsService _smsService;
    public OrderService(IOrderRepository repository, ISmsService smsService)
    {
        _repository = repository;
        _smsService = smsService;
    }

    public void AddOrder(AddOrderDto command)
    {
        var order = new Order(command.ProductId);
        _repository.Add(order);
        _repository.SaveChanges();
    }

    public void FinallyOrder(FinallyOrderDto command)
    {
        var order = _repository.GetById(command.OrderId);
        order.Finally();
        _repository.Update(order);
        _repository.SaveChanges();
        _smsService.SendSms(new SmsBody()
        {
            Message = "Test",
            PhoneNumber = "0917000000"
        });
    }

    public OrderDto GetOrderById(long id)
    {
        var order = _repository.GetById(id);
        return new OrderDto()
        {
            Id = order.Id,
            UserId=order.UserId,
        };
    }

    public List<OrderDto> GetOrders()
    {
        return _repository.GetList().Select(order => new OrderDto()
        {
            Id = order.Id,
        }).ToList();
    }
}