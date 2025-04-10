using API_ECommerce.Interfaces;
using API_ECommerce.Models;
using API_ECommerce.Context;

namespace API_ECommerce.Repositories;
public class ProdutoRepository : IProdutoRepository
{
    private readonly EcommerceContext _context;

    public ProdutoRepository(EcommerceContext context)
    {
        _context = context;
    }

    public List<Produto> ListarTodos()
    {
        return _context.Produtos.ToList();
    }
    public Produto BuscarPorId(int id)
    {
        throw new NotImplementedException();
    }
    public void Cadastro(Produto produto)
    {
        _context.Produtos.Add(produto);
    }
    public void Atualizar(int id, Produto produto)
    {

    }
    public void Deletar(int id)
    {

    }
}
