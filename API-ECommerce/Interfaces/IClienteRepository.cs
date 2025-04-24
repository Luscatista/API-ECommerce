using API_ECommerce.DTO;
using API_ECommerce.Models;

namespace API_ECommerce.Interfaces;

public interface IClienteRepository
{
    List<Cliente> ListarTodos();
    Cliente BuscarPorId(int id);
    Cliente BuscarPorEmailSenha(string email, string senha);
    List<Cliente> BuscarClientePorNome(string nome);
    void Cadastrar(CadastrarClienteDto cliente);
    void Atualizar(int id, Cliente cliente);
    void Deletar(int id);
}