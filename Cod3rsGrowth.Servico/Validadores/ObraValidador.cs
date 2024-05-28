using Cod3rsGrowth.Dominio.Classes;
using FluentValidation;

namespace Cod3rsGrowth.Servico.Validadores
{
    public class ObraValidador : AbstractValidator<Obra>
    {
        public ObraValidador() 
        {
            RuleFor(obra => obra.Titulo)
                .NotEmpty().WithMessage("O titulo da obra é obrigatório.")
                .Length(2, 1950).WithMessage("O título deve ter entre 2 e 1950 caracteres.");

            RuleFor(obra => obra.Autor)
                .NotEmpty().WithMessage("O nome do autor da obra é obrigatório.")
                .Length(1, 150).WithMessage("O nome do autor deve ter entre 1 e 150 caracteres.");

            RuleFor(obra => obra.Sinopse)
                .NotEmpty().WithMessage("A obra deve ter uma sinopse.")
                .Length(1, 2000);

            RuleFor(obra => obra.Id)
                .NotNull().WithMessage("O ID da obra deve ser especificado.")
                .GreaterThanOrEqualTo(0).WithMessage("O ID da obra não pode ser negativo.");

            RuleFor(obra => obra.NumeroCapitulos)
                .NotNull().WithMessage("O número de capítulos da obra deve ser informado.")
                .GreaterThan(0).WithMessage("O número de capítulos da obra deve ser maior que 0.");

            RuleFor(obra => obra.ValorObra)
                .NotNull().WithMessage("O valor da obra deve ser especificado.")
                .GreaterThanOrEqualTo(0).WithMessage("O valor da obra não pode ser negativo.");

            RuleFor(obra => obra.FoiFinalizada)
                .NotNull().WithMessage("O status da obra deve ser informado.");

            RuleFor(obra => obra.InicioPublicacao)
                .NotNull().WithMessage("A data de início da publicação da obra deve ser informada.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Data inválida.");

            RuleFor(obra => obra.Formato)
                .NotNull().WithMessage("O formato da obra deve ser informado.")
                .IsInEnum().WithMessage("Formato de obra inválido.");

            RuleFor(obra => obra.Generos)
                .NotEmpty().WithMessage("O(s) gênero(s) da obra deve(m) ser informado(s).")
                .Must(list => list.Count < 10).WithMessage("O limite de gêneros em uma única obra é 10.");

            RuleForEach(obra => obra.Generos)
                .NotNull().WithMessage("O(s) gênero(s) da obra deve(m) ser informado(s).")
                .IsInEnum().WithMessage("Genero informado inválido.");
        }
    }
}
