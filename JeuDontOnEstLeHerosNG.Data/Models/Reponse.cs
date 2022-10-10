using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JeuDontOnEstLeHerosNG.Data.Models;

[Table("Reponse")]
public class Reponse : AModel
{
    [Key]
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;

    public int QuestionId { get; set; }

    /// <summary>
    /// ID du paragraphe suivant
    /// </summary>
    //public int ParagrapheId { get; set; }
}
