using API_ECommerce.Context;
using API_ECommerce.Interfaces;
using API_ECommerce.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API_ECommerce.Controllers;

public class ClienteController : Controller
{
    private readonly EcommerceContext _context;
    private IClienteRepository _clienteRepository;
    public ClienteController(EcommerceContext context)
    {
        _context = context;
        _clienteRepository = new ClienteRepository(_context);

    }
}
