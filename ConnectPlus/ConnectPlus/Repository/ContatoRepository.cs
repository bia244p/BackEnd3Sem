using ConnectPlus.ConnectPlusz;
using ConnectPlus.Interface;
using ConnectPlus.Models;
using System;

namespace ConnectPlus.Repository
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly ConnectPluszContext _context;

        public ContatoRepository(ConnectPluszContext context)
        {
            _context = context;
        }

        public void Atualizar(Guid id, Contato contato)
        {
            var contatoExistente = _context.Contatos.Find(id);
            if (contatoExistente != null)
            {
                contatoExistente.Nome = contato.Nome;
                contatoExistente.DadosContato = contato.DadosContato;
                contatoExistente.Imagem = contato.Imagem;
                contatoExistente.IdTipoContato = contato.IdTipoContato;
                _context.SaveChanges();
            }
        }

        public Contato BuscarPorId(Guid id)
        {
            return _context.Contatos.Find(id)!;
        }

        public void Cadastrar(Contato contato)
        {
            _context.Contatos.Add(contato);
            _context.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            var contato = _context.Contatos.Find(id);
            if (contato != null)
            {
                _context.Contatos.Remove(contato);
                _context.SaveChanges();
            }
        }

        public List<Contato> Listar()
        {
            return _context.Contatos.ToList();
        }
    }
}


