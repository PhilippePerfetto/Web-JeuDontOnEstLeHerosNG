namespace JeuDontOnEstLeHerosNG.Web.ViewModels;

using System.ComponentModel.DataAnnotations;

public class UpdateAventureRequest : ARequest
{
    [Required]
    public string Title { get; set; } = string.Empty;
}