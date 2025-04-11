using API_ECommerce.Context;
using API_ECommerce.Interfaces;
using API_ECommerce.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API_ECommerce.Controllers;

public class PagamentoController : Controller
{
    private readonly EcommerceContext _context;
    private IPagamentoRepository _pagamentoRepository;
    public PagamentoController(EcommerceContext context)
    {
        _context = context;
        _pagamentoRepository = new PagamentoRepository(_context);

    }
}
