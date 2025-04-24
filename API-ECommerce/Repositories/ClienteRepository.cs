using System.Collections.Generic;
using API_ECommerce.Context;
using API_ECommerce.DTOs;
using API_ECommerce.Interfaces;
using API_ECommerce.Models;
using API_ECommerce.ViewModels;

namespace API_ECommerce.Repositories;

public class ClienteRepository : IClienteRepository
{
    private readonly EcommerceContext _context;
    public ClienteRepository(EcommerceContext context)
    {
        _context = context;
    }
    public List<ListarClienteViewModel> ListarTodos()
    {
        return _context.Clientes.Select(
            c => new ListarClienteViewModel 
            {
                IdCliente = c.IdCliente,
                NomeCompleto = c.NomeCompleto,
                Email = c.Email,
                Telefone = c.Telefone,
                Endereco = c.Endereco
            })
            .OrderBy(c => c.NomeCompleto).ToList();
    }
    public Cliente? BuscarPorId(int id)
    {
        //FirstOrDefault() - Entrega o primeiro ou null
        return _context.Clientes.FirstOrDefault(c => c.IdCliente == id);
    }
    public Cliente? BuscarPorEmailSenha(string email, string senha)
    {
        return _context.Clientes.FirstOrDefault(c => c.Email == email && c.Senha == senha);
    }
    public List<Cliente> BuscarClientePorNome(string nome)
    {
        var listaClientes = _context.Clientes.Where(c => c.NomeCompleto == nome).ToList();
        return listaClientes;
    }
    public void Cadastrar(ClienteDto cliente)
    {
        Cliente cadastrarCliente = new Cliente
        {
            NomeCompleto = cliente.NomeCompleto,
            Email = cliente.Email,
            Senha = cliente.Senha,
            Telefone = cliente.Telefone,
            Endereco = cliente.Endereco,
            DataCadastro = cliente.DataCadastro
        };
        _context.Clientes.Add(cadastrarCliente);
        _context.SaveChanges();
    }
    public void Atualizar(int id, Cliente cliente)
    {
        var clienteAtual = _context.Clientes.FirstOrDefault(c => c.IdCliente == id);
        if (clienteAtual == null)
        {
            throw new ArgumentNullException("Cliente não encontrado.");
        }

        clienteAtual.NomeCompleto = cliente.NomeCompleto;
        clienteAtual.Email = cliente.Email;
        clienteAtual.Senha = cliente.Senha;
        clienteAtual.Telefone = cliente.Telefone;
        clienteAtual.Endereco = cliente.Endereco;
        clienteAtual.DataCadastro = cliente.DataCadastro;

        _context.SaveChanges();
    }
    public void Deletar(int id)
    {
        // O método Find() aceita apenas ID
        var cliente = _context.Clientes.Find(id);

        if (cliente == null)
        {
            throw new ArgumentNullException("Cliente não encontrado.");
        }

        _context.Clientes.Remove(cliente);

        _context.SaveChanges();
    }
}
