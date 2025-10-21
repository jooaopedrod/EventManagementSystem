# 🎯 Sistema de Gerenciamento de Eventos

**João Pedro Domingues**

---

## 📋 Sobre o Projeto

Sistema completo para gerenciamento de eventos corporativos como conferências, workshops e seminários. O projeto foi desenvolvido aplicando técnicas avançadas de **programação defensiva** e **null safety** do C# moderno, garantindo código robusto, seguro e de fácil manutenção.

### Funcionalidades Principais

- ✅ Cadastro e gerenciamento de palestrantes
- ✅ Registro de locais físicos e virtuais para eventos
- ✅ Criação e organização de eventos com validações rigorosas
- ✅ Associação entre eventos, palestrantes e locais
- ✅ Validação automática de datas, emails e capacidades
- ✅ Lazy loading de dependências opcionais

---

## 🚀 Tecnologias Utilizadas

- **.NET 9.0** - Framework de desenvolvimento
- **C# 13** - Linguagem de programação
- **xUnit** - Framework de testes unitários
- **Nullable Reference Types** - Habilitado para null safety

---

## 📁 Estrutura do Projeto

```
EventManagement/
├── README.md
├── EXPLICACAO.md
├── EventManagement.sln
├── src/
│   ├── EventManagement.Domain/
│   │   ├── EventManagement.Domain.csproj
│   │   ├── Guards/
│   │   │   └── Guard.cs
│   │   └── Entities/
│   │       ├── Speaker.cs
│   │       ├── Venue.cs
│   │       └── Event.cs
│   └── EventManagement.Console/
│       ├── EventManagement.Console.csproj
│       └── Program.cs
└── tests/
    └── EventManagement.Domain.Tests/
        ├── EventManagement.Domain.Tests.csproj
        ├── SpeakerSpecs.cs
        ├── VenueSpecs.cs
        └── EventSpecs.cs
```

---

## ⚙️ Como Criar o Projeto

### Passo 1: Criar a estrutura de pastas

```bash
# Criar diretório raiz do projeto
mkdir EventManagement
cd EventManagement

# Criar estrutura de pastas
mkdir -p src/EventManagement.Domain/Guards
mkdir -p src/EventManagement.Domain/Entities
mkdir -p src/EventManagement.Console
mkdir -p tests/EventManagement.Domain.Tests
```

### Passo 2: Criar a solution e os projetos

```bash
# Criar solution
dotnet new sln -n EventManagement

# Criar projeto de domínio (Class Library)
dotnet new classlib -n EventManagement.Domain -o src/EventManagement.Domain -f net9.0

# Criar projeto console
dotnet new console -n EventManagement.Console -o src/EventManagement.Console -f net9.0

# Criar projeto de testes
dotnet new xunit -n EventManagement.Domain.Tests -o tests/EventManagement.Domain.Tests -f net9.0

# Adicionar projetos à solution
dotnet sln add src/EventManagement.Domain/EventManagement.Domain.csproj
dotnet sln add src/EventManagement.Console/EventManagement.Console.csproj
dotnet sln add tests/EventManagement.Domain.Tests/EventManagement.Domain.Tests.csproj

# Adicionar referências entre projetos
dotnet add tests/EventManagement.Domain.Tests/EventManagement.Domain.Tests.csproj reference src/EventManagement.Domain/EventManagement.Domain.csproj
dotnet add src/EventManagement.Console/EventManagement.Console.csproj reference src/EventManagement.Domain/EventManagement.Domain.csproj
```

### Passo 3: Habilitar Nullable Reference Types

Edite os arquivos `.csproj` e adicione dentro de `<PropertyGroup>`:

```xml
<Nullable>enable</Nullable>
```

### Passo 4: Remover arquivos padrão

```bash
# Remover Class1.cs padrão
rm src/EventManagement.Domain/Class1.cs

# Remover UnitTest1.cs padrão
rm tests/EventManagement.Domain.Tests/UnitTest1.cs
```

---

## 🔧 Como Executar

### Pré-requisitos

- [.NET SDK 9.0](https://dotnet.microsoft.com/download/dotnet/9.0) ou superior instalado

### Verificar instalação do .NET

```bash
dotnet --version
# Deve retornar 9.0.x ou superior
```

### Restaurar dependências

```bash
dotnet restore
```

### Compilar o projeto

```bash
# Compilar toda a solution
dotnet build

# Compilar apenas o domínio
dotnet build src/EventManagement.Domain

# Compilar sem warnings
dotnet build --no-incremental --no-restore
```

### Executar a aplicação console

```bash
dotnet run --project src/EventManagement.Console
```

---

## 🧪 Como Executar os Testes

Esta seção contém todos os comandos necessários para executar e verificar os testes do projeto.

### Executar Testes - Comandos Básicos

### Executar todos os testes

```bash
dotnet test
```

### Executar testes com saída detalhada

```bash
dotnet test --verbosity detailed
```

### Executar testes de uma classe específica

```bash
# Apenas testes de Speaker
dotnet test --filter FullyQualifiedName~SpeakerSpecs

# Apenas testes de Venue
dotnet test --filter FullyQualifiedName~VenueSpecs

# Apenas testes de Event
dotnet test --filter FullyQualifiedName~EventSpecs
```

### Executar teste específico

```bash
dotnet test --filter "FullyQualifiedName~SpeakerSpecs.Ctor_DadosValidos_DeveCriarSpeaker"
```

---

## 🎓 Aprendizados e Boas Práticas

### ✅ Programação Defensiva

- Validação de todos os inputs antes do uso
- Fail-fast: erros detectados imediatamente
- Mensagens de erro claras e descritivas

### ✅ Null Safety

- Uso extensivo de nullable reference types
- Atributos de nullability (`[AllowNull]`, `[DisallowNull]`, `[MemberNotNull]`)
- Redução drástica de NullReferenceException

### ✅ Testes Unitários

- Cobertura completa de cenários válidos e inválidos
- Nomenclatura clara e descritiva
- Padrão AAA (Arrange-Act-Assert)

### ✅ Clean Code

- Métodos pequenos e focados
- Responsabilidades bem definidas
- Código auto-documentado

---

