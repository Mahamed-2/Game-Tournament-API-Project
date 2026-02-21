using System.ComponentModel.DataAnnotations;

namespace TournamentApi.Dtos;

/// <summary>
/// Custom validation attribute ensuring that the provided date is in the future.
/// </summary>
public class FutureDateAttribute : ValidationAttribute
{
    /// <summary>
    /// Returns true if the object value is a DateTime and is greater than the current local time.
    /// </summary>
    public override bool IsValid(object? value)
    {
        if (value is DateTime date)
        {
            return date > DateTime.Now;
        }
        return false;
    }
}
