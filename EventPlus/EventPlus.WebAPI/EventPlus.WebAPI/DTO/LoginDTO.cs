using System.ComponentModel.DataAnnotations;

namespace EventPlus.WebApi.DTO;

public class LoginDTO
{
    [Required(ErrorMessage = "O email de usuário é obrigatório para o login")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "A senha de usuário é obrigatório para o login")]
    public string? Senha { get; set; }
}