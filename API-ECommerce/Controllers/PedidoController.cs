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

    [HttpPost]
    public IActionResult CadastrarProduto(PedidoDto pedido)
    {
        _pedidoRepository.Cadastrar(pedido);

        return Created();
    }
}
