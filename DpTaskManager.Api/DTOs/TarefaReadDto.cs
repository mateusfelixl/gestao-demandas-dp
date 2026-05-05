namespace DpTaskManager.Api.DTOs
{
    // DTO responsável por enviar os dados da API de volta para a tela do usuário(GET).
    // Funciona como uma "Xerox segura" da entidade oficial do banco de dados, 
    // garantindo que apenas as informações públicas e necessárias cheguem ao Front-end (Angular),
    // ocultando qualquer dado sensível futuro que a entidade possa ter.
    public class TarefaReadDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string? Descricao { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime DataCriacao { get; set; }
    }
}
