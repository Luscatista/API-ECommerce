using API_ECommerce.Context;
using API_ECommerce.DTOs;
using API_ECommerce.Interfaces;
using API_ECommerce.Models;
using API_ECommerce.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API_ECommerce.Controllers;

[Route("api/[controller]")]
[ApiController]

public class PedidoController : Controller
{
    private IPedidoRepository _pedidoRepository;
    public PedidoController(IPedidoRepository pedidoRepository)
    {
        _pedidoRepository = pedidoRepository;
    }

    [HttpGet]
    public ActionResult ListarPedidos()
    {
        return Ok(_pedidoRepository.ListarTodos());
    }

    [HttpGet("{id}")]
    public ActionResult BuscarPorId(int id)
    { 
        return Ok(_pedidoRepository.BuscarPorId(id));
    }

    [HttpPost]
    public IActionResult CadastrarProduto(PedidoDto pedido)
    {
        _pedidoRepository.Cadastrar(pedido);

        return Created();
    }

    [HttpPut]
    public IActionResult Editar(int id, PedidoDto pedidoDto)
    {
        try
        {
            _pedidoRepository.Atualizar(id, pedidoDto);
            return Ok(pedidoDto);
        }
        catch (Exception)
        {
            return NotFound("Pedido não encontrado.");
        }
    }

    [HttpDelete]
    public IActionResult Deletar(int id)
    {
        try
        {
            _pedidoRepository.Deletar(id);
            return NoContent();
        }
        catch (Exception)
        {
            return NotFound("Pedido não encontrado.");
        }
    }
}
