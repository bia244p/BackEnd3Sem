using ConnectPlus.BdContextConnectPlus;
using ConnectPlus.Interface;
using ConnectPlus.Models;
using System;

namespace ConnectPlus.Repository
{
    public class TipoContatoRepository : ITipoContatoRepository
    {
        private readonly ConnectContext _context;

        public TipoContatoRepository(ConnectContext context)
        {
            _context = context;
        }

        public void Atualizar(Guid id, TipoContato tipoContato)
        {
            var tipoContatoExistente = _context.TipoContatos.Find(id);
            if (tipoContatoExistente != null)
            {
                tipoContatoExistente.Titulo = tipoContato.Titulo;
                _context.SaveChanges();
            }
        }

        public TipoContato BuscarPorId(Guid id)
        {
            return _context.TipoContatos.Find(id)!;
        }

        public void Cadastrar(TipoContato tipoContato)
        {
            tipoContato.IdTipoContato = Guid.NewGuid();

            _context.TipoContatos.Add(tipoContato);
            _context.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            var tipoContato = _context.TipoContatos.Find(id);
            if (tipoContato != null)
            {
                _context.TipoContatos.Remove(tipoContato);
                _context.SaveChanges();
            }
        }

        public List<TipoContato> Listar()
        {
            return _context.TipoContatos.ToList();
        }
    }
}
