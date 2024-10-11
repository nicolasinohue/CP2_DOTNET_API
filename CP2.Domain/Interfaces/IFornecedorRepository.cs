using CP2.Domain.Entities;
using System.Collections.Generic;

namespace CP2.Domain.Interfaces
{
    public interface IFornecedorRepository
    {
        FornecedorEntity? Adicionar(FornecedorEntity fornecedor);
        FornecedorEntity? Atualizar(FornecedorEntity fornecedor);
        FornecedorEntity? DeletarDados(int id);
        IEnumerable<FornecedorEntity> ObterTodos();
        FornecedorEntity? ObterPorId(int id);
    }
}