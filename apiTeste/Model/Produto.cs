using apiTeste.Validations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace apiTeste.Model
{
    [Table("Produtos")]
    public class Produto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50,MinimumLength=50)]
        [LetraMaiuscula]
        public string? Nome { get; set; }

        [Required]
        [Range(1,100,ErrorMessage ="Tem que estar entre {1} e {2}")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Preco { get; set; }

        [Required]
        
        public float Estoque { get; set; }

        [Required]
        public string? Imagem { get; set; }
        public DateTime DataCadastro { get; set; }

        [Required]
        public int CategoriaId { get; set; }

        [JsonIgnore]
        public Categoria? Categoria { get; set; }
    }
}
