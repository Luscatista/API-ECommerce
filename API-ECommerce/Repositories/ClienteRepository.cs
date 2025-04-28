using System.Collections.Generic;
using API_ECommerce.Context;
using API_ECommerce.DTOs;
using API_ECommerce.Interfaces;
using API_ECommerce.Models;
using API_ECommerce.Services;
using API_ECommerce.ViewModels;

namespace API_ECommerce.Repositories;

public class ClienteRepository : IClienteRepository
{
    private readonly EcommerceContext _context;
    public ClienteRepository(EcommerceContext context)
    {
        _context = context;
    }
    public List<ClienteViewModel> ListarTodos()
    {
        return _context.Clientes.Select(
            c => new ClienteViewModel 
            {
                IdCliente = c.IdCliente,
                NomeCompleto = c.NomeCompleto,
                Email = c.Email,
                Telefone = c.Telefone,
                Endereco = c.Endereco
            })
            .OrderBy(c => c.NomeCompleto).ToList();
    }
    public ClienteViewModel? BuscarPorId(int id)
    {
        //FirstOrDefault() - Entrega o primeiro ou null
        return _context.Clientes.Select(
            c => new ClienteViewModel
            {
                IdCliente = c.IdCliente,
                NomeCompleto = c.NomeCompleto,
                Email = c.Email,
                Telefone = c.Telefone,
                Endereco = c.Endereco
            }).FirstOrDefault(c => c.IdCliente == id);
    }
    public ClienteViewModel? BuscarPorEmailSenha(string email, string senha)
    {
        var cliente = _context.Clientes.FirstOrDefault(c => c.Email == email && c.Senha == senha);
        if (cliente == null)
        {
            throw new Exception("Cliente não encontrado.");
        }

        var clienteDto = new ClienteViewModel
        {
            NomeCompleto = cliente.NomeCompleto,
            Email = cliente.Email,
            Endereco = cliente.Endereco,
            DataCadastro = cliente.DataCadastro,
            Telefone = cliente.Telefone
        };
        return clienteDto;
    }
    public List<ClienteViewModel> BuscarClientePorNome(string nome)
    {
        var listaClientes = _context.Clientes.Select(
            c => new ClienteViewModel
            {
                IdCliente = c.IdCliente,
                NomeCompleto = c.NomeCompleto,
                Email = c.Email,
                Telefone = c.Telefone,
                Endereco = c.Endereco
            }).Where(c => c.NomeCompleto == nome).ToList();

        return listaClientes;
    }
    public void Cadastrar(ClienteDto clienteDto)
    {

        Cliente cadastrarCliente = new Cliente
        {
            NomeCompleto = clienteDto.NomeCompleto,
            Email = clienteDto.Email,
            Senha = clienteDto.Senha,
            Telefone = clienteDto.Telefone,
            Endereco = clienteDto.Endereco,
            DataCadastro = clienteDto.DataCadastro
        };

        var passwordService = new PasswordService();

        cadastrarCliente.Senha = passwordService.HashPassword(cadastrarCliente);

        _context.Clientes.Add(cadastrarCliente);

        _context.SaveChanges();
    }
    public void Atualizar(int id, ClienteDto clienteDto)
    {
        var cliente = _context.Clientes.FirstOrDefault(c => c.IdCliente == id);
        if (cliente == null)
        {
            throw new ArgumentNullException("Cliente não encontrado.");
        }

        cliente.NomeCompleto = clienteDto.NomeCompleto;
        cliente.Email = clienteDto.Email;
        cliente.Senha = clienteDto.Senha;
        cliente.Telefone = clienteDto.Telefone;
        cliente.Endereco = clienteDto.Endereco;
        cliente.DataCadastro = clienteDto.DataCadastro;

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
