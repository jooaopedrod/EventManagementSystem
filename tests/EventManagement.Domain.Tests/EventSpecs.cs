using EventManagement.Domain.Entities;

namespace EventManagement.Domain.Tests;

public class EventSpecs
{
    #region Constructor Tests

    [Fact]
    public void Ctor_DadosValidos_DeveCriarEvent()
    {
        // Arrange
        var eventId = 1;
        var title = ".NET Conference 2025";
        var eventDate = DateTime.Now.AddMonths(3);
        var duration = TimeSpan.FromHours(8);

        // Act
        var evt = new Event(eventId, title, eventDate, duration);

        // Assert
        Assert.NotNull(evt);
        Assert.Equal(eventId, evt.EventId);
        Assert.Equal(title, evt.Title);
        Assert.Equal(eventDate, evt.EventDate);
        Assert.Equal(duration, evt.Duration);
        Assert.Null(evt.Description);
        Assert.Null(evt.MainSpeaker);
    }

    [Fact]
    public void Ctor_EventIdNegativo_DeveLancarArgumentOutOfRangeException()
    {
        // Arrange
        var eventId = -1;
        var title = "Conference";
        var eventDate = DateTime.Now.AddMonths(1);
        var duration = TimeSpan.FromHours(4);

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => 
            new Event(eventId, title, eventDate, duration));
    }

    [Fact]
    public void Ctor_EventIdZero_DeveLancarArgumentOutOfRangeException()
    {
        // Arrange
        var eventId = 0;
        var title = "Conference";
        var eventDate = DateTime.Now.AddMonths(1);
        var duration = TimeSpan.FromHours(4);

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => 
            new Event(eventId, title, eventDate, duration));
    }

    [Fact]
    public void Ctor_TitleNulo_DeveLancarArgumentNullException()
    {
        // Arrange
        var eventId = 1;
        string? title = null;
        var eventDate = DateTime.Now.AddMonths(1);
        var duration = TimeSpan.FromHours(4);

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => 
            new Event(eventId, title!, eventDate, duration));
    }

    [Fact]
    public void Ctor_TitleVazio_DeveLancarArgumentException()
    {
        // Arrange
        var eventId = 1;
        var title = "";
        var eventDate = DateTime.Now.AddMonths(1);
        var duration = TimeSpan.FromHours(4);

        // Act & Assert
        Assert.Throws<ArgumentException>(() => 
            new Event(eventId, title, eventDate, duration));
    }

    [Fact]
    public void Ctor_TitleApenasEspacos_DeveLancarArgumentException()
    {
        // Arrange
        var eventId = 1;
        var title = "   ";
        var eventDate = DateTime.Now.AddMonths(1);
        var duration = TimeSpan.FromHours(4);

        // Act & Assert
        Assert.Throws<ArgumentException>(() => 
            new Event(eventId, title, eventDate, duration));
    }

    [Fact]
    public void Ctor_EventDateNoPassado_DeveLancarArgumentException()
    {
        // Arrange
        var eventId = 1;
        var title = "Conference";
        var eventDate = DateTime.Now.AddDays(-1);
        var duration = TimeSpan.FromHours(4);

        // Act & Assert
        Assert.Throws<ArgumentException>(() => 
            new Event(eventId, title, eventDate, duration));
    }

    [Fact]
    public void Ctor_DurationMenorQue30Minutos_DeveLancarArgumentOutOfRangeException()
    {
        // Arrange
        var eventId = 1;
        var title = "Conference";
        var eventDate = DateTime.Now.AddMonths(1);
        var duration = TimeSpan.FromMinutes(29);

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => 
            new Event(eventId, title, eventDate, duration));
    }

    [Fact]
    public void Ctor_DurationExatos30Minutos_DeveCriarEvent()
    {
        // Arrange
        var eventId = 1;
        var title = "Quick Talk";
        var eventDate = DateTime.Now.AddMonths(1);
        var duration = TimeSpan.FromMinutes(30);

        // Act
        var evt = new Event(eventId, title, eventDate, duration);

        // Assert
        Assert.NotNull(evt);
        Assert.Equal(duration, evt.Duration);
    }

    #endregion

    #region EventCode Tests - [DisallowNull]

    [Fact]
    public void EventCode_ValorInicial_DeveSerStringVazia()
    {
        // Arrange & Act
        var evt = new Event(1, "Conference", DateTime.Now.AddMonths(1), TimeSpan.FromHours(4));

        // Assert
        Assert.NotNull(evt.EventCode);
        Assert.Equal(string.Empty, evt.EventCode);
    }

    [Fact]
    public void SetEventCode_CodigoValido_DeveDefinirCodigo()
    {
        // Arrange
        var evt = new Event(1, "Conference", DateTime.Now.AddMonths(1), TimeSpan.FromHours(4));
        var code = "CONF2025";

        // Act
        evt.SetEventCode(code);

        // Assert
        Assert.Equal(code, evt.EventCode);
        Assert.NotNull(evt.EventCode);
    }

    [Fact]
    public void SetEventCode_CodigoComEspacos_DeveFazerTrim()
    {
        // Arrange
        var evt = new Event(1, "Conference", DateTime.Now.AddMonths(1), TimeSpan.FromHours(4));
        var code = "  CONF2025  ";

        // Act
        evt.SetEventCode(code);

        // Assert
        Assert.Equal("CONF2025", evt.EventCode);
    }

    [Fact]
    public void SetEventCode_CodigoNulo_DeveLancarArgumentNullException()
    {
        // Arrange
        var evt = new Event(1, "Conference", DateTime.Now.AddMonths(1), TimeSpan.FromHours(4));

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => evt.SetEventCode(null!));
    }

    [Fact]
    public void EventCode_NuncaRetornaNulo_DisallowNull()
    {
        // Arrange
        var evt = new Event(1, "Conference", DateTime.Now.AddMonths(1), TimeSpan.FromHours(4));

        // Act
        var code1 = evt.EventCode;
        evt.SetEventCode("ABC123");
        var code2 = evt.EventCode;

        // Assert
        Assert.NotNull(code1);
        Assert.NotNull(code2);
    }

    #endregion

    #region SetDescription Tests

    [Fact]
    public void SetDescription_DescricaoValida_DeveDefinirDescricao()
    {
        // Arrange
        var evt = new Event(1, "Conference", DateTime.Now.AddMonths(1), TimeSpan.FromHours(4));
        var description = "Conferência anual sobre tecnologias .NET";

        // Act
        evt.SetDescription(description);

        // Assert
        Assert.Equal(description, evt.Description);
    }

    [Fact]
    public void SetDescription_DescricaoNula_DeveDefinirComoNull()
    {
        // Arrange
        var evt = new Event(1, "Conference", DateTime.Now.AddMonths(1), TimeSpan.FromHours(4));

        // Act
        evt.SetDescription(null);

        // Assert
        Assert.Null(evt.Description);
    }

    [Fact]
    public void SetDescription_DescricaoVazia_DeveDefinirComoNull()
    {
        // Arrange
        var evt = new Event(1, "Conference", DateTime.Now.AddMonths(1), TimeSpan.FromHours(4));

        // Act
        evt.SetDescription("");

        // Assert
        Assert.Null(evt.Description);
    }

    [Fact]
    public void SetDescription_DescricaoApenasEspacos_DeveDefinirComoNull()
    {
        // Arrange
        var evt = new Event(1, "Conference", DateTime.Now.AddMonths(1), TimeSpan.FromHours(4));

        // Act
        evt.SetDescription("   ");

        // Assert
        Assert.Null(evt.Description);
    }

    #endregion

    #region Requirements Tests - [AllowNull]

    [Fact]
    public void Requirements_ValorInicial_DeveSerStringVazia()
    {
        // Arrange & Act
        var evt = new Event(1, "Conference", DateTime.Now.AddMonths(1), TimeSpan.FromHours(4));

        // Assert
        Assert.NotNull(evt.Requirements);
        Assert.Equal(string.Empty, evt.Requirements);
    }

    [Fact]
    public void Requirements_DefinirValorValido_DeveArmazenarValor()
    {
        // Arrange
        var evt = new Event(1, "Conference", DateTime.Now.AddMonths(1), TimeSpan.FromHours(4));
        var requirements = "Conhecimento básico em C#";

        // Act
        evt.Requirements = requirements;

        // Assert
        Assert.Equal(requirements, evt.Requirements);
    }

    [Fact]
    public void Requirements_DefinirNull_DeveRetornarStringVazia()
    {
        // Arrange
        var evt = new Event(1, "Conference", DateTime.Now.AddMonths(1), TimeSpan.FromHours(4));
        evt.Requirements = "Algum requisito";

        // Act
        evt.Requirements = null;

        // Assert
        Assert.NotNull(evt.Requirements);
        Assert.Equal(string.Empty, evt.Requirements);
    }

    #endregion

    #region Notes Tests - [AllowNull]

    [Fact]
    public void Notes_ValorInicial_DeveSerStringVazia()
    {
        // Arrange & Act
        var evt = new Event(1, "Conference", DateTime.Now.AddMonths(1), TimeSpan.FromHours(4));

        // Assert
        Assert.NotNull(evt.Notes);
        Assert.Equal(string.Empty, evt.Notes);
    }

    [Fact]
    public void Notes_DefinirValorValido_DeveArmazenarValor()
    {
        // Arrange
        var evt = new Event(1, "Conference", DateTime.Now.AddMonths(1), TimeSpan.FromHours(4));
        var notes = "Evento patrocinado pela Microsoft";

        // Act
        evt.Notes = notes;

        // Assert
        Assert.Equal(notes, evt.Notes);
    }

    [Fact]
    public void Notes_DefinirNull_DeveRetornarStringVazia()
    {
        // Arrange
        var evt = new Event(1, "Conference", DateTime.Now.AddMonths(1), TimeSpan.FromHours(4));
        evt.Notes = "Alguma nota";

        // Act
        evt.Notes = null;

        // Assert
        Assert.NotNull(evt.Notes);
        Assert.Equal(string.Empty, evt.Notes);
    }

    #endregion

    #region Venue Tests - Lazy Loading with [MemberNotNull]

    [Fact]
    public void Venue_PrimeiroAcesso_DeveCarregarVenueDefault()
    {
        // Arrange
        var evt = new Event(1, "Conference", DateTime.Now.AddMonths(1), TimeSpan.FromHours(4));

        // Act
        var venue = evt.Venue;

        // Assert
        Assert.NotNull(venue);
        Assert.Equal(1, venue.VenueId);
        Assert.Equal("Online Event", venue.Name);
    }

    [Fact]
    public void Venue_MultiploAcessos_DeveRetornarMesmaInstancia()
    {
        // Arrange
        var evt = new Event(1, "Conference", DateTime.Now.AddMonths(1), TimeSpan.FromHours(4));

        // Act
        var venue1 = evt.Venue;
        var venue2 = evt.Venue;

        // Assert
        Assert.Same(venue1, venue2);
    }

    [Fact]
    public void Venue_NuncaNulo_GraciasAoMemberNotNull()
    {
        // Arrange
        var evt = new Event(1, "Conference", DateTime.Now.AddMonths(1), TimeSpan.FromHours(4));

        // Act
        var venueName = evt.Venue.Name;
        var venueId = evt.Venue.VenueId;

        // Assert
        Assert.NotNull(venueName);
        Assert.Equal(1, venueId);
    }

    #endregion

    #region AssignMainSpeaker Tests

    [Fact]
    public void AssignMainSpeaker_SpeakerValido_DeveAtribuirSpeaker()
    {
        // Arrange
        var evt = new Event(1, "Conference", DateTime.Now.AddMonths(1), TimeSpan.FromHours(4));
        var speaker = new Speaker(1, "João Silva", "joao@email.com");

        // Act
        evt.AssignMainSpeaker(speaker);

        // Assert
        Assert.Equal(speaker, evt.MainSpeaker);
    }

    [Fact]
    public void AssignMainSpeaker_SpeakerNulo_DeveLancarArgumentNullException()
    {
        // Arrange
        var evt = new Event(1, "Conference", DateTime.Now.AddMonths(1), TimeSpan.FromHours(4));

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => evt.AssignMainSpeaker(null!));
    }

    [Fact]
    public void MainSpeaker_PodeSerNull()
    {
        // Arrange & Act
        var evt = new Event(1, "Conference", DateTime.Now.AddMonths(1), TimeSpan.FromHours(4));

        // Assert
        Assert.Null(evt.MainSpeaker);
    }

    #endregion

    #region ToString Tests

    [Fact]
    public void ToString_DeveRetornarFormatoCorreto()
    {
        // Arrange
        var evt = new Event(1, ".NET Conference", DateTime.Now.AddMonths(1), TimeSpan.FromHours(8));
        evt.SetEventCode("NETCONF2025");

        // Act
        var result = evt.ToString();

        // Assert
        Assert.Contains(".NET Conference", result);
        Assert.Contains("NETCONF2025", result);
    }

    #endregion
}