namespace Shop.Application.Categories.DTOs;

public class EditCategoryDto
{
    public long Id { get; set; }
    public string Title { get; set; }
    public int? ParentId { get; set; }
}