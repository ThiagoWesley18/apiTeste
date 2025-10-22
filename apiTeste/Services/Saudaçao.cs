namespace apiTeste.Services
{
    public class Saudaçao : IMeuService
    {
        public string Saudar(string nome)
        {
            return $"Bem vindo {nome}";
        }

        
    }
}
