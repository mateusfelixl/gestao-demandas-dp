using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DpTaskManager.Api.Data;
using DpTaskManager.Api.Models;

namespace DpTaskManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TarefasController(AppDbContext context)
        {
            _context = context;
        }

        // POST: api/Tarefas
        // Método responsável por receber os dados do Front-end (Angular/Swagger) 
        // e cadastrar uma nova demanda do Departamento Pessoal no banco de dados.
        [HttpPost]
        public async Task<ActionResult<Tarefa>> PostTarefas(Tarefa tarefa)
        {
            tarefa.Status = "pendente";
            tarefa.DataCriacao = DateTime.Now;

            _context.Tarefas.Add(tarefa);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTarefa), new { id = tarefa.Id }, tarefa);
        }

        // GET: api/Tarefas/5
        // Método responsável por buscar os detalhes de uma demanda específica usando o seu ID exclusivo.
        [HttpGet("{id}")]
        public async Task<ActionResult<Tarefa>> GetTarefa(int id)
        {
            var tarefa = await _context.Tarefas.FindAsync(id);

            if (tarefa == null)
            {
                return NotFound();
            }

            return tarefa;
        }

        // PUT: api/Tarefas/5
        // Método responsável por atualizar os dados ou o status de uma demanda existente.
        // Exige que o ID passado na URL seja idêntico ao ID do objeto enviado.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTarefa(int id, Tarefa tarefa)
        {
            if (id != tarefa.Id)
            {
                return BadRequest();
            }

            _context.Entry(tarefa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TarefaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();

        }
        // Método auxiliar privado(Detetive)
        // Utiliza LINQ para fazer uma verificação ultrarrápida no banco de dados.
        // Retorna true se encontrar alguma tarefa com o ID informado, e false se não encontrar.
        private bool TarefaExists(int id)
        {
            return _context.Tarefas.Any(e => e.Id == id);
        }

        // DELETE: api/Tarefas/5
        // Método responsável por excluir uma demanda permanentemente do banco de dados.
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTarefa(int id)
        {
            var tarefa = await _context.Tarefas.FindAsync(id);
            if (tarefa == null)
            {
                return NotFound();
            }

            _context.Tarefas.Remove(tarefa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/Tarefas
        // Método responsável por buscar TODAS as demandas cadastradas no banco de dados.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tarefa>>> GetTarefas()
        {
            var tarefas = await _context.Tarefas.ToListAsync();

            return tarefas;
        }
    }
}
