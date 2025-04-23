using API_ECommerce.Context;
using API_ECommerce.Interfaces;
using API_ECommerce.Models;
using API_ECommerce.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API_ECommerce.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClienteController : Controller
{
    private IClienteRepository _clienteRepository;
    public ClienteController(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    [HttpGet]
    public IActionResult ListarTodos()
    {
        return Ok(_clienteRepository.ListarTodos());
    }

    [HttpGet("{id}")]
    public IActionResult BuscarPorId(int id)
    {
        var cliente = _clienteRepository.BuscarPorId(id);
        if (cliente == null)
        {
            return NotFound();
        }
        return Ok(cliente);
    }

    [HttpGet("{email}/{senha}")]
    public IActionResult Login(string email, string senha)
    {
        var cliente = _clienteRepository.BuscarPorEmailSenha(email, senha);
        if (cliente == null)
        {
            return NotFound("Dados inválidos.");
        }
        return Ok(cliente);
    }

    [HttpPost]
    public IActionResult CadastrarCliente(Cliente cliente)
    {
        _clienteRepository.Cadastrar(cliente);

        return Created();
    }

    [HttpPut("{id}")]
    public IActionResult Editar(int id, Cliente cliente)
    {
        try
        {
            _clienteRepository.Atualizar(id, cliente);
            return Ok(cliente);
        }
        catch(Exception)
        {
            return NotFound("Cliente não encontrado.");
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Deletar(int id)
    {
        try
        {
            _clienteRepository.Deletar(id);
            return NoContent();
        }
        catch(Exception)
        {
            return NotFound("Cliente não encontrado.");
        }
    }
}