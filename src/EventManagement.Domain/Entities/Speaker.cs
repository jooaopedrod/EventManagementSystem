using EventManagement.Domain.Guards;
using System.Diagnostics.CodeAnalysis;

namespace EventManagement.Domain.Entities;

/// <summary>
/// Representa um palestrante em um evento.
/// </summary>
public class Speaker
{
    private string _company = string.Empty;
    private string _linkedInProfile = string.Empty;

    public int SpeakerId { get; }
    public string FullName { get; }
    public string Email { get; }
    public string? Biography { get; private set; }

    /// <summary>
    /// Empresa onde o palestrante trabalha. Aceita null mas retorna string vazia.
    /// </summary>
    [AllowNull]
    public string Company
    {
        get => _company;
        set => _company = value ?? string.Empty;
    }

    /// <summary>
    /// URL do perfil LinkedIn. Aceita null mas retorna string vazia.
    /// </summary>
    [AllowNull]
    public string LinkedInProfile
    {
        get => _linkedInProfile;
        set => _linkedInProfile = value ?? string.Empty;
    }

    public Speaker(int speakerId, string fullName, string email)
    {
        // Valida SpeakerId
        Guard.AgainstNegativeOrZero(speakerId, nameof(speakerId));

        // Valida FullName
        Guard.AgainstNull(ref fullName, nameof(fullName));
        if (string.IsNullOrWhiteSpace(fullName))
            throw new ArgumentException("FullName cannot be empty or whitespace.", nameof(fullName));

        // Valida Email
        Guard.AgainstNull(ref email, nameof(email));
        if (!Guard.IsValidEmail(email))
            throw new ArgumentException("Email must contain '@'.", nameof(email));

        SpeakerId = speakerId;
        FullName = fullName;
        Email = email;
    }

    /// <summary>
    /// Define a biografia do palestrante.
    /// </summary>
    public void SetBiography(string? biography)
    {
        if (Guard.TryParseNonEmpty(biography, out string? validBiography))
        {
            Biography = validBiography;
        }
        else
        {
            Biography = null;
        }
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Speaker other)
            return false;

        return SpeakerId == other.SpeakerId;
    }

    public override int GetHashCode()
    {
        return SpeakerId.GetHashCode();
    }

    public override string ToString()
    {
        return $"Speaker [Id: {SpeakerId}, Name: {FullName}, Email: {Email}, " +
               $"Company: {Company}, Biography: {Biography ?? "N/A"}]";
    }
}