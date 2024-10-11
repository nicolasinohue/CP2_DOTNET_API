using CP2.Domain.Entities;
using System.Collections.Generic;

namespace CP2.Domain.Interfaces
{
    public interface IVendedorRepository
    {
        VendedorEntity? Adicionar(VendedorEntity vendedor);
        VendedorEntity? Atualizar(VendedorEntity vendedor);
        VendedorEntity? DeletarDados(int id);
        IEnumerable<VendedorEntity> ObterTodos();
        VendedorEntity? ObterPorId(int id);
    }
}