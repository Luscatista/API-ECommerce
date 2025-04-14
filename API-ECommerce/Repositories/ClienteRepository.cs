using System.Collections.Generic;
using API_ECommerce.Context;
using API_ECommerce.Interfaces;
using API_ECommerce.Models;

namespace API_ECommerce.Repositories;

public class ClienteRepository : IClienteRepository
{
    private readonly EcommerceContext _context;
    public ClienteRepository(EcommerceContext context)
    {
        _context = context;
    }
    public List<Cliente> ListarTodos()
    {
        return _context.Clientes.ToList();
    }
    public Cliente BuscarPorId(int id)
    {
        throw new NotImplementedException();
    }
    public void Cadastrar(Cliente cliente)
    {
        _context.Clientes.Add(cliente);
        _context.SaveChanges();
    }
    public void Atualizar(int id, Cliente cliente)
    {
        throw new NotImplementedException();
    }
    public Cliente BuscarPorEmailSenha(string email, string senha)
    {
        throw new NotImplementedException();
    }
    public void Deletar(int id)
    {
        throw new NotImplementedException();
    }
}
