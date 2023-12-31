﻿using Shop.Domain.Shared;

namespace Shop.Application.Orders.DTOs;

public class OrderDto
{
    public long UserId { get; set; }
    public long Id { get;  set; }
    public long ProductId { get;  set; }
    public int Count { get;  set; }
    public Money Price { get;  set; }
}