using API_ECommerce.Interfaces;
using API_ECommerce.Models;
using API_ECommerce.Context;
using API_ECommerce.DTOs;
using API_ECommerce.ViewModels;

namespace API_ECommerce.Repositories;
public class ProdutoRepository : IProdutoRepository
{
    private readonly EcommerceContext _context;
    public ProdutoRepository(EcommerceContext context)
    {
        _context = context;
    }
    public List<ProdutoViewModel> ListarTodos()
    {
        return _context.Produtos.Select(
            p => new ProdutoViewModel
            {
                IdProduto = p.IdProduto,
                NomeProduto = p.NomeProduto,
                Descricao = p.Descricao,
                Preco = p.Preco,
                EstoqueDisponivel = p.EstoqueDisponivel,
                CategoriaProduto = p.CategoriaProduto,
                Imagem = p.Imagem
            }).ToList();
    }
    public ProdutoViewModel? BuscarPorId(int id)
    {
        return _context.Produtos.Select(
            p => new ProdutoViewModel
            {
                IdProduto = p.IdProduto,
                NomeProduto = p.NomeProduto,
                Descricao = p.Descricao,
                Preco = p.Preco,
                EstoqueDisponivel = p.EstoqueDisponivel,
                CategoriaProduto = p.CategoriaProduto,
                Imagem = p.Imagem
            }).FirstOrDefault(p => p.IdProduto == id);
    }
    public void Cadastrar(ProdutoDto produtoDto)
    {
        var produto = new Produto
        {
            NomeProduto = produtoDto.NomeProduto,
            Descricao = produtoDto.Descricao,
            Preco = produtoDto.Preco,
            EstoqueDisponivel = produtoDto.EstoqueDisponivel,
            CategoriaProduto = produtoDto.CategoriaProduto,
            Imagem = produtoDto.Imagem
        };

        _context.Produtos.Add(produto);
        _context.SaveChanges();
    }
    public void Atualizar(int id, ProdutoDto produtoDto)
    {
        var produtoAtual =  _context.Produtos.FirstOrDefault(p => p.IdProduto == id);
        if (produtoAtual == null)
        {
            throw new Exception();
        }

        produtoAtual.NomeProduto = produtoDto.NomeProduto;
        produtoAtual.Descricao = produtoDto.Descricao;
        produtoAtual.Preco = produtoDto.Preco;
        produtoAtual.CategoriaProduto = produtoDto.CategoriaProduto;
        produtoAtual.Imagem = produtoDto.Imagem;
        produtoAtual.EstoqueDisponivel = produtoDto.EstoqueDisponivel;

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
