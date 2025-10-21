using EventManagement.Domain.Entities;

#region Speaker Examples

Console.WriteLine("=== SPEAKER EXAMPLES ===\n");

// Exemplo 1: Criar palestrante válido
try
{
    var speaker1 = new Speaker(1, "João Silva", "joao@email.com");
    Console.WriteLine($"✓ Palestrante criado: {speaker1.FullName}");
    Console.WriteLine($"  Email: {speaker1.Email}");
    Console.WriteLine();
}
catch (Exception ex)
{
    Console.WriteLine($"✗ Erro: {ex.Message}\n");
}

// Exemplo 2: Tentar criar com SpeakerId inválido
try
{
    var speakerInvalido = new Speaker(-1, "Maria Santos", "maria@email.com");
    Console.WriteLine($"✓ Palestrante criado: {speakerInvalido.FullName}");
}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine($"✗ Erro ao criar palestrante com ID negativo:");
    Console.WriteLine($"  {ex.Message}\n");
}

// Exemplo 3: Tentar criar com email inválido
try
{
    var speakerEmailInvalido = new Speaker(2, "Pedro Costa", "pedroemail.com");
    Console.WriteLine($"✓ Palestrante criado: {speakerEmailInvalido.FullName}");
}
catch (ArgumentException ex)
{
    Console.WriteLine($"✗ Erro ao criar palestrante com email sem @:");
    Console.WriteLine($"  {ex.Message}\n");
}

// Exemplo 4: SetBiography com diferentes valores
var speaker2 = new Speaker(3, "Ana Paula", "ana@email.com");
Console.WriteLine($"✓ Palestrante criado: {speaker2.FullName}");

speaker2.SetBiography("Especialista em C# com 10 anos de experiência");
Console.WriteLine($"  Biografia definida: {speaker2.Biography}");

speaker2.SetBiography(null);
Console.WriteLine($"  Biografia após null: {speaker2.Biography ?? "NULL"}");

speaker2.SetBiography("   ");
Console.WriteLine($"  Biografia após espaços: {speaker2.Biography ?? "NULL"}\n");

// Exemplo 5: Company e LinkedInProfile com [AllowNull]
var speaker3 = new Speaker(4, "Carlos Mendes", "carlos@email.com");
speaker3.Company = "Tech Corp";
speaker3.LinkedInProfile = "https://linkedin.com/in/carlosmendes";
Console.WriteLine($"✓ Palestrante: {speaker3.FullName}");
Console.WriteLine($"  Company: '{speaker3.Company}'");
Console.WriteLine($"  LinkedIn: '{speaker3.LinkedInProfile}'");

speaker3.Company = null;
speaker3.LinkedInProfile = null;
Console.WriteLine($"  Após definir null:");
Console.WriteLine($"  Company: '{speaker3.Company}' (nunca null)");
Console.WriteLine($"  LinkedIn: '{speaker3.LinkedInProfile}' (nunca null)\n");

#endregion

#region Venue Examples

Console.WriteLine("=== VENUE EXAMPLES ===\n");

// Exemplo 1: Criar local válido
try
{
    var venue1 = new Venue(1, "Centro de Convenções", "Av. Principal, 100", 500);
    Console.WriteLine($"✓ Local criado: {venue1.Name}");
    Console.WriteLine($"  Endereço: {venue1.Address}");
    Console.WriteLine($"  Capacidade: {venue1.Capacity} pessoas\n");
}
catch (Exception ex)
{
    Console.WriteLine($"✗ Erro: {ex.Message}\n");
}

// Exemplo 2: Demonstrar Venue.Default
var venueDefault = Venue.Default;
Console.WriteLine($"✓ Venue Default: {venueDefault.Name}");
Console.WriteLine($"  Endereço: {venueDefault.Address}");
Console.WriteLine($"  Capacidade: {venueDefault.Capacity}\n");

// Exemplo 3: SetDescription
var venue2 = new Venue(2, "Auditório Municipal", "Rua das Flores, 50", 200);
venue2.SetDescription("Moderno auditório com sistema de som profissional");
Console.WriteLine($"✓ Local: {venue2.Name}");
Console.WriteLine($"  Descrição: {venue2.Description}\n");

// Exemplo 4: ParkingInfo com [AllowNull]
var venue3 = new Venue(3, "Teatro Central", "Praça da Cultura, 10", 300);
venue3.ParkingInfo = "Estacionamento gratuito com 150 vagas";
Console.WriteLine($"✓ Local: {venue3.Name}");
Console.WriteLine($"  Estacionamento: '{venue3.ParkingInfo}'");

venue3.ParkingInfo = null;
Console.WriteLine($"  Após null: '{venue3.ParkingInfo}' (nunca null)\n");

#endregion

#region Event Examples

Console.WriteLine("=== EVENT EXAMPLES ===\n");

// Exemplo 1: Criar evento válido
try
{
    var event1 = new Event(1, "Workshop de C#", DateTime.Now.AddMonths(2), TimeSpan.FromHours(4));
    Console.WriteLine($"✓ Evento criado: {event1.Title}");
    Console.WriteLine($"  Data: {event1.EventDate:dd/MM/yyyy}");
    Console.WriteLine($"  Duração: {event1.Duration.TotalHours}h\n");
}
catch (Exception ex)
{
    Console.WriteLine($"✗ Erro: {ex.Message}\n");
}

