using API_ECommerce.DTOs;
using API_ECommerce.ViewModels;

namespace API_ECommerce.Interfaces;

public interface IClienteRepository
{
    List<ClienteViewModel> ListarTodos();
    ClienteViewModel BuscarPorId(int id);
    ClienteViewModel BuscarPorEmailSenha(string email, string senha);
    List<ClienteViewModel> BuscarClientePorNome(string nome);
    void Cadastrar(ClienteDto cliente);
    void Atualizar(int id, ClienteDto cliente);
    void Deletar(int id);
}