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
    
    [HttpGet("{id}")]
    public ActionResult ListarPorId(int id)
    {
        var produto = _produtoRepository.BuscarPorId(id);
        if(produto == null)
        {
            return NotFound();
        }

        return Ok(produto);
    }

    [HttpPost]
    public IActionResult CadastrarProduto(Produto produto)
    {
        _produtoRepository.Cadastrar(produto);

        return Created();
    }

    [HttpPut("{id}")]
    public IActionResult Editar(int id, Produto produto)
    {
        try
        {
            _produtoRepository.Atualizar(id, produto);
            return Ok(produto);
        }
        catch(Exception ex) 
        {
            return NotFound("Produto não encontrado.");
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        try 
        {
            _produtoRepository.Deletar(id);
            return NoContent();
        }
        catch(Exception ex)
        {
            return NotFound("Produto não encontrado.");
        }
    }
}