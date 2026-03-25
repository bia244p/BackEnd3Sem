using System.ComponentModel.DataAnnotations;

namespace EventPlus.WebAPI.DTO;

public class UsuarioDTO
{
    [Required(ErrorMessage ="O nome do usuário é obrigratório!")]
    public string? Nome { get; set; }

    [Required(ErrorMessage = "O e-mail do usuário é obrigratório")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "A senha do usuário é obrigratório")]
    public string? Senha { get; set; }
    public Guid  IdtTipoUSuario { get; set; }
    public object IdTipoUsuario { get; internal set; }
}
