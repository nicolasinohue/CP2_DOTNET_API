using CP2.Data.AppData;
using CP2.Domain.Entities;
using CP2.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CP2.Data.Repositories
{
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly ApplicationContext _context;

        public FornecedorRepository(ApplicationContext context)
        {
            _context = context;
        }

        public FornecedorEntity? Adicionar(FornecedorEntity fornecedor)
        {
            _context.Fornecedores.Add(fornecedor);
            _context.SaveChanges();
            return fornecedor;
        }

        public FornecedorEntity? Atualizar(FornecedorEntity fornecedor)
        {
            _context.Fornecedores.Update(fornecedor);
            _context.SaveChanges();
            return fornecedor;
        }

        public FornecedorEntity? DeletarDados(int id)
        {
            var fornecedor = _context.Fornecedores.Find(id);
            if (fornecedor != null)
            {
                _context.Fornecedores.Remove(fornecedor);
                _context.SaveChanges();
            }
            return fornecedor;
        }

        public IEnumerable<FornecedorEntity> ObterTodos()
        {
            return _context.Fornecedores.AsNoTracking().ToList();
        }

        public FornecedorEntity? ObterPorId(int id)
        {
            return _context.Fornecedores.AsNoTracking().FirstOrDefault(f => f.Id == id);
        }
    }
}