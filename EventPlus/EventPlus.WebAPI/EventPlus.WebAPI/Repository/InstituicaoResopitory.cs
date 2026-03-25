using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interface;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;

namespace EventPlus.WebAPI.Repositories;

public class InstituicaoRepository : IInstituicaoRepository
{
    private readonly EventContext _Context;
    public InstituicaoRepository(EventContext context)
    {
        _Context = context;
    }
    public void Atualizar(Guid id, Instituicao instituicao)
    {
        var instituicaoExistente = _Context.Instituicaos.Find(id);
        if (instituicaoExistente == null)
        {
            instituicaoExistente.NomeFantasia = instituicao.NomeFantasia;
            instituicaoExistente.Endereco = instituicao.Endereco;
            instituicaoExistente.Cnpj = instituicao.Cnpj;
            _Context.SaveChanges();
        }
    }

    public Instituicao BuscarPorId(Guid id)
    {
        return _Context.Instituicaos.Find(id);
    }

    public void Cadastrar(Instituicao instituicao)
    {
        _Context.Instituicaos.Add(instituicao);
        _Context.SaveChanges();
    }

    public void Deletar(Guid IdInstituicao)
    {
        var instituicaoExistente = _Context.Instituicaos.Find(IdInstituicao);
        if (instituicaoExistente != null)
        {
            _Context.Instituicaos.Remove(instituicaoExistente);
            _Context.SaveChanges();
        }
    }

    public List<Instituicao> Listar()
    {
        return _Context.Instituicaos.OrderBy(instituicao => instituicao.NomeFantasia).ToList();
    }
}
