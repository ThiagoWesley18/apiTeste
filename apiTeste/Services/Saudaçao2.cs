namespace apiTeste.Services
{
    public class Saudaçao2 : IMeuService2
    {
        public string Saudar2(string nome, string sobrenome)
        {
            return $"Bem vindo {nome} {sobrenome}";
        }
    }
}
