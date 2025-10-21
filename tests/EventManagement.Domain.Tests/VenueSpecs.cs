using EventManagement.Domain.Entities;

namespace EventManagement.Domain.Tests;

public class VenueSpecs
{
    #region Constructor Tests

    [Fact]
    public void Ctor_DadosValidos_DeveCriarVenue()
    {
        // Arrange
        var venueId = 1;
        var name = "Centro de Convenções";
        var address = "Av. Principal, 100";
        var capacity = 500;

        // Act
        var venue = new Venue(venueId, name, address, capacity);

        // Assert
        Assert.NotNull(venue);
        Assert.Equal(venueId, venue.VenueId);
        Assert.Equal(name, venue.Name);
        Assert.Equal(address, venue.Address);
        Assert.Equal(capacity, venue.Capacity);
        Assert.Null(venue.Description);
    }

    [Fact]
    public void Ctor_VenueIdNegativo_DeveLancarArgumentOutOfRangeException()
    {
        // Arrange
        var venueId = -1;
        var name = "Centro";
        var address = "Av. Principal, 100";
        var capacity = 500;

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => 
            new Venue(venueId, name, address, capacity));
    }

    [Fact]
    public void Ctor_VenueIdZero_DeveLancarArgumentOutOfRangeException()
    {
        // Arrange
        var venueId = 0;
        var name = "Centro";
        var address = "Av. Principal, 100";
        var capacity = 500;

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => 
            new Venue(venueId, name, address, capacity));
    }

    [Fact]
    public void Ctor_NameNulo_DeveLancarArgumentNullException()
    {
        // Arrange
        var venueId = 1;
        string? name = null;
        var address = "Av. Principal, 100";
        var capacity = 500;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => 
            new Venue(venueId, name!, address, capacity));
    }

    [Fact]
    public void Ctor_AddressNulo_DeveLancarArgumentNullException()
    {
        // Arrange
        var venueId = 1;
        var name = "Centro";
        string? address = null;
        var capacity = 500;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => 
            new Venue(venueId, name, address!, capacity));
    }

    [Fact]
    public void Ctor_AddressVazio_DeveLancarArgumentException()
    {
        // Arrange
        var venueId = 1;
        var name = "Centro";
        var address = "";
        var capacity = 500;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => 
            new Venue(venueId, name, address, capacity));
    }

    [Fact]
    public void Ctor_AddressApenasEspacos_DeveLancarArgumentException()
    {
        // Arrange
        var venueId = 1;
        var name = "Centro";
        var address = "   ";
        var capacity = 500;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => 
            new Venue(venueId, name, address, capacity));
    }

    [Fact]
    public void Ctor_CapacityZero_DeveLancarArgumentOutOfRangeException()
    {
        // Arrange
        var venueId = 1;
        var name = "Centro";
        var address = "Av. Principal, 100";
        var capacity = 0;

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => 
            new Venue(venueId, name, address, capacity));
    }

    [Fact]
    public void Ctor_CapacityNegativo_DeveLancarArgumentOutOfRangeException()
    {
        // Arrange
        var venueId = 1;
        var name = "Centro";
        var address = "Av. Principal, 100";
        var capacity = -10;

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => 
            new Venue(venueId, name, address, capacity));
    }

    #endregion

    #region SetDescription Tests

    [Fact]
    public void SetDescription_DescricaoValida_DeveDefinirDescricao()
    {
        // Arrange
        var venue = new Venue(1, "Centro", "Av. Principal, 100", 500);
        var description = "Moderno centro com infraestrutura completa";

        // Act
        venue.SetDescription(description);

        // Assert
        Assert.Equal(description, venue.Description);
    }

    [Fact]
    public void SetDescription_DescricaoNula_DeveDefinirComoNull()
    {
        // Arrange
        var venue = new Venue(1, "Centro", "Av. Principal, 100", 500);

        // Act
        venue.SetDescription(null);

        // Assert
        Assert.Null(venue.Description);
    }

    [Fact]
    public void SetDescription_DescricaoVazia_DeveDefinirComoNull()
    {
        // Arrange
        var venue = new Venue(1, "Centro", "Av. Principal, 100", 500);

        // Act
        venue.SetDescription("");

        // Assert
        Assert.Null(venue.Description);
    }

    [Fact]
    public void SetDescription_DescricaoApenasEspacos_DeveDefinirComoNull()
    {
        // Arrange
        var venue = new Venue(1, "Centro", "Av. Principal, 100", 500);

        // Act
        venue.SetDescription("   ");

        // Assert
        Assert.Null(venue.Description);
    }

    #endregion

    #region ParkingInfo Tests

    [Fact]
    public void ParkingInfo_DefinirValorValido_DeveArmazenarValor()
    {
        // Arrange
        var venue = new Venue(1, "Centro", "Av. Principal, 100", 500);
        var parkingInfo = "Estacionamento gratuito com 200 vagas";

        // Act
        venue.ParkingInfo = parkingInfo;

        // Assert
        Assert.Equal(parkingInfo, venue.ParkingInfo);
    }

    [Fact]
    public void ParkingInfo_DefinirNull_DeveRetornarStringVazia()
    {
        // Arrange
        var venue = new Venue(1, "Centro", "Av. Principal, 100", 500);

        // Act
        venue.ParkingInfo = null;

        // Assert
        Assert.NotNull(venue.ParkingInfo);
        Assert.Equal(string.Empty, venue.ParkingInfo);
    }

    [Fact]
    public void ParkingInfo_ValorInicial_DeveSerStringVazia()
    {
        // Arrange & Act
        var venue = new Venue(1, "Centro", "Av. Principal, 100", 500);

        // Assert
        Assert.NotNull(venue.ParkingInfo);
        Assert.Equal(string.Empty, venue.ParkingInfo);
    }

    #endregion

    #region Default Property Tests

    [Fact]
    public void Default_DeveRetornarVenueOnlineEvent()
    {
        // Act
        var defaultVenue = Venue.Default;

        // Assert
        Assert.NotNull(defaultVenue);
        Assert.Equal(1, defaultVenue.VenueId);
        Assert.Equal("Online Event", defaultVenue.Name);
        Assert.Equal("Virtual", defaultVenue.Address);
        Assert.Equal(10000, defaultVenue.Capacity);
    }

    [Fact]
    public void Default_ChamadasMultiplas_DevemRetornarInstanciasDiferentes()
    {
        // Act
        var default1 = Venue.Default;
        var default2 = Venue.Default;

        // Assert
        Assert.NotSame(default1, default2);
        Assert.Equal(default1, default2); // Iguais por identidade
    }

    #endregion

    #region Identity Tests

    [Fact]
    public void Equals_VenuesComMesmoVenueId_DeveRetornarTrue()
    {
        // Arrange
        var venue1 = new Venue(1, "Centro", "Av. Principal, 100", 500);
        var venue2 = new Venue(1, "Outro Nome", "Outro Endereço", 1000);

        // Act
        var result = venue1.Equals(venue2);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Equals_VenuesComVenueIdDiferente_DeveRetornarFalse()
    {
        // Arrange
        var venue1 = new Venue(1, "Centro", "Av. Principal, 100", 500);
        var venue2 = new Venue(2, "Centro", "Av. Principal, 100", 500);

        // Act
        var result = venue1.Equals(venue2);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void Equals_ComparacaoComNull_DeveRetornarFalse()
    {
        // Arrange
        var venue = new Venue(1, "Centro", "Av. Principal, 100", 500);

        // Act
        var result = venue.Equals(null);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void GetHashCode_VenuesComMesmoVenueId_DevemTerMesmoHashCode()
    {
        // Arrange
        var venue1 = new Venue(1, "Centro", "Av. Principal, 100", 500);
        var venue2 = new Venue(1, "Outro Nome", "Outro Endereço", 1000);

        // Act
        var hash1 = venue1.GetHashCode();
        var hash2 = venue2.GetHashCode();

        // Assert
        Assert.Equal(hash1, hash2);
    }

    [Fact]
    public void ToString_DeveRetornarFormatoCorreto()
    {
        // Arrange
        var venue = new Venue(1, "Centro de Convenções", "Av. Principal, 100", 500);

        // Act
        var result = venue.ToString();

        // Assert
        Assert.Contains("Centro de Convenções", result);
        Assert.Contains("Av. Principal, 100", result);
        Assert.Contains("500", result);
    }

    #endregion
}