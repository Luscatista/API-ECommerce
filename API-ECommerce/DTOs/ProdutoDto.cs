namespace API_ECommerce.DTOs;

public class ProdutoDto
{
    public string NomeProduto { get; set; } = null!;

    public string? Descricao { get; set; }

    public decimal Preco { get; set; }

    public int EstoqueDisponivel { get; set; }

    public string CategoriaProduto { get; set; } = null!;

    public string? Imagem { get; set; }
}
