using EventManagement.Domain.Entities;

namespace EventManagement.Domain.Tests;

public class SpeakerSpecs
{
    #region Constructor Tests

    [Fact]
    public void Ctor_DadosValidos_DeveCriarSpeaker()
    {
        // Arrange
        var speakerId = 1;
        var fullName = "João Silva";
        var email = "joao@email.com";

        // Act
        var speaker = new Speaker(speakerId, fullName, email);

        // Assert
        Assert.NotNull(speaker);
        Assert.Equal(speakerId, speaker.SpeakerId);
        Assert.Equal(fullName, speaker.FullName);
        Assert.Equal(email, speaker.Email);
        Assert.Null(speaker.Biography);
    }

    [Fact]
    public void Ctor_SpeakerIdNegativo_DeveLancarArgumentOutOfRangeException()
    {
        // Arrange
        var speakerId = -1;
        var fullName = "João Silva";
        var email = "joao@email.com";

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => 
            new Speaker(speakerId, fullName, email));
    }

    [Fact]
    public void Ctor_SpeakerIdZero_DeveLancarArgumentOutOfRangeException()
    {
        // Arrange
        var speakerId = 0;
        var fullName = "João Silva";
        var email = "joao@email.com";

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => 
            new Speaker(speakerId, fullName, email));
    }

    [Fact]
    public void Ctor_FullNameNulo_DeveLancarArgumentNullException()
    {
        // Arrange
        var speakerId = 1;
        string? fullName = null;
        var email = "joao@email.com";

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => 
            new Speaker(speakerId, fullName!, email));
    }

    [Fact]
    public void Ctor_FullNameVazio_DeveLancarArgumentException()
    {
        // Arrange
        var speakerId = 1;
        var fullName = "";
        var email = "joao@email.com";

        // Act & Assert
        Assert.Throws<ArgumentException>(() => 
            new Speaker(speakerId, fullName, email));
    }

    [Fact]
    public void Ctor_FullNameApenasEspacos_DeveLancarArgumentException()
    {
        // Arrange
        var speakerId = 1;
        var fullName = "   ";
        var email = "joao@email.com";

        // Act & Assert
        Assert.Throws<ArgumentException>(() => 
            new Speaker(speakerId, fullName, email));
    }

    [Fact]
    public void Ctor_EmailNulo_DeveLancarArgumentNullException()
    {
        // Arrange
        var speakerId = 1;
        var fullName = "João Silva";
        string? email = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => 
            new Speaker(speakerId, fullName, email!));
    }

    [Fact]
    public void Ctor_EmailSemArroba_DeveLancarArgumentException()
    {
        // Arrange
        var speakerId = 1;
        var fullName = "João Silva";
        var email = "joaoemail.com";

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => 
            new Speaker(speakerId, fullName, email));
        Assert.Contains("@", exception.Message);
    }

    #endregion

    #region SetBiography Tests

    [Fact]
    public void SetBiography_BiografiaValida_DeveDefinirBiografia()
    {
        // Arrange
        var speaker = new Speaker(1, "João Silva", "joao@email.com");
        var biography = "Especialista em C# com 10 anos de experiência";

        // Act
        speaker.SetBiography(biography);

        // Assert
        Assert.Equal(biography, speaker.Biography);
    }

    [Fact]
    public void SetBiography_BiografiaNula_DeveDefinirComoNull()
    {
        // Arrange
        var speaker = new Speaker(1, "João Silva", "joao@email.com");

        // Act
        speaker.SetBiography(null);

        // Assert
        Assert.Null(speaker.Biography);
    }

    [Fact]
    public void SetBiography_BiografiaVazia_DeveDefinirComoNull()
    {
        // Arrange
        var speaker = new Speaker(1, "João Silva", "joao@email.com");

        // Act
        speaker.SetBiography("");

        // Assert
        Assert.Null(speaker.Biography);
    }

    [Fact]
    public void SetBiography_BiografiaApenasEspacos_DeveDefinirComoNull()
    {
        // Arrange
        var speaker = new Speaker(1, "João Silva", "joao@email.com");

        // Act
        speaker.SetBiography("   ");

        // Assert
        Assert.Null(speaker.Biography);
    }

    #endregion

    #region Company Tests

    [Fact]
    public void Company_DefinirNull_DeveRetornarStringVazia()
    {
        // Arrange
        var speaker = new Speaker(1, "João Silva", "joao@email.com");

        // Act
        speaker.Company = null;

        // Assert
        Assert.NotNull(speaker.Company);
        Assert.Equal(string.Empty, speaker.Company);
    }

    [Fact]
    public void Company_DefinirValorValido_DeveArmazenarValor()
    {
        // Arrange
        var speaker = new Speaker(1, "João Silva", "joao@email.com");
        var company = "Tech Corp";

        // Act
        speaker.Company = company;

        // Assert
        Assert.Equal(company, speaker.Company);
    }

    #endregion

    #region LinkedInProfile Tests

    [Fact]
    public void LinkedInProfile_DefinirNull_DeveRetornarStringVazia()
    {
        // Arrange
        var speaker = new Speaker(1, "João Silva", "joao@email.com");

        // Act
        speaker.LinkedInProfile = null;

        // Assert
        Assert.NotNull(speaker.LinkedInProfile);
        Assert.Equal(string.Empty, speaker.LinkedInProfile);
    }

    [Fact]
    public void LinkedInProfile_DefinirValorValido_DeveArmazenarValor()
    {
        // Arrange
        var speaker = new Speaker(1, "João Silva", "joao@email.com");
        var profile = "https://linkedin.com/in/joaosilva";

        // Act
        speaker.LinkedInProfile = profile;

        // Assert
        Assert.Equal(profile, speaker.LinkedInProfile);
    }

    #endregion

    #region Identity Tests

    [Fact]
    public void Equals_SpeakersComMesmoSpeakerId_DeveRetornarTrue()
    {
        // Arrange
        var speaker1 = new Speaker(1, "João Silva", "joao@email.com");
        var speaker2 = new Speaker(1, "Outro Nome", "outro@email.com");

        // Act
        var result = speaker1.Equals(speaker2);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Equals_SpeakersComSpeakerIdDiferente_DeveRetornarFalse()
    {
        // Arrange
        var speaker1 = new Speaker(1, "João Silva", "joao@email.com");
        var speaker2 = new Speaker(2, "João Silva", "joao@email.com");

        // Act
        var result = speaker1.Equals(speaker2);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void Equals_ComparacaoComNull_DeveRetornarFalse()
    {
        // Arrange
        var speaker = new Speaker(1, "João Silva", "joao@email.com");

        // Act
        var result = speaker.Equals(null);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void GetHashCode_SpeakersComMesmoSpeakerId_DevemTerMesmoHashCode()
    {
        // Arrange
        var speaker1 = new Speaker(1, "João Silva", "joao@email.com");
        var speaker2 = new Speaker(1, "Outro Nome", "outro@email.com");

        // Act
        var hash1 = speaker1.GetHashCode();
        var hash2 = speaker2.GetHashCode();

        // Assert
        Assert.Equal(hash1, hash2);
    }

    [Fact]
    public void ToString_DeveRetornarFormatoCorreto()
    {
        // Arrange
        var speaker = new Speaker(1, "João Silva", "joao@email.com");

        // Act
        var result = speaker.ToString();

        // Assert
        Assert.Contains("João Silva", result);
        Assert.Contains("joao@email.com", result);
    }

    #endregion
}