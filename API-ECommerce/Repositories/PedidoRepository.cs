using API_ECommerce.Context;
using API_ECommerce.DTOs;
using API_ECommerce.Interfaces;
using API_ECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace API_ECommerce.Repositories;

public class PedidoRepository : IPedidoRepository
{
    private readonly EcommerceContext _context;
    public PedidoRepository(EcommerceContext context)
    {
        _context = context;
    }
    public List<Pedido> ListarTodos()
    {
        return _context.Pedidos
            .Include(p => p.ItemPedidos)
            .ThenInclude(p => p.IdProdutoNavigation)
            .ToList();
    }
    public Pedido? BuscarPorId(int id)
    {
        return _context.Pedidos.FirstOrDefault(p => p.IdPedido == id);
    }
    public void Cadastrar(PedidoDto pedidoDto)
    {
        var pedido = new Pedido
        {
            DataPedido = pedidoDto.DataPedido,
            Status = pedidoDto.Status,
            ValorTotal = pedidoDto.ValorTotal,
            IdCliente = pedidoDto.IdCliente
        };

        _context.Pedidos.Add(pedido);
        _context.SaveChanges();

        for (int i = 0; i < pedidoDto.Produtos.Count; i++)
        {
            var produto = _context.Produtos.Find(pedidoDto.Produtos[i]);

            var itemPedido = new ItemPedido
            {
                IdPedido = pedido.IdPedido,
                IdProduto = produto.IdProduto,
                Quantidade = 0
            };
                _context.ItemPedidos.Add(itemPedido);
                _context.SaveChanges();
        }
    }
    public void Atualizar(int id, PedidoDto pedidoDto)
    {
        var pedido = _context.Pedidos.FirstOrDefault(p => p.IdPedido == id);

        if(pedido == null)
        {
            throw new Exception("Pedido não encontrado.");
        }

        pedido.Status = pedidoDto.Status;
        pedido.IdCliente = pedidoDto.IdCliente;
        pedido.ValorTotal = pedidoDto.ValorTotal;
        pedido.DataPedido = pedidoDto.DataPedido;

        _context.SaveChanges();
    }
    public void Deletar(int id)
    {
        var pedido = _context.Produtos.Find(id);

        if (pedido == null)
        {
            throw new Exception("Pedido não encontrado.");
        }

        _context.Produtos.Remove(pedido);

        _context.SaveChanges();
    }
}
