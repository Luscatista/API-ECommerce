using API_ECommerce.Context;
using API_ECommerce.Interfaces;
using API_ECommerce.Models;
using API_ECommerce.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_ECommerce.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProdutoController : ControllerBase
{

    private IProdutoRepository _produtoRepository;
    public ProdutoController(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    [HttpGet]
    public ActionResult ListarProdutos()
    {
        return Ok(_produtoRepository.ListarTodos());  
    }

    [HttpPost]
    public IActionResult CadastrarProduto(Produto produto)
    {
        _produtoRepository.Cadastrar(produto);

        return Created();
    }
}