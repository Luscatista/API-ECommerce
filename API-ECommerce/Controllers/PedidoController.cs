using API_ECommerce.Context;
using API_ECommerce.Interfaces;
using API_ECommerce.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API_ECommerce.Controllers
{
    public class PedidoController : Controller
    {
        private readonly EcommerceContext _context;
        private IPedidoRepository _pedidoRepository;
        public PedidoController(EcommerceContext context)
        {
            _context = context;
            _pedidoRepository = new PedidoRepository(_context);

        }
    }
}
