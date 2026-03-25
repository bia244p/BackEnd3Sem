using System.ComponentModel.DataAnnotations;

namespace EventPlus.WebApi.DTO;

public class EventoDTO
{
    [Required(ErrorMessage = "O nome do evento é obrigatório")]
    public string? Nome { get; set; }

    [Required(ErrorMessage = "A descrição do evento é orbigatória")]
    public string? Descricao { get; set; }

    [Required(ErrorMessage = "A data do evento é obrigatório")]
    public DateTime DataEvento { get; set; }
}
