using CP2.Domain.Entities;
using CP2.Domain.Interfaces.Dtos;

namespace CP2.Domain.Interfaces
{
    public interface IVendedorApplicationService
    {
        IEnumerable<VendedorEntity> ObterTodosVendedores();
        VendedorEntity? ObterVendedorPorId(int id);
        VendedorEntity? SalvarDadosVendedor(IVendedorDto vendedorDto);
        VendedorEntity? EditarDadosVendedor(int id, IVendedorDto vendedorDto);
        VendedorEntity? DeletarDadosVendedor(int id);
    }
}