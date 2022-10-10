namespace JeuDontOnEstLeHerosNG.Web.ViewModels;

using System.ComponentModel.DataAnnotations;

public class CreateQuestionRequest : ARequest
{
    [Required]
    public string Title { get; set; } = string.Empty;

    [Required]
    public int ParagrapheId { get; set; }
}