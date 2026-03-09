using PetBoutique.Api.Entities;
namespace PetBoutique.Api.Repositories;

public interface IProdutoRepository
{
    Task<IEnumerable<Produto>> GetItens();
    Task<Produto> GetItem(int id);
    Task<IEnumerable<Produto>> GetItemPorCategoria(int id);
}
