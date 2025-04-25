using API_ECommerce.DTOs;
using API_ECommerce.ViewModels;

namespace API_ECommerce.Interfaces;

public interface IProdutoRepository
{
    List<ProdutoViewModel> ListarTodos();
    ProdutoViewModel BuscarPorId(int id);
    void Cadastrar(ProdutoDto produto);
    void Atualizar(int id, ProdutoDto produto);
    void Deletar(int id);
}