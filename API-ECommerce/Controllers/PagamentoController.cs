﻿using API_ECommerce.Context;
using API_ECommerce.DTOs;
using API_ECommerce.Interfaces;
using API_ECommerce.Models;
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

    [HttpGet("{id}")]
    public IActionResult BuscarPorId(int id)
    {
        var pagamento = _pagamentoRepository.BuscarPorId(id);
        if (pagamento == null)
        {
            return NotFound();
        }
        return Ok(pagamento);
    }

    [HttpPost]
    public IActionResult CadastrarPagamento(PagamentoDto pagamentoDto)
    {
        _pagamentoRepository.Cadastrar(pagamentoDto);
        return Created();
    }

    [HttpPut("{id}")]
    public IActionResult Editar(int id, PagamentoDto pagamentoDto)
    {
        try
        {
            _pagamentoRepository.Atualizar(id, pagamentoDto);
            return Ok(pagamentoDto);
        }
        catch (Exception)
        {
            return NotFound();
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Deletar(int id)
    {
        try
        {
            _pagamentoRepository.Deletar(id);
            return NoContent();
        }
        catch (Exception)
        {
            return NotFound("Pagamento não encontrado.");
        }
        
    }
}
