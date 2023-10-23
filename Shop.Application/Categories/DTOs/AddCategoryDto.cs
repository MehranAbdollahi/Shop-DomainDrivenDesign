namespace Shop.Application.Categories.DTOs;

public class AddCategoryDto
{
    public string Title { get; set; }
    public int? ParentId { get; set; }
}