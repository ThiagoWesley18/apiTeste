using Microsoft.AspNetCore.Mvc;

namespace apiTeste.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VarAmbienteController : Controller
    {
        private readonly IConfiguration _configuration;

        public VarAmbienteController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("getChave")]
        public  ActionResult<string> Get()
        {
            try
            {
                var valor = _configuration["chave"];
                return Ok(valor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ChaveComposta")]
        public ActionResult<Object> GetChaveComposta() 
        {
            try
            {
                var valor1 = _configuration["chaveComposta:index1"];
                var valor2 = _configuration["chaveComposta:index2"];
                return Ok(new { index1=valor1,index2=valor2});
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
