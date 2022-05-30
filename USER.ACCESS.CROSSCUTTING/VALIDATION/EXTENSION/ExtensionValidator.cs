using FluentValidation;
using MIDDLEWARE.LOG.APPLICATION.MODEL.EXCEPTION;

namespace USER.ACCESS.CROSSCUTTING.VALIDATION.EXTENSION
{
    public static class ExtensionValidator
    {
        public static void ValidateHorti<T>(this IValidator<T> iValidator, T objValidation) where T : class
        {
            try
            {
                ((AbstractValidator<T>)iValidator).CascadeMode = CascadeMode.Continue;

                iValidator.ValidateAndThrow(objValidation);
            }
            catch (ValidationException ex)
            {
                throw new BadRequestException(nameof(T).ToUpperInvariant() + " - " + ex.Message);
            }
        }
    }
}
