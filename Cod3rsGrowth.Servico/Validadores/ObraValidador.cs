using Cod3rsGrowth.Dominio.Classes;
using FluentValidation;

namespace Cod3rsGrowth.Servico.Validadores
{
    public class ObraValidador : AbstractValidator<Obra>
    {
        public ObraValidador() 
        {
            RuleFor(obra => obra.Titulo)
                .NotEmpty().WithMessage("A obra deve ter um título.")
                .Length(1, 1950).WithMessage("O título deve ter entre 1 e 1950 caracteres.");

            RuleFor(obra => obra.Autor)
                .NotEmpty().WithMessage("O nome do autor da obra é obrigatório.")
                .Length(1, 150).WithMessage("O nome do autor deve ter entre 1 e 150 caracteres.");

            RuleFor(obra => obra.Sinopse)
                .NotEmpty().WithMessage("A obra deve ter uma sinopse.");

            RuleFor(obra => obra.Id)
                .NotNull().WithMessage("O ID da obra deve ser especificado.")
                .GreaterThan(0).WithMessage("O ID da obra deve ser maior que 0.");

            RuleFor(obra => obra.NumeroCapitulos)
                .NotNull().WithMessage("O número de capítulos da obra deve ser informado.")
                .GreaterThan(0).WithMessage("O número de capítulos da obra deve ser maior que 0.");

            RuleFor(obra => obra.ValorObra)
                .NotNull().WithMessage("O valor da obra deve ser especificado.")
                .GreaterThanOrEqualTo(0).WithMessage("O valor da obra não pode ser negativo.");

            RuleFor(obra => obra.FoiFinalizada)
                .NotNull().WithMessage("O status da obra deve ser informado.");

        }
    }
}
