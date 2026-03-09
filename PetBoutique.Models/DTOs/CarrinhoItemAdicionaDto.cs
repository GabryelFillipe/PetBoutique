using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace PetBoutique.Models.DTOs;

public class CarrinhoItemAdicionaDto
{

    [Required]
    public int ProdutoId { get; set; }
    [Required]
    public int CarrinhoId { get; set; }
    [Required]
    public int Quantidade { get; set; }

}
