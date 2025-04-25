using API_ECommerce.Context;
using API_ECommerce.DTOs;
using API_ECommerce.Interfaces;
using API_ECommerce.Models;
using API_ECommerce.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace API_ECommerce.Repositories;

public class PagamentoRepository : IPagamentoRepository
{
    private readonly EcommerceContext _context;
    public PagamentoRepository(EcommerceContext context)
    {
        _context = context;
    }
    public List<PagamentoViewModel> ListarTodos()
    {
        return _context.Pagamentos.Select(
            p => new PagamentoViewModel
            {
                IdPagamento = p.IdPagamento,
                IdPedido = p.IdPedido,
                StatusPagamento = p.StatusPagamento,
                FormaPagamento = p.FormaPagamento,
                DataPagamento = p.DataPagamento
            }).ToList();
    }
    public PagamentoViewModel? BuscarPorId(int id)
    {
        return _context.Pagamentos.Select(
            p => new PagamentoViewModel
            {
                IdPagamento = p.IdPagamento,
                IdPedido = p.IdPedido,
                StatusPagamento = p.StatusPagamento,
                FormaPagamento = p.FormaPagamento,
                DataPagamento = p.DataPagamento
            }).FirstOrDefault(p => p.IdPagamento == id);
    }
    public void Cadastrar(PagamentoDto pagamentoDto)
    {
        var Pagamento = new Pagamento
        {
            StatusPagamento = pagamentoDto.StatusPagamento,
            FormaPagamento = pagamentoDto.FormaPagamento,
            DataPagamento = pagamentoDto.DataPagamento,
            IdPedido = pagamentoDto.IdPedido
        };
        _context.Pagamentos.Add(Pagamento);
        _context.SaveChanges();
    }
    public void Atualizar(int id, PagamentoDto pagamentoDto)
    {
        var pagamento = _context.Pagamentos.FirstOrDefault(p => p.IdPagamento == id);

        if(pagamento == null)
        {
            throw new Exception("Pagamento não encontrado.");
        }

        pagamento.StatusPagamento = pagamentoDto.StatusPagamento;
        pagamento.FormaPagamento = pagamentoDto.FormaPagamento;
        pagamento.DataPagamento = pagamentoDto.DataPagamento;
        pagamento.IdPedido = pagamentoDto.IdPedido;
        
        _context.SaveChanges();
    }
    public void Deletar(int id)
    {
        var pagamento = _context.Pagamentos.Find(id);

        if (pagamento == null)
        {
            throw new Exception();
        }

        _context.Pagamentos.Remove(pagamento);

        _context.SaveChanges();
    }
}
