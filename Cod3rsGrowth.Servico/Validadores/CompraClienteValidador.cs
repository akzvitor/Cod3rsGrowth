using FluentValidation;
using Cod3rsGrowth.Dominio.Classes;

namespace Cod3rsGrowth.Servico.Validadores
{
    public class CompraClienteValidador : AbstractValidator<CompraCliente>
    {
        public CompraClienteValidador()
        {
            RuleFor(cliente => cliente.Id)
                .NotNull().WithMessage("O ID da compra deve ser informado.")
                .GreaterThanOrEqualTo(0).WithMessage("O ID da compra não pode ser negativo.");

            RuleFor(cliente => cliente.Cpf)
                .NotNull().WithMessage("O CPF do cliente é obrigatório.");

            RuleFor(cliente => cliente.Nome)
                .NotEmpty().WithMessage("O nome do cliente deve ser informado.");

            RuleFor(cliente => cliente.Telefone)
                .NotNull().WithMessage("O telefone do cliente é obrigatório.");

            RuleFor(cliente => cliente.Email)
                .NotEmpty().WithMessage("O e-mail do cliente é obrigatório.")
                .EmailAddress().WithMessage("Formato de e-mail inválido.");

            RuleForEach(cliente => cliente.Produtos)
                .NotEmpty().WithMessage("A compra deve conter a lista de produtos.")
                .SetValidator(new ObraValidador());

            RuleFor(cliente => cliente.ValorCompra)
                .NotNull().WithMessage("O valor total da compra deve ser informado.")
                .GreaterThanOrEqualTo(0).WithMessage("O valor da compra não pode ser negativo.");

            RuleFor(cliente => cliente.DataCompra)
                .NotNull().WithMessage("A data da compra deve ser informada.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("");
        }
    }
}
