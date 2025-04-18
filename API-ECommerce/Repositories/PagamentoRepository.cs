using API_ECommerce.Context;
using API_ECommerce.Interfaces;
using API_ECommerce.Models;

namespace API_ECommerce.Repositories;

public class PagamentoRepository : IPagamentoRepository
{
    private readonly EcommerceContext _context;
    public PagamentoRepository(EcommerceContext context)
    {
        _context = context;
    }
    public List<Pagamento> ListarTodos()
    {
        return _context.Pagamentos.ToList();
    }
    public Pagamento BuscarPorId(int id)
    {
        return _context.Pagamentos.FirstOrDefault(p => p.IdPagamento == id);
    }
    public void Cadastrar(Pagamento pagamento)
    {
        _context.Pagamentos.Add(pagamento);
        _context.SaveChanges();
    }
    public void Atualizar(int id, Pagamento pagamento)
    {
        var pagamentoAtual = _context.Pagamentos.FirstOrDefault(p => p.IdPagamento == id);

        if(pagamentoAtual == null)
        {
            throw new Exception();
        }

        pagamentoAtual.StatusPagamento = pagamento.StatusPagamento;
        pagamentoAtual.FormaPagamento = pagamento.FormaPagamento;
        pagamentoAtual.DataPagamento = pagamento.DataPagamento;
        pagamentoAtual.IdPedido = pagamento.IdPedido;
        
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
