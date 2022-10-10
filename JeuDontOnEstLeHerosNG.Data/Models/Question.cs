using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JeuDontOnEstLeHerosNG.Data.Models;

[Table("Question")]
public class Question : AModel
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;

    public int ParagrapheId { get; set; }

    public List<Reponse> Reponse { get; init; } = new List<Reponse>();
}
