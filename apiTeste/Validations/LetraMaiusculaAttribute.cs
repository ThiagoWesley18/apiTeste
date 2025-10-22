using System.ComponentModel.DataAnnotations;

namespace apiTeste.Validations
{
    public class LetraMaiusculaAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var primeiraLetra = value.ToString()[0].ToString();
            if (primeiraLetra != primeiraLetra.ToUpper())
            {
                return new ValidationResult("A primeira Letra tem que ser Maiuscula");
            }
            return ValidationResult.Success;
        }
    }
}
