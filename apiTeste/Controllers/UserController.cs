using apiTeste.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace apiTeste.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class UserController : Controller
    {
        [HttpGet("saudar/{nome}")]
        public ActionResult<string> saudar(IMeuService saudar, string nome)
        {
            return saudar.Saudar(nome);
        }

        [HttpGet("saudar2/{nome}")]
        public ActionResult<string> saudar2(IMeuService2 saudar, string nome, [BindRequired] string sobrenome) // BindRequeride obriga a vir paramentro na query get.
        {
            return saudar.Saudar2(nome, sobrenome);
        }
    }
}
