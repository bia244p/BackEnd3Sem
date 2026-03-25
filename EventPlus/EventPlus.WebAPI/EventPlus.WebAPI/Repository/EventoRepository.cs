using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebApi.Repositories;

public class EventoRepository : IEventoRepository
{
    private EventContext _context;

    public EventoRepository(EventContext context)
    {
        _context = context;
    }

    public void Atualizar(Guid Id, Evento evento)
    {
        var EventoBuscado = _context.Eventos.Find(Id);

        if (EventoBuscado != null)
        {
            EventoBuscado.Nome = evento.Nome;
            EventoBuscado.Descricao = evento.Descricao;
            EventoBuscado.DataEvento = evento.DataEvento;
            _context.SaveChanges();
        }
    }

    public Evento BuscarPorId(Guid Id)
    {
        return _context.Eventos.Find(Id)!;
    }

    public void Cadastrar(Evento evento)
    {
        _context.Eventos.Add(evento);
        _context.SaveChanges();
    }

    public void Deletar(Guid id)
    {
        var EventoBuscado = _context.Eventos.Find(id);

        if (EventoBuscado != null)
        {
            _context.Eventos.Remove(EventoBuscado);
            _context.SaveChanges();                                           
        }
    }

    public List<Evento> Listar()
    {
        return _context.Eventos.OrderBy(Eventos => Eventos.Nome).ToList();
    }

    /// <summary>
    /// Método que lista eventos filtrando pelas presencas de um usuário
    /// </summary>
    /// <param name="IdUsuario">Id do usuário para filtragem</param>
    /// <returns>Lista de eventos filtrados pelo usuário</returns>
    public List<Evento> ListarPorId(Guid IdUsuario)
    {
        return _context.Eventos
            .Include(e => e.IdTipoEventoNavigation)
            .Include(e => e.IdInstituicaoNavigation)
            .Where(e => e.Presencas.Any(p => p.IdUsuario == IdUsuario && p.Situacao == true))
            .ToList()!;
    }

    /// <summary>
    /// Metodo que retorna os próximos eventos que irão acontecer
    /// </summary>
    /// <returns>Lista de próximos eventos</returns>
    public List<Evento> ListarProximos()
    {
        return _context.Eventos
            .Include(e => e.IdTipoEventoNavigation)
            .Include(e => e.IdInstituicaoNavigation)
            .Where(e => e.DataEvento >= DateTime.Now)
            .OrderBy(e => e.DataEvento)
            .ToList()!;
    }
}
