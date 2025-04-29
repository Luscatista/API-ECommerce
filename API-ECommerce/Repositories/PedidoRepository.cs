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
        var pedido = _context.Pedidos.FirstOrDefault(p => p.IdPedido == id);
        
        return pedido;
    }
    public void Cadastrar(PedidoDto pedidoDto)
    {
        var pedidoNovo = new Pedido
        {
            DataPedido = pedidoDto.DataPedido,
            Status = pedidoDto.Status,
            ValorTotal = pedidoDto.ValorTotal,
            IdCliente = pedidoDto.IdCliente
        };

        _context.Pedidos.Add(pedidoNovo);
        _context.SaveChanges();

        for (int i = 0; i < pedidoDto.Produtos.Count; i++)
        {
            var produto = _context.Produtos.Find(pedidoDto.Produtos[i]);

            var itemPedido = new ItemPedido
            {
                IdPedido = pedidoNovo.IdPedido,
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
        var pedido = _context.Pedidos.Find(id);

        if (pedido == null)
        {
            throw new Exception("Não encontrado.");
        }

        _context.Pedidos.Remove(pedido);

        _context.SaveChanges();
    }
}
