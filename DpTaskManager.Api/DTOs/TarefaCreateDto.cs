using System.ComponentModel.DataAnnotations;

namespace DpTaskManager.Api.DTOs
{
    // DTO responsável por receber os dados do Front-end no momento da CRIAÇÃO(POST) de uma demanda.
    // Ele expõe apenas os campos que o usuário tem permissão para preencher (Título e Descrição).
    // Protege o sistema impedindo que o usuário envie um ID, um Status forçado ou manipule a Data de Criação.
    public class TarefaCreateDto
    {
        [Required(ErrorMessage = "O Título da demanda é obrigatório")]
        [MaxLength(100, ErrorMessage = "O Título da demanda deve conter no máximo 100 caracteres")]
        public string Titulo { get; set; } = string.Empty;

        [MaxLength(500, ErrorMessage = "A descrição da demanda deve conter no máximo 500 caracteres")]
        public string? Descricao { get; set; } 
    }
}
