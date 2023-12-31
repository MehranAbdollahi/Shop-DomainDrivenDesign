﻿using Shop.Domain.Shared;
using Shop.Application.Products.DTOs;
using Shop.Domain.ProductAgg;

namespace Shop.Application.Products;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public long AddProduct(AddProductDto command)
    {
        Product product = new Product(command.Title, Money.FromTooman(command.Price));
        _repository.Add(product);
        _repository.Save();

        return product.Id;
    }

    public void EditProduct(EditProductDto command)
    {
        var product = _repository.GetById(command.Id);
        product.Edit(command.Title, Money.FromTooman(command.Price));

        _repository.Update(product);
        _repository.Save();
    }

    public ProductDto GetProductById(long productId)
    {
        var product = _repository.GetById(productId);
        return new ProductDto()
        {
            Price = product.Money.RialValue,
            Id = productId,
            Title = product.Title
        };
    }

    public List<ProductDto> GetProducts()
    {
        return _repository.GetList().Select(product => new ProductDto()
        {
            Price = product.Money.RialValue,
            Id = product.Id,
            Title = product.Title
        }).ToList();

    }
}