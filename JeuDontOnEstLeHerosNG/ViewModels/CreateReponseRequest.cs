namespace JeuDontOnEstLeHerosNG.Web.ViewModels;

using System.ComponentModel.DataAnnotations;

public class CreateReponseRequest : ARequest
{
    [Required]
    public string Description { get; set; } = string.Empty;

    [Required]
    public int QuestionId { get; set; }
}