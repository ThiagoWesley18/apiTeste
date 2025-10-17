using apiTeste.Context;
using apiTeste.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;


namespace apiTeste.Controllers
{
    [ApiController] // Informa que é uma api com endpoints
    [Route("[controller]")] // Rota padrão "/"
    public class ProdutosController : ControllerBase // devemos colocar o nome do endpoint seguido de Controller
    {
       private readonly apiTesteContext _context;

        public ProdutosController(apiTesteContext context)
        {
            _context = context;
        }

        [HttpGet] 
        public async Task<ActionResult<IEnumerable<Produto>>> GetProdutos()
        {
            try
            {
                var produtos = await _context.Produtos?.AsNoTracking().Where(p => p.Estoque <= 500).ToListAsync();// Where filtra o retorno dos produtos para quem tiver menos que 500 no estoque.
                if (produtos is null)
                {
                    return NotFound("Produtos não encontrados");
                }
                return produtos;

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
            
        }

        [HttpGet("{id:int}", Name="ObterProduto")] // get com parametro
        public async Task<ActionResult<Produto>> GetProdutoId(int id)
        {
            try
            {
                var produto = await _context.Produtos?.AsNoTracking().FirstOrDefaultAsync(produto => produto.Id == id);// AsNoTracking() so deve ser usado se não precisar acessar o objeto no banco, entao so deve ser usasdo no Get
                if (produto is null)
                {
                    return NotFound("Produto não Encontrado.");
                }
                return produto;

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }       
        }

        [HttpPost]
        public async Task<ActionResult> Post(Produto produto)
        {
            try
            {
                if (produto is null)
                {
                    return BadRequest();
                }

                await _context.Produtos!.AddAsync(produto);
                await _context.SaveChangesAsync();

                return new CreatedAtRouteResult("ObterProduto", new { id = produto.Id }, produto);// Retorna o status code 201 e aciona a rota ObterProduto(get com parametro) para retornar o ID do produto criado pelo response.
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro na solicitação");
            }
       
        }

        [HttpPut("{id:int:min(1)}")]
        public async Task<ActionResult> PutProduto(int id, Produto produto)
        {
            try
            {

                if (id != produto.Id)
                {
                    return BadRequest();
                }
                _context.Entry(produto).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return Ok(produto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro na solicitação");
            }

        }

        [HttpDelete("{id:int:min(1)}")]
        public async Task<ActionResult> DeleteProduto(int id)
        {
            try
            {
                var produto = await _context.Produtos?.FirstOrDefaultAsync(prod => prod.Id == id);

                if (produto is null)
                {
                    return NotFound("Produto não Encontrado.");
                }

                _context.Remove(produto);
                await _context.SaveChangesAsync();

                return Ok(produto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro na solicitação");
            }
            
        }
    }
}
