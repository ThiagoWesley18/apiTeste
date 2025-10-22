using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using apiTeste.Context;
using apiTeste.Model;
using System.Collections;
using apiTeste.Filter;

namespace apiTeste.Controllers
{
    [ApiController] // Informa que é uma api com endpoints
    [Route("[controller]")] // Rota padrão "/"
    public class CategoriasController : Controller
    {
        private readonly apiTesteContext _context;

        public CategoriasController(apiTesteContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ServiceFilter(typeof(LoggingFilter))]
        public async Task<ActionResult<IEnumerable<Categoria>>> Get()
        {
            try
            {
                var categoria =await _context.Categorias?.AsNoTracking().Where(c => !c.Image.EndsWith("jpg")).ToListAsync();//Where serve para filtrar o retorno do banco

                if (categoria is null)
                {
                    return NotFound("Produtos não encontrados");
                }
                return categoria;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro na solicitação");
            }
            
        }

        [HttpGet("Produtos")]
        [ServiceFilter(typeof(LoggingFilter))]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategoriaProduto()
        {
            try
            {
                // AsNoTracking() so deve ser usado se não precisar acessar o objeto no banco, entao so deve ser usasdo no Get
                // Take(2) retorna somente os 2 primeiros registros
                return await _context.Categorias.AsNoTracking().Include(categoria => categoria.Produtos).Take(2).ToListAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro na solicitação");
            }
           
        }

        [HttpGet("{id:int}", Name = "ObterCategoria")]
        [ServiceFilter(typeof(LoggingFilter))]
        public async Task<ActionResult<Categoria>> Get(int id)
        {
            try
            {
                var categoria = await _context.Categorias?.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
                if (categoria is null)
                {
                    return NotFound("Categoria não encontrada..");
                }

                return categoria;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro na solicitação");
            }
        }
            

        [HttpPost]
        [ServiceFilter(typeof(LoggingFilter))]
        public async Task<ActionResult> Post(Categoria categoria)
        {
            if (categoria is null)
            {
                return BadRequest();
            }

            await _context.Categorias!.AddAsync(categoria);
            await _context.SaveChangesAsync();

            return new CreatedAtRouteResult("ObterCategoria", new { id = categoria.Id }, categoria);

        }

        [HttpPut("{id:int}")]
        [ServiceFilter(typeof(LoggingFilter))]
        public async Task<ActionResult> Put(int id, Categoria categoria)
        {
            try
            {
                if (id != categoria.Id)
                {
                    return BadRequest();
                }


                _context.Entry(categoria).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return Ok(categoria);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro na solicitação");
            }
           
        }

        [HttpDelete("{id:int}")]
        [ServiceFilter(typeof(LoggingFilter))]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var categoria = await _context.Categorias?.FirstOrDefaultAsync(cat => cat.Id == id);

                if (categoria is null)
                {
                    return NotFound("Categoria não Encontrada.");
                }

                _context.Remove(categoria);
                await _context.SaveChangesAsync();

                return Ok(categoria);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro na solicitação");
            }
            
        }
    }
}
