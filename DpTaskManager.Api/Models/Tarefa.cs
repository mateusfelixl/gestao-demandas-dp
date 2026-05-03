using System.ComponentModel.DataAnnotations;

namespace DpTaskManager.Api.Models

{
    //Criação das propriedades da Classe Tarefa
    public class Tarefa
    {
        public int Id { get; set; }

        // Anotações de validação para garantir que o título da demanda seja obrigatório e tenha um limite de caracteres.
        [Required(ErrorMessage = "O Título da demanda é obrigatório")]
        [MaxLength(100, ErrorMessage = "O Título da demanda deve conter no máximo 100 caracteres")]
        public string Titulo { get; set; } = string.Empty;
        
        [MaxLength(500, ErrorMessage = "A descrição da demanda deve conter no máximo 500 caracteres")]
        public string Descricao { get; set; } = string.Empty;

        public string Status { get; set; } = "Pendente";

        public DateTime DataCriacao { get; set; } = DateTime.Now;
    }
}

