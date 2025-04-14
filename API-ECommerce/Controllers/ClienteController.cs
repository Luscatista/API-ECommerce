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

    [HttpPost]
    public IActionResult CadastrarCliente(Cliente cliente)
    {
        _clienteRepository.Cadastrar(cliente);

        return Created();
    }
}
