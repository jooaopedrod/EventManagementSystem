using System.Diagnostics.CodeAnalysis;

namespace EventManagement.Domain.Guards;

/// <summary>
/// Classe estática que fornece métodos de validação (Guard Clauses) para proteger o código contra estados inválidos.
/// </summary>
public static class Guard
{
    /// <summary>
    /// Valida se o valor fornecido não é nulo, lançando uma exceção caso seja.
    /// </summary>
    public static void AgainstNull<[DynamicallyAccessedMembers(0)] T>(
        [NotNull] ref T? value, string paramName)
    {
        if (value is null)
            throw new ArgumentNullException(paramName);
    }

    /// <summary>
    /// Tenta validar se uma string possui conteúdo não vazio.
    /// </summary>
    public static bool TryParseNonEmpty(string? s, 
        [NotNullWhen(true)] out string? result)
    {
        if (!string.IsNullOrWhiteSpace(s)) 
        { 
            result = s; 
            return true; 
        }
        result = null; 
        return false;
    }

    /// <summary>
    /// Valida se o valor é maior que zero, lançando exceção caso seja negativo ou zero.
    /// </summary>
    public static void AgainstNegativeOrZero(int value, string paramName)
    {
        if (value <= 0)
            throw new ArgumentOutOfRangeException(paramName, 
                $"{paramName} must be greater than zero.");
    }

    /// <summary>
    /// Valida se uma data não está no passado.
    /// </summary>
    public static void AgainstPastDate(DateTime date, string paramName)
    {
        if (date < DateTime.Now)
            throw new ArgumentException(
                $"{paramName} cannot be in the past.", paramName);
    }

    /// <summary>
    /// Valida se um email possui formato básico válido (contém @).
    /// </summary>
    public static bool IsValidEmail(string? email)
    {
        return !string.IsNullOrWhiteSpace(email) && email.Contains('@');
    }
}