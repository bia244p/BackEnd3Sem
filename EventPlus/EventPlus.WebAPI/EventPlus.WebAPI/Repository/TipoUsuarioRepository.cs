using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interface;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;

namespace EventPlus.WebAPI.Repositories;

public class TipoUsuarioRepository : ITipoUsuarioRepository
{
    private readonly EventContext _Context;
    public TipoUsuarioRepository(EventContext context)
    {
        _Context = context;
    }
    public void Atualizar(Guid id, TipoUsuario tipoUsuario)
    {
        var TipoUsuarioBuscado = _Context.TipoUsuarios.Find(id);
        if (TipoUsuarioBuscado != null)
        {
            TipoUsuarioBuscado.Titulo = tipoUsuario.Titulo;
            _Context.SaveChanges();

        }
    }

    public TipoUsuario BuscarPorId(Guid id)
    {
        return _Context.TipoUsuarios.Find(id);
    }

    public void Cadastrar(TipoUsuario tipoUsuario)
    {
        _Context.TipoUsuarios.Add(tipoUsuario);
        _Context.SaveChanges();
    }

    public void Deletar(Guid id)
    {
        var TipoUsuarioBuscado = _Context.TipoUsuarios.Find(id);
        if (TipoUsuarioBuscado != null)
        {
            _Context.TipoUsuarios.Remove(TipoUsuarioBuscado);
            _Context.SaveChanges();
        }
    }

    public List<TipoUsuario> Listar()
    {
        return _Context.TipoUsuarios.OrderBy(TipoUsuarios => TipoUsuarios.Titulo).ToList();
    }
}



