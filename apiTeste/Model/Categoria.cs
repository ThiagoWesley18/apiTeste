using System.Collections.ObjectModel;

namespace apiTeste.Model
{
    public class Categoria
    {
        public Categoria()
        {
            Produtos = new Collection<Produto>();
        }
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Image {  get; set; }

        public Collection<Produto>? Produtos { get; set; }
    }
}
