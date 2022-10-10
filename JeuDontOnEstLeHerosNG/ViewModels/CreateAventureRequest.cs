namespace JeuDontOnEstLeHerosNG.Web.ViewModels;

using System.ComponentModel.DataAnnotations;

public class CreateAventureRequest : ARequest
{
    [Required]
    public string Title { get; set; } = string.Empty;
}