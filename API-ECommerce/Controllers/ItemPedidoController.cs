using API_ECommerce.Context;
using API_ECommerce.Interfaces;
using API_ECommerce.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API_ECommerce.Controllers
{
    public class ItemPedidoController : Controller
    {
        private readonly EcommerceContext _context;
        private IItemPedidoRepository _itemPedidoRepository;
        public ItemPedidoController(EcommerceContext context)
        {
            _context = context;
            _itemPedidoRepository = new ItemPedidoRepository(_context);

        }
    }
}
