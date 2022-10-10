using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JeuDontOnEstLeHerosNG.Data.Models;

[Table("Paragraphe")]
public class Paragraphe : AModel
{
    [Key]
    public int Id { get; set; }
    [Range(1, 9999, ErrorMessage = "Nombre requis STP !")]
    public int Numero { get; set; }
    [MinLength(5)]
    public string Title { get; set; } = string.Empty;
    [MinLength(5)]
    public string Description { get; set; } = string.Empty;
    public Question MaQuestion { get; private set; } = new Question();
}
