using FluentValidation;

internal sealed class CreateClientDtoValidators : AbstractValidator<CreateClientRequest>
{
    public CreateClientDtoValidators()
    {
        RuleFor(x => x.Nom)
            .NotEmpty().WithMessage("Le nom est obligatoire.")
            .MaximumLength(50).WithMessage("Le nom ne peut pas dépasser 50 caractères.");

        RuleFor(x => x.Prenom)
            .NotEmpty().WithMessage("Le prénom est obligatoire.")
            .MaximumLength(50).WithMessage("Le prénom ne peut pas dépasser 50 caractères.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("L'email est obligatoire.")
            .EmailAddress().WithMessage("L'email n'est pas valide.");

        RuleFor(x => x.Telephone)
            .NotEmpty().WithMessage("Le téléphone est obligatoire.")
            .Matches(@"^\d{10}$").WithMessage("Le téléphone doit contenir exactement 10 chiffres.");

        RuleFor(x => x.Adresse)
            .MaximumLength(150).WithMessage("L'adresse ne peut pas dépasser 150 caractères.");
    }
}