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
        throw new NotImplementedException();
    }
    public void Cadastro(Pagamento pagamento)
    {
        throw new NotImplementedException();
    }
    public void Atualizar(int id, Pagamento pagamento)
    {
        throw new NotImplementedException();
    }
    public void Deletar(int id)
    {
        throw new NotImplementedException();
    }
}
