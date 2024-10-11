using CP2.Domain.Interfaces.Dtos;
using FluentValidation;

namespace CP2.Application.Dtos
{
    public class FornecedorDto : IFornecedorDto
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string CNPJ { get; set; }
        public required string Endereco { get; set; }
        public required string Telefone { get; set; }
        public required string Email { get; set; }
        public DateTime CriadoEm { get; set; }

        public void Validate()
        {
            var validateResult = new FornecedorDtoValidation().Validate(this);

            if (!validateResult.IsValid)
                throw new Exception(string.Join(" e ", validateResult.Errors.Select(x => x.ErrorMessage)));
        }
    }

    internal class FornecedorDtoValidation : AbstractValidator<FornecedorDto>
    {
        public FornecedorDtoValidation()
        {
            RuleFor(f => f.Nome)
                .NotEmpty().WithMessage("O nome do fornecedor é obrigatório.")
                .MaximumLength(100).WithMessage("O nome do fornecedor deve ter no máximo 100 caracteres.");

            RuleFor(f => f.CNPJ)
                .NotEmpty().WithMessage("O CNPJ é obrigatório.")
                .Length(14).WithMessage("O CNPJ deve conter 14 caracteres.")
                .Matches(@"^\d{14}$").WithMessage("O CNPJ deve conter apenas números.");

            RuleFor(f => f.Endereco)
                .NotEmpty().WithMessage("O endereço é obrigatório.")
                .MaximumLength(200).WithMessage("O endereço deve ter no máximo 200 caracteres.");

            RuleFor(f => f.Telefone)
                .NotEmpty().WithMessage("O telefone é obrigatório.")
                .Matches(@"^\d{10,15}$").WithMessage("O telefone deve conter de 10 a 15 dígitos.");

            RuleFor(f => f.Email)
                .NotEmpty().WithMessage("O email é obrigatório.")
                .EmailAddress().WithMessage("Email inválido.")
                .MaximumLength(100).WithMessage("O email deve ter no máximo 100 caracteres.");
        }
    }
}