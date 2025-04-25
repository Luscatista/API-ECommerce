using API_ECommerce.Context;
using API_ECommerce.DTOs;
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

    [HttpGet("{id}")]
    public ActionResult BuscarPorId(int id)
    {
        return Ok(_itemPedidoRepository.BuscarPorId(id));
    }

    [HttpPost]
    public IActionResult CadastrarProduto(ItemPedido itemPedido)
    {
        _itemPedidoRepository.Cadastrar(itemPedido);

        return Created();
    }

    [HttpPut]
    public IActionResult Editar(int id, ItemPedido itemPedido)
    {
        try
        {
            _itemPedidoRepository.Atualizar(id, itemPedido);
            return Ok(itemPedido);
        }
        catch (Exception)
        {
            return NotFound("ItemPedido não encontrado.");
        }
    }

    [HttpDelete]
    public IActionResult Deletar(int id)
    {
        try
        {
            _itemPedidoRepository.Deletar(id);
            return NoContent();
        }
        catch (Exception)
        {
            return NotFound("ItemPedido não encontrado.");
        }
    }
}
