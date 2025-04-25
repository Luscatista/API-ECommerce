using API_ECommerce.Models;

namespace API_ECommerce.ViewModels
{
    public class ProdutoViewModel
    {
        public int IdProduto { get; set; }

        public string NomeProduto { get; set; } = null!;

        public string? Descricao { get; set; }

        public decimal Preco { get; set; }

        public int EstoqueDisponivel { get; set; }

        public string CategoriaProduto { get; set; } = null!;

        public string? Imagem { get; set; }
    }
}
