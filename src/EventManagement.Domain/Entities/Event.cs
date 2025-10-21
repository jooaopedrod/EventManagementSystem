using EventManagement.Domain.Guards;
using System.Diagnostics.CodeAnalysis;

namespace EventManagement.Domain.Entities;

/// <summary>
/// Representa um evento (conferência, workshop, seminário).
/// </summary>
public class Event
{
    private Venue? _venue;
    private string _requirements = string.Empty;
    private string _notes = string.Empty;

    public int EventId { get; }
    public string Title { get; }
    public DateTime EventDate { get; }
    public TimeSpan Duration { get; }
    public string? Description { get; private set; }
    public Speaker? MainSpeaker { get; private set; }

    /// <summary>
    /// Código único do evento. Nunca retorna null.
    /// </summary>
    [DisallowNull]
    public string EventCode { get; private set; } = string.Empty;

    /// <summary>
    /// Requisitos para participação. Aceita null mas retorna string vazia.
    /// </summary>
    [AllowNull]
    public string Requirements
    {
        get => _requirements;
        set => _requirements = value ?? string.Empty;
    }

    /// <summary>
    /// Observações gerais. Aceita null mas retorna string vazia.
    /// </summary>
    [AllowNull]
    public string Notes
    {
        get => _notes;
        set => _notes = value ?? string.Empty;
    }

    /// <summary>
    /// Local do evento. Usa lazy loading, carrega Default se não definido.
    /// </summary>
    public Venue Venue
    {
        get
        {
            EnsureVenue();
            return _venue;
        }
    }

    public Event(int eventId, string title, DateTime eventDate, TimeSpan duration)
    {
        // Valida EventId
        Guard.AgainstNegativeOrZero(eventId, nameof(eventId));

        // Valida Title
        Guard.AgainstNull(ref title, nameof(title));
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title cannot be empty or whitespace.", nameof(title));

        // Valida EventDate
        Guard.AgainstPastDate(eventDate, nameof(eventDate));

        // Valida Duration (mínimo 30 minutos)
        if (duration < TimeSpan.FromMinutes(30))
            throw new ArgumentOutOfRangeException(nameof(duration), 
                "Duration must be at least 30 minutes.");

        EventId = eventId;
        Title = title;
        EventDate = eventDate;
        Duration = duration;
    }

    /// <summary>
    /// Define o código do evento.
    /// </summary>
    public void SetEventCode(string code)
    {
        Guard.AgainstNull(ref code, nameof(code));
        EventCode = code.Trim();
    }

    /// <summary>
    /// Define a descrição do evento.
    /// </summary>
    public void SetDescription(string? description)
    {
        if (Guard.TryParseNonEmpty(description, out string? validDescription))
        {
            Description = validDescription;
        }
        else
        {
            Description = null;
        }
    }

    /// <summary>
    /// Atribui o palestrante principal do evento.
    /// </summary>
    public void AssignMainSpeaker(Speaker speaker)
    {
        Guard.AgainstNull(ref speaker, nameof(speaker));
        MainSpeaker = speaker;
    }

    /// <summary>
    /// Garante que o local do evento está carregado (lazy loading).
    /// </summary>
    [MemberNotNull(nameof(_venue))]
    private void EnsureVenue()
    {
        _venue ??= Venue.Default;
    }

    public override string ToString()
    {
        return $"Event [Id: {EventId}, Title: {Title}, Date: {EventDate:yyyy-MM-dd}, " +
               $"Duration: {Duration.TotalHours}h, Code: {EventCode}, " +
               $"MainSpeaker: {MainSpeaker?.FullName ?? "TBD"}]";
    }
}