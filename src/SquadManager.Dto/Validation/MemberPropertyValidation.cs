using System.ComponentModel.DataAnnotations;


namespace SquadManager.Dto.Validation;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
public abstract class ConditionalValidationAttribute : ValidationAttribute
{
    protected readonly ValidationAttribute InnerAttribute;
    public string DependentProperty { get; set; }
    public object TargetValue { get; set; }
    protected abstract string ValidationName { get; }

    protected virtual IDictionary<string, object> GetExtraValidationParameters()
    {
        return new Dictionary<string, object>();
    }

    protected ConditionalValidationAttribute(
        ValidationAttribute innerAttribute, string dependentProperty, object targetValue)
    {
        this.InnerAttribute = innerAttribute;
        this.DependentProperty = dependentProperty;
        this.TargetValue = targetValue;
    }

    protected override ValidationResult IsValid(
        object value, ValidationContext validationContext)
    {
        // get a reference to the property this validation depends upon
        var containerType = validationContext.ObjectInstance.GetType();
        var field = containerType.GetProperty(this.DependentProperty);

        if (field != null)
        {
            // get the value of the dependent property
            var dependentvalue = field.GetValue(validationContext.ObjectInstance, null);

            // compare the value against the target value
            if ((dependentvalue == null && this.TargetValue == null)
                || (dependentvalue != null
                && dependentvalue.Equals(this.TargetValue)))
            {
                // match => means we should try validating this field
                if (!InnerAttribute.IsValid(value))
                {
                    // validation failed - return an error
                    return new ValidationResult(
                        this.ErrorMessage, new[] { validationContext.MemberName }
                        );
                }
            }
        }

        return ValidationResult.Success;
    }
}

public class RequiredIfAttribute : ConditionalValidationAttribute
{
    protected override string ValidationName
    {
        get { return "requiredif"; }
    }

    public RequiredIfAttribute(string dependentProperty, object targetValue)
        : base(new RequiredAttribute(), dependentProperty, targetValue)
    {
    }

    protected override IDictionary<string, object> GetExtraValidationParameters()
    {
        return new Dictionary<string, object>
        {
            { "rule", "required" }
        };
    }
}

public class NotFutureDate : ValidationAttribute
{
    public override string FormatErrorMessage(string name)
    {
        return "Date value should not be a future date.";
    }

    protected override ValidationResult IsValid(
        object objValue, ValidationContext validationContext)
    {
        var dateValue = objValue as DateTime? ?? new DateTime();

        if (dateValue.Date > DateTime.UtcNow.Date)
        {
            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        }

        return ValidationResult.Success;
    }
}

public class FutureDate : ValidationAttribute
{
    public override string FormatErrorMessage(string name)
    {
        return "Date should be a future date.";
    }

    protected override ValidationResult IsValid(
        object objValue, ValidationContext validationContext)
    {
        var dateValue = objValue as DateTime? ?? new DateTime();

        if (dateValue.Date <= DateTime.UtcNow.Date)
        {
            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        }

        return ValidationResult.Success;
    }
}
