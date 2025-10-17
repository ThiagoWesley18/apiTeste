using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace apiTeste.Model
{
    public class Produto
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Preco { get; set; }
        public float Estoque { get; set; }
        public string? Imagem { get; set; }
        public DateTime DataCadastro { get; set; }

        public int CategoriaId { get; set; }

        [JsonIgnore]
        public Categoria? Categoria { get; set; }
    }
}
