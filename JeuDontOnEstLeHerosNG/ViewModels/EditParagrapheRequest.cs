namespace JeuDontOnEstLeHerosNG.Web.ViewModels;

using System.ComponentModel.DataAnnotations;

public class EditParagrapheRequest : ARequest
{
    [Required]
    public string Title { get; set; } = string.Empty;
    public DateTime DateDeCreation { get; set; }
}