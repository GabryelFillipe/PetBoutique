using System.ComponentModel.DataAnnotations;

namespace PetBoutique.Models.DTOs;

public class CategoriaDto
{
    public int Id { get; set; }

    [MaxLength(100)]
    public string Nome { get; set; } = string.Empty;
    public string IconCSS { get; set; } = string.Empty;
}
