﻿using Cod3rsGrowth.Dominio.Classes;
using FluentValidation;

namespace Cod3rsGrowth.Servico.Validadores
{
    public class ObraValidador : AbstractValidator<Obra>
    {
        public ObraValidador() 
        {
            RuleFor(obra => obra.Titulo)
                .NotEmpty().WithMessage("O titulo da obra é obrigatório.")
                .MaximumLength(2000).WithMessage("O título pode ter no máximo 2000 caracteres.");

            RuleFor(obra => obra.Autor)
                .NotEmpty().WithMessage("O nome do autor da obra é obrigatório.")
                .MaximumLength(150).WithMessage("O nome do autor deve ter até 150 caracteres.");

            RuleFor(obra => obra.Sinopse)
                .NotEmpty().WithMessage("A obra deve ter uma sinopse.")
                .MaximumLength(2000).WithMessage("A sinopse deve ter no máximo 2000 caracteres.");

            RuleFor(obra => obra.NumeroCapitulos)
                .GreaterThanOrEqualTo(1).WithMessage("A obra deve ter pelo menos 1 capítulo.");

            RuleFor(obra => obra.ValorObra)
                .GreaterThanOrEqualTo(0).WithMessage("O valor da obra não pode ser negativo.");

            RuleFor(obra => obra.InicioPublicacao)
                .NotEmpty().WithMessage("A data de início da publicação da obra deve ser informada.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Data inválida. Não é possível colocar uma data futura.");

            RuleFor(obra => obra.Formato)
                .IsInEnum().WithMessage("Formato de obra inválido.");

            RuleFor(obra => obra.Generos)
                .NotEmpty().WithMessage("O(s) gênero(s) da obra deve(m) ser informado(s).")
                .Must(list => list.Count < 10).WithMessage("O limite de gêneros em uma única obra é 10.");

            RuleForEach(obra => obra.Generos)
                .IsInEnum().WithMessage("Genero informado inválido.");
        }
    }
}
