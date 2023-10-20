namespace Shop.Application.Categories.DTOs;

public class CategoryDto
{
    public long Id { get; set; }
    public string Title { get; set; }
    public int? SubCategoryId { get; set; }
}