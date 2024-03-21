using FluentValidation;
using Proyecto_BeerStore.DTOs;

namespace Proyecto_BeerStore.Validators;

public class BeerUpdateValidator : AbstractValidator<BeerUpdateDto>
{
    public BeerUpdateValidator()
    {
        RuleFor(x => x.Id).NotNull().WithMessage("EL Id es obligatorio");
        RuleFor(x => x.Name).NotEmpty().WithMessage("El nombre es obligatorio");
        RuleFor(x => x.Name).Length(2, 20).WithMessage("El nombre tiene que ser entre 3 y 20 caracteres");
        RuleFor(x => x.BrandId).NotNull().WithMessage("La marca es obligatoria");
        RuleFor(x => x.Alcohol).GreaterThan(0).WithMessage("El {PropertyName} debe ser mayor a 0");
    
    }
    
}