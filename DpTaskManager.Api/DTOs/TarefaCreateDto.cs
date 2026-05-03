using System.ComponentModel.DataAnnotations;

namespace DpTaskManager.Api.DTOs
{
    public class TarefaCreateDto
    {
        [Required(ErrorMessage = "O Título da demanda é obrigatório")]
        [MaxLength(100, ErrorMessage = "O Título da demanda deve conter no máximo 100 caracteres")]
        public string Titulo { get; set; } = string.Empty;

        [MaxLength(500, ErrorMessage = "A descrição da demanda deve conter no máximo 500 caracteres")]
        public string? Descricao { get; set; } 
    }
}
