using API_ECommerce.Context;
using API_ECommerce.Interfaces;
using API_ECommerce.Models;
using API_ECommerce.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API_ECommerce.Controllers;

[Route("api/[controller]")]
[ApiController]

public class ItemPedidoController : Controller
{
    private IItemPedidoRepository _itemPedidoRepository;
    public ItemPedidoController(IItemPedidoRepository itemPedidoRepository)
    {
        _itemPedidoRepository = itemPedidoRepository;
    }

    [HttpGet]
    public ActionResult ListarProdutos()
    {
        return Ok(_itemPedidoRepository.ListarTodos());
    }

    [HttpPost]
    public IActionResult CadastrarProduto(ItemPedido itemPedido)
    {
        _itemPedidoRepository.Cadastrar(itemPedido);

        return Created();
    }
}
