using FluentValidation;

public sealed class CreateCommandeDtoValidators : AbstractValidator<CreateCommandeRequest>
{
    public CreateCommandeDtoValidators()
    {
        RuleFor(x => x.NumeroCommande)
            .NotEmpty().WithMessage("Le numéro de commande est obligatoire.")
            .MaximumLength(50).WithMessage("Le numéro de commande ne peut pas dépasser 50 caractères.");

        RuleFor(x => x.MontantTotal)
            .NotEmpty().WithMessage("Le montant total est obligatoire.")
            .GreaterThanOrEqualTo(0).WithMessage("Le montant total ne peut pas être négatif.");

        RuleFor(x => x.Statut)
            .NotEmpty().WithMessage("Le statut est obligatoire.");

        RuleFor(x => x.ClientId)
            .NotEmpty().WithMessage("Le client est obligatoire.");
    }
}