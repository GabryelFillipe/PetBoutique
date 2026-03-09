using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetBoutique.Api.Mappings;
using PetBoutique.Api.Repositories;
using PetBoutique.Models.DTOs;

namespace PetBoutique.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProdutosController : ControllerBase
{
    private readonly IProdutoRepository _produtoRepository;

    public ProdutosController(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProdutoDto>>> GetItens()
    {
        try
        {
            var produtos = await _produtoRepository.GetItens();
            if (produtos is null)
            {
                return NotFound();
            }
            else
            {
                var produtoDtos = produtos.ConverterProdutosParaDto();
                return Ok(produtoDtos);
            }

        }
        catch (Exception )
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao acessar a base de Dados");
        }
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ProdutoDto>> GetItem(int id)
    {
        try
        {
            var produto = await _produtoRepository.GetItem(id);
            if (produto is null)
            {
                return NotFound("Produto não localizado");
            }
            else
            {
                var produtoDto = produto.ConverterProdutoParaDto();
                return Ok(produtoDto);
            }

        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao acessar a base de Dados");
        }
    }

    [HttpGet]
    [Route("GetItensPorCategoria/{categoriaId:int}")]
    public async Task<ActionResult<IEnumerable<ProdutoDto>>> GetItensPorCategoria(int categoriaId)
    {
        try
        {
            var produtos = await _produtoRepository.GetItemPorCategoria(categoriaId);
            var produtosDto = produtos.ConverterProdutosParaDto();
            return Ok(produtosDto);

        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao aceder à base de dados");
        }
    }
}
