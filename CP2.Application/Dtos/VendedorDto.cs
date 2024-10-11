using CP2.Domain.Interfaces.Dtos;
using FluentValidation;

namespace CP2.Application.Dtos
{
    public class VendedorDto : IVendedorDto
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string Email { get; set; }
        public required string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public required string Endereco { get; set; }
        public DateTime DataContratacao { get; set; }
        public decimal ComissaoPercentual { get; set; }
        public decimal MetaMensal { get; set; }
        public DateTime CriadoEm { get; set; }

        public void Validate()
        {
            var validateResult = new VendedorDtoValidation().Validate(this);

            if (!validateResult.IsValid)
                throw new Exception(string.Join(" e ", validateResult.Errors.Select(x => x.ErrorMessage)));
        }
    }

    internal class VendedorDtoValidation : AbstractValidator<VendedorDto>
    {
        public VendedorDtoValidation()
        {
            RuleFor(v => v.Nome)
                .NotEmpty().WithMessage("O nome do vendedor é obrigatório.")
                .MaximumLength(100).WithMessage("O nome do vendedor deve ter no máximo 100 caracteres.");

            RuleFor(v => v.Email)
                .NotEmpty().WithMessage("O email é obrigatório.")
                .EmailAddress().WithMessage("Email inválido.")
                .MaximumLength(100).WithMessage("O email deve ter no máximo 100 caracteres.");

            RuleFor(v => v.Telefone)
                .NotEmpty().WithMessage("O telefone é obrigatório.")
                .Matches(@"^\d{10,15}$").WithMessage("O telefone deve conter de 10 a 15 dígitos.");

            RuleFor(v => v.DataNascimento)
                .LessThan(DateTime.Now).WithMessage("A data de nascimento deve ser anterior à data atual.");

            RuleFor(v => v.Endereco)
                .NotEmpty().WithMessage("O endereço é obrigatório.")
                .MaximumLength(200).WithMessage("O endereço deve ter no máximo 200 caracteres.");

            RuleFor(v => v.DataContratacao)
                .NotEmpty().WithMessage("A data de contratação é obrigatória.");

            RuleFor(v => v.ComissaoPercentual)
                .InclusiveBetween(0, 100).WithMessage("A comissão deve estar entre 0% e 100%.");

            RuleFor(v => v.MetaMensal)
                .GreaterThan(0).WithMessage("A meta mensal deve ser maior que 0.");
        }
    }
}