// Exemplo 2: Tentar criar evento no passado
try
{
    var eventPassado = new Event(2, "Evento Passado", DateTime.Now.AddDays(-1), TimeSpan.FromHours(2));
    Console.WriteLine($"✓ Evento criado: {eventPassado.Title}");
}
catch (ArgumentException ex)
{
    Console.WriteLine($"✗ Erro ao criar evento no passado:");
    Console.WriteLine($"  {ex.Message}\n");
}

// Exemplo 3: Lazy loading de Venue
var event2 = new Event(3, "Seminário de Arquitetura", DateTime.Now.AddMonths(1), TimeSpan.FromHours(6));
Console.WriteLine($"✓ Evento: {event2.Title}");
Console.WriteLine($"  Venue (lazy loaded): {event2.Venue.Name}");
var venueAgain = event2.Venue;
Console.WriteLine($"  Múltiplos acessos retornam mesma instância: {ReferenceEquals(event2.Venue, venueAgain)}\n");

// Exemplo 4: SetEventCode com [DisallowNull]
var event3 = new Event(4, "Tech Summit 2025", DateTime.Now.AddMonths(3), TimeSpan.FromHours(8));
Console.WriteLine($"✓ Evento: {event3.Title}");
Console.WriteLine($"  EventCode inicial: '{event3.EventCode}' (vazio, nunca null)");

event3.SetEventCode("  TECHSUMMIT2025  ");
Console.WriteLine($"  EventCode após set: '{event3.EventCode}' (com trim automático)\n");

// Exemplo 5: Requirements e Notes com [AllowNull]
var event4 = new Event(5, "Bootcamp Full Stack", DateTime.Now.AddMonths(2), TimeSpan.FromHours(40));
event4.Requirements = "Conhecimento básico em programação";
event4.Notes = "Material fornecido pela organização";
Console.WriteLine($"✓ Evento: {event4.Title}");
Console.WriteLine($"  Requirements: '{event4.Requirements}'");
Console.WriteLine($"  Notes: '{event4.Notes}'");

event4.Requirements = null;
event4.Notes = null;
Console.WriteLine($"  Após null:");
Console.WriteLine($"  Requirements: '{event4.Requirements}' (nunca null)");
Console.WriteLine($"  Notes: '{event4.Notes}' (nunca null)\n");

#endregion

#region Complete Scenario

Console.WriteLine("=== CENÁRIO COMPLETO ===\n");

// Criar palestrante
var palestrante = new Speaker(10, "João Silva", "joao@email.com");
palestrante.SetBiography("Especialista em C# com 10 anos de experiência");
palestrante.Company = "Tech Corp";
palestrante.LinkedInProfile = "https://linkedin.com/in/joaosilva";

Console.WriteLine($"✓ Palestrante: {palestrante.FullName}");
Console.WriteLine($"  Biografia: {palestrante.Biography}");
Console.WriteLine($"  Empresa: {palestrante.Company}");
Console.WriteLine();

// Criar local
var local = new Venue(10, "Centro de Convenções", "Av. Principal, 100", 500);
local.SetDescription("Moderno centro com infraestrutura completa");
local.ParkingInfo = "Estacionamento gratuito com 200 vagas";

Console.WriteLine($"✓ Local: {local.Name}");
Console.WriteLine($"  Endereço: {local.Address}");
Console.WriteLine($"  Capacidade: {local.Capacity}");
Console.WriteLine($"  Descrição: {local.Description}");
Console.WriteLine();

// Criar evento
var evento = new Event(10, ".NET Conference 2025", new DateTime(2025, 12, 15), TimeSpan.FromHours(8));
evento.SetEventCode("NETCONF2025");
evento.SetDescription("Conferência anual sobre tecnologias .NET");
evento.Requirements = "Conhecimento em C# ou interesse em aprender";
evento.Notes = "Coffee break e almoço incluídos";
evento.AssignMainSpeaker(palestrante);

Console.WriteLine($"✓ Evento: {evento.Title}");
Console.WriteLine($"  Código: {evento.EventCode}");
Console.WriteLine($"  Data: {evento.EventDate:dd/MM/yyyy}");
Console.WriteLine($"  Duração: {evento.Duration.TotalHours}h");
Console.WriteLine($"  Descrição: {evento.Description}");
Console.WriteLine($"  Requisitos: {evento.Requirements}");
Console.WriteLine($"  Observações: {evento.Notes}");
Console.WriteLine();

// Exibir informações completas
Console.WriteLine("=== RESUMO DO EVENTO ===");
Console.WriteLine(evento);
Console.WriteLine($"Local: {evento.Venue}");
Console.WriteLine($"Palestrante: {evento.MainSpeaker?.FullName ?? "A definir"}");
Console.WriteLine($"Email do palestrante: {evento.MainSpeaker?.Email ?? "N/A"}");
Console.WriteLine($"Empresa: {evento.MainSpeaker?.Company ?? "N/A"}");

#endregion