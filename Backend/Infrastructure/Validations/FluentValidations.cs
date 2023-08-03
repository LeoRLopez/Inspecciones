using Core.Entities;
using FluentValidation;

namespace Infrastructure.Validations
{
    public class FluentValidations: AbstractValidator<Inspection>
    {
        public FluentValidations() 
        {
            RuleFor(inspection => inspection.StatusId).NotEmpty().NotNull();
            RuleFor(inspection => inspection.Description).NotEmpty().NotNull();
            RuleFor(inspection =>  inspection.InspectionTypeId).NotEmpty().NotNull();
        }
    }
}
