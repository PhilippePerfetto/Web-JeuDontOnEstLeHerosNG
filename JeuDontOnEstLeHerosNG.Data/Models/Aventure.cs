using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JeuDontOnEstLeHerosNG.Data.Models;

[Table(name: "Aventure")]
public class Aventure : AModel
{
    [Key]
    public int Id { get; set; }

    [Required(AllowEmptyStrings = false)]
    public string Title { get; set; } = string.Empty;
    public DateTime DateDeCreation { get; set; } = DateTime.Now;
}
