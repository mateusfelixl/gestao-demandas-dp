using DpTaskManager.Api.Data;
using DpTaskManager.Api.DTOs;
using DpTaskManager.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<ActionResult<Tarefa>> PostTarefas(TarefaCreateDto tarefaDto)
        {
            var tarefa = new Tarefa
            {
                Titulo = tarefaDto.Titulo,
                Descricao = tarefaDto.Descricao ?? string.Empty,
                Status = "Pendente",
                DataCriacao = DateTime.Now
            };

            _context.Tarefas.Add(tarefa);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTarefa), new { id = tarefa.Id }, tarefa);
        }

        // GET: api/Tarefas/5
        // Método responsável por buscar os detalhes de uma demanda específica usando o seu ID exclusivo.
        [HttpGet("{id}")]
        public async Task<ActionResult<TarefaReadDto>> GetTarefa(int id)
        {
            var tarefa = await _context.Tarefas.FindAsync(id);

            if (tarefa == null)
            {
                return NotFound();
            }

            var tarefaDto = new TarefaReadDto
            {
                Id = tarefa.Id,
                Titulo = tarefa.Titulo,
                Descricao = tarefa.Descricao,
                Status = tarefa.Status,
                DataCriacao = tarefa.DataCriacao
            };

            return tarefaDto;
        }

        // PUT: api/Tarefas/5
        // Método responsável por atualizar os dados ou o status de uma demanda existente.
        // Exige que o ID passado na URL seja idêntico ao ID do objeto enviado.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTarefa(int id, TarefaUpdateDto tarefaDto) // Recebe o DTO em vez da Entidade
        {
            var tarefa = await _context.Tarefas.FindAsync(id);

            if (tarefa == null)
            {
                return NotFound();
            }

            tarefa.Titulo = tarefaDto.Titulo;
            tarefa.Descricao = tarefaDto.Descricao ?? string.Empty; 
            tarefa.Status = tarefaDto.Status;

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
        public async Task<ActionResult<IEnumerable<TarefaReadDto>>> GetTarefas()
        {
            var tarefas = await _context.Tarefas
                .Select(t => new TarefaReadDto
                {
                    Id = t.Id,
                    Titulo = t.Titulo,
                    Descricao = t.Descricao,
                    Status = t.Status,
                    DataCriacao = t.DataCriacao
                })
                .ToListAsync();

            return tarefas;
        }
    }
}
