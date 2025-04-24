using API_ECommerce.Models;
using API_ECommerce.DTOs;

namespace API_ECommerce.Interfaces;

public interface IProdutoRepository
{
    List<Produto> ListarTodos();
    Produto BuscarPorId(int id);
    void Cadastrar(ProdutoDto produto);
    void Atualizar(int id, Produto produto);
    void Deletar(int id);
}