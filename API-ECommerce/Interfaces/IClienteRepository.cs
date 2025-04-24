using API_ECommerce.DTOs;
using API_ECommerce.Models;
using API_ECommerce.ViewModels;

namespace API_ECommerce.Interfaces;

public interface IClienteRepository
{
    List<ListarClienteViewModel> ListarTodos();
    Cliente BuscarPorId(int id);
    Cliente BuscarPorEmailSenha(string email, string senha);
    List<Cliente> BuscarClientePorNome(string nome);
    void Cadastrar(ClienteDto cliente);
    void Atualizar(int id, Cliente cliente);
    void Deletar(int id);
}