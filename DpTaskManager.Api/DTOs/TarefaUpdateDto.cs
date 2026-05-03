using System.ComponentModel.DataAnnotations;

namespace DpTaskManager.Api.DTOs
{
    // DTO responsável por receber os dados do Front-end no momento da ATUALIZAÇÃO(PUT) de uma demanda.
    // DTO exige o envio do Status 
    // Garante a integridade da base de dados por não possuir o campo DataCriacao, impedindo
    // que a data original do documento seja alterada acidentalmente durante uma edição.
    public class TarefaUpdateDto
    {
        [Required(ErrorMessage = "O título é obrigatório.")]
        [MaxLength(100)]
        public string Titulo { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Descricao { get; set; }

        [Required]
        public string Status { get; set; } = string.Empty;
    }
}
