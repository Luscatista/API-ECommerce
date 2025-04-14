using API_ECommerce.Context;
using API_ECommerce.Interfaces;
using API_ECommerce.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API_ECommerce.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PagamentoController : Controller
{
    private IPagamentoRepository _pagamentoRepository;
    public PagamentoController(IPagamentoRepository pagamentoRepository)
    {
        _pagamentoRepository = pagamentoRepository;
    }

    [HttpGet()]
    public IActionResult ListarTodos()
    {
        return Ok(_pagamentoRepository.ListarTodos());
    }
}
