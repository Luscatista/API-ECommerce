using API_ECommerce.Interfaces;
using API_ECommerce.Models;
using API_ECommerce.Context;
using API_ECommerce.DTOs;

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
        return _context.Produtos.FirstOrDefault(p => p.IdProduto == id);
    }
    public void Cadastrar(ProdutoDto produto)
    {
        Produto produtoCadastro = new Produto
        {
            NomeProduto = produto.NomeProduto,
            Descricao = produto.Descricao,
            Preco = produto.Preco,
            EstoqueDisponivel = produto.EstoqueDisponivel,
            CategoriaProduto = produto.CategoriaProduto,
            Imagem = produto.Imagem
        };

        _context.Produtos.Add(produtoCadastro);
        _context.SaveChanges();
    }
    public void Atualizar(int id, Produto produto)
    {
        var produtoAtual =  _context.Produtos.FirstOrDefault(p => p.IdProduto == id);
        if (produtoAtual == null)
        {
            throw new Exception();
        }

        produtoAtual.NomeProduto = produto.NomeProduto;
        produtoAtual.Descricao = produto.Descricao;
        produtoAtual.Preco = produto.Preco;
        produtoAtual.CategoriaProduto = produto.CategoriaProduto;
        produtoAtual.Imagem = produto.Imagem;
        produtoAtual.EstoqueDisponivel = produto.EstoqueDisponivel;

        _context.SaveChanges();
    }
    public void Deletar(int id)
    {
        var produto = _context.Produtos.Find(id);

        if(produto == null)
        {
            throw new Exception();
        }

        _context.Produtos.Remove(produto);

        _context.SaveChanges();
    }
}
