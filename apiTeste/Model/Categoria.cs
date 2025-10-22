using apiTeste.Validations;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace apiTeste.Model
{
    public class Categoria
    {
        public Categoria()
        {
            Produtos = new Collection<Produto>();
        }
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength=5)]
        [LetraMaiuscula]
        public string? Nome { get; set; }

        [Required]
        public string? Image {  get; set; }

        public Collection<Produto>? Produtos { get; set; }
    }
}
