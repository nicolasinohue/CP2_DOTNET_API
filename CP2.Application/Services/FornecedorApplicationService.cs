using CP2.Domain.Entities;
using CP2.Domain.Interfaces;
using CP2.Domain.Interfaces.Dtos;

namespace CP2.Application.Services
{
    public class FornecedorApplicationService : IFornecedorApplicationService
    {
        private readonly IFornecedorRepository _repository;

        public FornecedorApplicationService(IFornecedorRepository repository)
        {
            _repository = repository;
        }

        public FornecedorEntity? DeletarDadosFornecedor(int id)
        {
            return _repository.DeletarDados(id);
        }

        public IEnumerable<FornecedorEntity> ObterTodosFornecedores()
        {
            return _repository.ObterTodos();
        }

        public FornecedorEntity? ObterFornecedorPorId(int id)
        {
            return _repository.ObterPorId(id);
        }

        public FornecedorEntity? AdicionarFornecedor(FornecedorEntity fornecedor)
        {
            return _repository.Adicionar(fornecedor);
        }

        public FornecedorEntity? AtualizarFornecedor(FornecedorEntity fornecedor)
        {
            return _repository.Atualizar(fornecedor);
        }

        public FornecedorEntity? SalvarDadosFornecedor(IFornecedorDto fornecedorDto)
        {
            var fornecedor = new FornecedorEntity
            {
                Nome = fornecedorDto.Nome,
                CNPJ = fornecedorDto.CNPJ,
                Endereco = fornecedorDto.Endereco,
                Telefone = fornecedorDto.Telefone,
                Email = fornecedorDto.Email,
                CriadoEm = DateTime.Now
            };

            return _repository.Adicionar(fornecedor);
        }

        public FornecedorEntity? EditarDadosFornecedor(int id, IFornecedorDto fornecedorDto)
        {
            var fornecedor = _repository.ObterPorId(id);
            if (fornecedor == null)
            {
                return null;
            }
            fornecedor.Nome = fornecedorDto.Nome;
            fornecedor.CNPJ = fornecedorDto.CNPJ;
            fornecedor.Endereco = fornecedorDto.Endereco;
            fornecedor.Telefone = fornecedorDto.Telefone;
            fornecedor.Email = fornecedorDto.Email;

            return _repository.Atualizar(fornecedor);
        }
    }
}