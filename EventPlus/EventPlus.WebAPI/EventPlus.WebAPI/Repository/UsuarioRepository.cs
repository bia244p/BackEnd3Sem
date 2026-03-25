using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using EventPlus.WebAPI.Utils;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.Repository;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly EventContext _context;

    public UsuarioRepository(EventContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Busca o usuário pelo email e valida o hash da senha
    /// </summary>
    /// <param name="Email">email do usuário</param>
    /// <param name="Senha">senha do usuário</param>
    /// <returns> Usuário buscado e validado</returns>

    public Usuario BuscarPorEmailESenha(string Email, string Senha)
    {
        //Primero, buscamos o Usuário pelo e-mail
        var usuarioBuscado = _context.Usuarios
              .Include(usuario => usuario.IdTipoUsuario)
              .FirstOrDefault(usuario => usuario.Email == Email);
        //verifica se o usuário realmente existe
        if (usuarioBuscado != null)
        {
            bool confere = Cripitografia.compararHash(Senha, usuarioBuscado.Senha);

            if (confere)
            {
                return usuarioBuscado;
            }
        }
        return null!;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="IdUsuario"></param>
    /// <returns></returns>
    public Usuario BuscarPorID(Guid IdUsuario)
    {
        return _context.Usuarios.Include(usuario => usuario.IdTipoUsuarioNavigation).
            FirstOrDefault(usuario => usuario.IdUsuario == IdUsuario)!;
    }

    public object? BuscarPorId(Guid id)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Cadastra um novo Usuáio com a senha Cripitografada
    /// </summary>
    /// <param name="usuario">Usuário a ser cadastrado</param>

    public void Cadastrar(Usuario usuario)
    {
        usuario.Senha = Cripitografia.GerarHash(usuario.Senha);

        _context.Usuarios.Add(usuario);
        _context.SaveChanges();
    }
}
