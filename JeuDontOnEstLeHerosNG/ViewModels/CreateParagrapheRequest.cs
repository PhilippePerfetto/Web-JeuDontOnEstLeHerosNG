namespace JeuDontOnEstLeHerosNG.Web.ViewModels;

using JeuDontOnEstLeHerosNG.Data.Models;
using System.ComponentModel.DataAnnotations;

public class CreateParagrapheRequest : ARequest
{
    [Required]
    public int Id { get; set; }

    [Required]
    public string Title { get; set; } = string.Empty;

    [Required]
    public int Numero { get; set; }

    [Required]
    public string Description { get; set; } = string.Empty;

    [Required]
    public Question MaQuestion { get; private init; } = new Question();
}