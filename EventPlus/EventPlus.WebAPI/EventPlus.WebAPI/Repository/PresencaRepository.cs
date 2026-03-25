using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebApi.Repositories;

public class PresencaRepository : IPresencaRepository
{
    private readonly EventContext _context;

    public PresencaRepository(EventContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Metodo que alterna a situacao da presenca
    /// </summary>
    /// <param name="Id">id da presenca a ser alterada</param>
    public void Atualizar(Guid Id)
    {
        var presencaBuscada = _context.Presencas.Find(Id);

        if (presencaBuscada != null)
        {
            presencaBuscada.Situacao = !presencaBuscada.Situacao;

            _context.SaveChanges();
        }

    }

    /// <summary>
    /// Método que busca uma presenca por id
    /// </summary>
    /// <param name="Id"> id da presenca a ser buscada</param>
    /// <returns>presenca buscada</returns>
    public Presenca BuscarPorId(Guid Id)
    {
        return _context.Presencas
            .Include(p => p.IdEventoNavigation)
                .ThenInclude(E => E!.IdInstituicaoNavigation)
            .FirstOrDefault(p => p.IdPresenca == Id)!;
    }

    public void Deletar(Guid Id)
    {
        Presenca presencaBuscada = _context.Presencas.Find(Id)!;

        if (presencaBuscada != null)
        {
            _context.Presencas.Remove(presencaBuscada);
            _context.SaveChanges();
        }
    }

    public void Inscrever(Presenca presenca)
    {
        _context.Presencas.Add(presenca);
        _context.SaveChanges();
    }

    public List<Presenca> Listar(Guid IdEvento)
    {
        return _context.Presencas.Where(p => p.IdEvento == IdEvento).ToList();
    }

    public List<Presenca> Listar()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Método que lista as presencas de um usuário específico
    /// </summary>
    /// <param name="IdUsuario">id do usuário para filtragem </param>
    /// <returns>lista de presencas de um usuário </returns>
    public List<Presenca> ListarMinhas(Guid IdUsuario)
    {
        return _context.Presencas
            .Include(p => p.IdEventoNavigation)
            .ThenInclude(e => e!.IdInstituicaoNavigation)
            .Where(p => p.IdUsuario == IdUsuario)
            .ToList();

    }
}
