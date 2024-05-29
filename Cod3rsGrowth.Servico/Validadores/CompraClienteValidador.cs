using FluentValidation;
using Cod3rsGrowth.Dominio.Classes;

namespace Cod3rsGrowth.Servico.Validadores
{
    public class CompraClienteValidador : AbstractValidator<CompraCliente>
    {
        public CompraClienteValidador()
        {
            RuleFor(cliente => cliente.Cpf)
                .NotEmpty().WithMessage("O CPF do cliente é obrigatório.");

            RuleFor(cliente => cliente.Nome)
                .NotEmpty().WithMessage("O nome do cliente deve ser informado.")
                .MaximumLength(100).WithMessage("O nome deve ter até 100 caracteres.");

            RuleFor(cliente => cliente.Telefone)
                .NotEmpty().WithMessage("O telefone do cliente é obrigatório.");

            RuleFor(cliente => cliente.Email)
                .NotEmpty().WithMessage("O e-mail do cliente é obrigatório.")
                .EmailAddress().WithMessage("Formato de e-mail inválido.");

            RuleFor(cliente => cliente.Produtos)
                .NotEmpty().WithMessage("Os produtos da compra devem ser informados.");

            RuleForEach(cliente => cliente.Produtos)
                .NotEmpty().WithMessage("A compra deve conter a lista de produtos.")
                .SetValidator(new ObraValidador());

            RuleFor(cliente => cliente.ValorCompra)
                .NotNull().WithMessage("O valor total da compra deve ser informado.")
                .GreaterThanOrEqualTo(0).WithMessage("O valor da compra não pode ser negativo.");

            RuleFor(cliente => cliente.DataCompra)
                .NotEmpty().WithMessage("A data da compra deve ser informada.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Não é possível informar uma data futura.");
        }
    }
}
