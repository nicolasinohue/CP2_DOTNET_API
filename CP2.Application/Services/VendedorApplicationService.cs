using CP2.Domain.Entities;
using CP2.Domain.Interfaces;
using CP2.Domain.Interfaces.Dtos;

namespace CP2.Application.Services
{
    public class VendedorApplicationService : IVendedorApplicationService
    {
        private readonly IVendedorRepository _repository;

        public VendedorApplicationService(IVendedorRepository repository)
        {
            _repository = repository;
        }

        public VendedorEntity? DeletarDadosVendedor(int id)
        {
            return _repository.DeletarDados(id);
        }

        public IEnumerable<VendedorEntity> ObterTodosVendedores()
        {
            return _repository.ObterTodos();
        }

        public VendedorEntity? ObterVendedorPorId(int id)
        {
            return _repository.ObterPorId(id);
        }

        public VendedorEntity? AdicionarVendedor(VendedorEntity vendedor)
        {
            return _repository.Adicionar(vendedor);
        }

        public VendedorEntity? AtualizarVendedor(VendedorEntity vendedor)
        {
            return _repository.Atualizar(vendedor);
        }

        public VendedorEntity? SalvarDadosVendedor(IVendedorDto vendedorDto)
        {
            var vendedor = new VendedorEntity
            {
                Nome = vendedorDto.Nome,
                Email = vendedorDto.Email,
                Telefone = vendedorDto.Telefone,
                DataNascimento = vendedorDto.DataNascimento,
                Endereco = vendedorDto.Endereco,
                DataContratacao = vendedorDto.DataContratacao,
                ComissaoPercentual = vendedorDto.ComissaoPercentual,
                MetaMensal = vendedorDto.MetaMensal,
                CriadoEm = DateTime.Now
            };

            return _repository.Adicionar(vendedor);
        }

        public VendedorEntity? EditarDadosVendedor(int id, IVendedorDto vendedorDto)
        {
            var vendedor = _repository.ObterPorId(id);
            if (vendedor == null)
            {
                return null;
            }

            vendedor.Nome = vendedorDto.Nome;
            vendedor.Email = vendedorDto.Email;
            vendedor.Telefone = vendedorDto.Telefone;
            vendedor.DataNascimento = vendedorDto.DataNascimento;
            vendedor.Endereco = vendedorDto.Endereco;
            vendedor.DataContratacao = vendedorDto.DataContratacao;
            vendedor.ComissaoPercentual = vendedorDto.ComissaoPercentual;
            vendedor.MetaMensal = vendedorDto.MetaMensal;

            return _repository.Atualizar(vendedor);
        }
    }
}