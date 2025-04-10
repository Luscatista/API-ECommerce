using API_ECommerce.Models;

namespace API_ECommerce.Interfaces;

public interface IProdutoRepository
{
    List<Produto> ListarTodos();
    Produto BuscarPorId(int id);
    void Cadastro(Produto produto);
    void Atualizar(int id, Produto produto);
    void Deletar(int id);
}