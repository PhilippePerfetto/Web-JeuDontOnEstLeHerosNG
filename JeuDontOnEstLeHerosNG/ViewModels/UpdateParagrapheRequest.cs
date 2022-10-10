namespace JeuDontOnEstLeHerosNG.Web.ViewModels;

using System.ComponentModel.DataAnnotations;

public class UpdateParagrapheRequest : ARequest
{
    [Required]
    public int Id { get; set; }

    [Required]
    public string Title { get; set; } = string.Empty;

    [Required]
    public string Description { get; set; } = string.Empty;
}