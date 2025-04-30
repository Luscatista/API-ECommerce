using API_ECommerce.Context;
using API_ECommerce.DTOs;
using API_ECommerce.Interfaces;
using API_ECommerce.Models;
using API_ECommerce.Repositories;
using API_ECommerce.Services;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]

    public IActionResult ListarTodos()
    {
        return Ok(_clienteRepository.ListarTodos());
    }

    [HttpGet("{id}")]
    [Authorize]

    public IActionResult BuscarPorId(int id)
    {
        var cliente = _clienteRepository.BuscarPorId(id);
        if (cliente == null)
        {
            return NotFound("Cliente não encontrado.");
        }
        return Ok(cliente);
    }
    
    [HttpGet("/buscar/{nome}")]
    [Authorize]

    public IActionResult BuscarClientePorNome(string nome)
    {
        var clientes = _clienteRepository.BuscarClientePorNome(nome);
        if (clientes == null)
        {
            return NotFound();
        }
        return Ok(clientes);
    }

    [HttpPost("login")]

    public IActionResult Login(LoginDto loginDto)
    {

        var cliente = _clienteRepository.BuscarPorEmailSenha(loginDto.Email, loginDto.Senha);
        if (cliente == null)
        {
            return Unauthorized("Dados inválidos.");
        }

        var tokenService = new TokenService();

        var token = tokenService.GenerateToken(cliente.Email);

        return Ok(token);
    }

    [HttpPost]
    [Authorize]

    public IActionResult CadastrarCliente(ClienteDto cliente)
    {
        _clienteRepository.Cadastrar(cliente);

        return Created();
    }

    [HttpPut("{id}")]
    [Authorize]

    public IActionResult Editar(int id, ClienteDto clienteDto)
    {
        try
        {
            _clienteRepository.Atualizar(id, clienteDto);
            return Ok(clienteDto);
        }
        catch(Exception)
        {
            return NotFound("Cliente não encontrado.");
        }
    }

    [HttpDelete("{id}")]
    [Authorize]

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