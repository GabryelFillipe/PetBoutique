using Microsoft.EntityFrameworkCore;
using PetBoutique.Api.Entities;
using PetBoutique.Api.Repositories;

namespace PetBoutique.Api.Context;

public class ProdutoRepository : IProdutoRepository
{
    private readonly AppDbContext _context;

    public ProdutoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Produto> GetItem(int id)
    {
        var produto = await _context.Produtos
                              .Include(c => c.Categoria)
                              .SingleOrDefaultAsync(c => c.Id == id);
        return produto;

    }

    public async Task<IEnumerable<Produto>> GetItemPorCategoria(int id)
    {
        var produto = await _context.Produtos
                        .Include(p => p.Categoria)
                        .Where(p => p.CategoriaId == id).ToListAsync();
        return produto;
  
    }

    public async Task<IEnumerable<Produto>> GetItens()
    {
        var produto = await _context.Produtos
                 .Include(c => c.Categoria)
                 .ToListAsync();
        return produto;
    }
}
