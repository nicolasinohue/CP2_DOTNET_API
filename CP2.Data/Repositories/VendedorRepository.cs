using CP2.Data.AppData;
using CP2.Domain.Entities;
using CP2.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CP2.Data.Repositories
{
    public class VendedorRepository : IVendedorRepository
    {
        private readonly ApplicationContext _context;

        public VendedorRepository(ApplicationContext context)
        {
            _context = context;
        }

        public VendedorEntity? Adicionar(VendedorEntity vendedor)
        {
            _context.Vendedores.Add(vendedor);
            _context.SaveChanges();
            return vendedor;
        }

        public VendedorEntity? Atualizar(VendedorEntity vendedor)
        {
            _context.Vendedores.Update(vendedor);
            _context.SaveChanges();
            return vendedor;
        }

        public VendedorEntity? DeletarDados(int id)
        {
            var vendedor = _context.Vendedores.Find(id);
            if (vendedor != null)
            {
                _context.Vendedores.Remove(vendedor);
                _context.SaveChanges();
            }
            return vendedor;
        }

        public IEnumerable<VendedorEntity> ObterTodos()
        {
            return _context.Vendedores.AsNoTracking().ToList();
        }

        public VendedorEntity? ObterPorId(int id)
        {
            return _context.Vendedores.AsNoTracking().FirstOrDefault(v => v.Id == id);
        }
    }
}