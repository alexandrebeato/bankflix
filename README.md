<p align="center">
  <img alt="trivelum logo" src="logo.png" /> 
</p>

[![Build status](https://dev.azure.com/alexandrebeato-com/Bankflix/_apis/build/status/Bankflix-CI)](https://dev.azure.com/alexandrebeato-com/Bankflix/_build/latest?definitionId=9)

## Architecture

### Overview

**Bankflix** is a multi-client digital bank platform built as a **Clean Architecture Modular Monolith** with event-driven async processing. The system is organized into independent **bounded contexts** (Agencia, Clientes, Movimentacoes) that follow **Domain-Driven Design** principles, communicate via commands and events, and integrate through a centralized API gateway.

**Key Architectural Characteristics:**
- **Style:** Clean Architecture / Layered + Modular Monolith with DDD
- **Communication:** Synchronous (REST API), Asynchronous (RabbitMQ + Command Queue)
- **Pattern:** CQRS (Command Query Responsibility Segregation) via MediatR for Clientes & Movimentacoes; Traditional layered approach for Agencia
- **Database:** NoSQL (MongoDB) for all persistence
- **Deployment:** Containerized (Docker) with Docker Compose orchestration

### Technology Stack

| Component | Technology | Purpose | Evidence |
|-----------|-----------|---------|----------|
| **API Server** | ASP.NET Core 3.1+ (.NET Framework) | REST API, core orchestration | `server/src/Bankflix.API/` |
| **Web Client** | Angular 8.x, TypeScript, Bootstrap, Material Design | Front-end web application | `clients/angular/package.json` (Angular 8.1.2) |
| **Mobile Client** | Flutter (Dart) with MobX state management | Cross-platform mobile app (iOS/Android) | `clients/flutter/pubspec.yaml` (Flutter SDK >=2.1.0) |
| **Database** | MongoDB 5.x | Document store for all aggregates | `docker-compose.yml` (mongo:latest) |
| **Message Queue** | RabbitMQ 3.x | Async command processing & event sourcing | `docker-compose.yml` (rabbitmq:3-management) |
| **Mediator** | MediatR 7.0.0 | Command/Query routing & Event handling | `Core.Domain/Core.Domain.csproj` |
| **ORM/Mapping** | MongoDB.Driver 2.9.2, AutoMapper 6.0.0 | Data mapping & object-document mapping | `*.csproj` dependencies |
| **Resilience** | Polly 7.1.1 | Retry policies for RabbitMQ connection | `Core.Domain/Services/QueueHostedService.cs` |
| **Validation** | FluentValidation | Domain-level & command validation | Core.Domain patterns |
| **Authentication** | JWT (HS256) | Stateless API authentication | `Bankflix.API/Configurations/ConfiguracoesSeguranca.cs` |

### Components & Responsibilities

| Component | Tech | Responsibility | Evidence |
|-----------|------|-----------------|----------|
| **Bankflix.API** | ASP.NET Core | HTTP endpoints, request routing, dependency injection bootstrap | `server/src/Bankflix.API/Program.cs`, `Startup.cs` |
| **Core.Domain** | C# | Base abstractions: Commands, Events, Entities, ValueObjects, Repositories, Validators, MediatorHandler, QueueHostedService | `server/src/Core.Domain/` |
| **Agencia Context** | C# + MongoDB | Agency/Branch management (non-CQRS traditional layer approach). Entities: Agencia, Usuario (Admin). Single instance on startup. | `server/src/Agencia.Domain/`, `Agencia.Infra.Data/` |
| **Clientes Context** | C# + MongoDB + CQRS | Client lifecycle: registration, approval, rejection. Commands: CadastrarCliente, AprovarCliente, RecusarCliente. Events trigger email notifications. | `server/src/Clientes.Domain/`, `Clientes.CommandStack/`, `Clientes.Commands/` |
| **Movimentacoes Context** | C# + MongoDB + CQRS + RabbitMQ | Financial transactions: Depositos (Deposits) & Transferencias (Transfers). Async processing: SolicitarDeposito → queue → EfetuarDeposito (30s delay demo). | `server/src/Movimentacoes.Domain/`, `Movimentacoes.CommandStack/`, `Movimentacoes.Commands/` |
| **Angular Client** | TypeScript, Angular 8.x | Web UI for client & admin portals. Communicates with API via HTTP/JWT. | `clients/angular/src/` |
| **Flutter Client** | Dart, Flutter | Mobile app (iOS/Android). Uses MobX for state management, Dio for HTTP. | `clients/flutter/lib/` |
| **RabbitMQ Container** | Docker image: rabbitmq:3-management | Message broker. Virtual host: rabbitmq-bankflix. Credentials: guest/guest. | `docker-compose.yml` |
| **MongoDB Container** | Docker image: mongo:latest | NoSQL database. All domain aggregates stored as documents. | `docker-compose.yml` |

### Folder Structure & Responsibilities

```
bankflix/
├── server/
│   ├── src/
│   │   ├── Bankflix.API/
│   │   │   ├── Controllers/          # HTTP endpoints (Agencia, Clientes, Movimentacoes)
│   │   │   ├── Configurations/       # Security (JWT), Queue services, AutoMapper
│   │   │   ├── Models/               # DTOs for API responses
│   │   │   ├── Mapper/               # AutoMapper profiles
│   │   │   ├── Program.cs            # Entry point; Agencia initialization
│   │   │   └── Startup.cs            # Service registration & middleware config
│   │   │
│   │   ├── Core.Domain/
│   │   │   ├── Commands/             # Base Command abstract class (MediatR IRequest)
│   │   │   ├── Events/               # Base Event abstract class (MediatR INotification)
│   │   │   ├── CommandHandlers/      # MediatorHandler (routes to local or queue)
│   │   │   ├── Models/               # Entity<T> (aggregate root base); ValidationResult
│   │   │   ├── ValueObjects/         # ValueObject<T> base (immutable domain values)
│   │   │   ├── Repository/           # IRepository, IMongoSequenceRepository interfaces
│   │   │   ├── Services/             # QueueHostedService, IQueueableService
│   │   │   ├── Interfaces/           # IMediatorHandler, IUsuario, IEntity
│   │   │   ├── Validations/          # DomainValidator, DomainSpecification
│   │   │   ├── Notifications/        # DomainNotification (aggregates domain errors)
│   │   │   └── Extensions/           # Validation rules, entity extensions
│   │   │
│   │   ├── Agencia.Domain/
│   │   │   ├── Agencia/              # Agencia entity (aggregate root)
│   │   │   └── Repository/           # IAgenciaRepository interface
│   │   │
│   │   ├── Agencia.Infra.CrossCutting/
│   │   │   └── DependencyRegistration/ # BootstrapperAgencia (registers Agencia services)
│   │   │
│   │   ├── Agencia.Infra.Data.Mongo/
│   │   │   └── Repository/           # AgenciaRepository (MongoDB persistence)
│   │   │
│   │   ├── Clientes.Domain/
│   │   │   ├── Clientes/             # Cliente entity (aggregate root) + validations
│   │   │   ├── Contas/               # Conta (Account) entity + specifications
│   │   │   └── Repository/           # Interfaces: IClienteRepository, IContaRepository
│   │   │
│   │   ├── Clientes.Commands/
│   │   │   ├── Clientes/             # CadastrarClienteCommand, AprovarClienteCommand, RecusarClienteCommand
│   │   │   └── Contas/               # CriarContaCommand, AdicionarValorSaldoContaCommand, RemoverValorSaldoContaCommand
│   │   │
│   │   ├── Clientes.CommandStack/
│   │   │   ├── Clientes/
│   │   │   │   ├── Events/           # ClienteCadastradoEvent, ClienteAprovadoEvent, ClienteRecusadoEvent
│   │   │   │   └── Handlers/         # ClienteCommandHandler, ClienteEventHandler
│   │   │   └── Contas/
│   │   │       └── Handlers/         # ContaCommandHandler
│   │   │
│   │   ├── Clientes.Infra.CrossCutting/
│   │   │   └── DependencyRegistration/ # BootstrapperClientes (registers handlers, repositories)
│   │   │
│   │   ├── Clientes.Infra.Data.Mongo/
│   │   │   └── Repository/           # ClienteRepository, ContaRepository (MongoDB)
│   │   │
│   │   ├── Movimentacoes.Domain/
│   │   │   ├── Depositos/            # Deposito entity (aggregate root)
│   │   │   ├── Transferencias/       # Transferencia entity (aggregate root)
│   │   │   ├── Movimentacoes/        # Movimentacao (Transaction record) entity
│   │   │   ├── Clientes/ & Contas/   # Value Objects referencing other contexts
│   │   │   └── Repository/           # Interfaces: IDepositoRepository, ITransferenciaRepository, IMovimentacaoRepository
│   │   │
│   │   ├── Movimentacoes.Commands/
│   │   │   ├── Depositos/            # SolicitarDepositoCommand, EfetuarDepositoCommand
│   │   │   ├── Transferencias/       # SolicitarTransferenciaCommand, EfetuarTransferenciaCommand
│   │   │   └── Movimentacoes/        # RegistrarMovimentacaoCommand
│   │   │
│   │   ├── Movimentacoes.CommandStack/
│   │   │   ├── Depositos/
│   │   │   │   ├── Events/           # DepositoSolicitadoEvent
│   │   │   │   └── Handlers/         # DepositoCommandHandler, DepositoEventHandler
│   │   │   ├── Transferencias/
│   │   │   │   ├── Events/           # TransferenciaSolicitadaEvent
│   │   │   │   └── Handlers/         # TransferenciaCommandHandler, TransferenciaEventHandler
│   │   │   └── Movimentacoes/
│   │   │       └── Handlers/         # MovimentacaoCommandHandler
│   │   │
│   │   ├── Movimentacoes.Infra.CrossCutting/
│   │   │   └── DependencyRegistration/ # BootstrapperMovimentacoes (registers handlers, defines queueable commands)
│   │   │
│   │   └── Movimentacoes.Infra.Data.Mongo/
│   │       └── Repository/           # DepositoRepository, TransferenciaRepository, MovimentacaoRepository (MongoDB)
│   │
│   ├── Bankflix.Core.sln             # Visual Studio solution file
│   ├── global.json                   # .NET SDK version specification
│   └── Dockerfile                    # ASP.NET Core runtime image
│
├── clients/
│   ├── angular/
│   │   ├── src/
│   │   │   ├── app/                  # Angular components, services, guards, interceptors
│   │   │   ├── assets/               # Static images, styles
│   │   │   ├── environments/         # API endpoint configuration (dev/prod)
│   │   │   ├── index.html            # Entry HTML
│   │   │   └── main.ts               # Bootstrap Angular app
│   │   ├── angular.json              # Angular CLI config
│   │   ├── Dockerfile                # Node + Nginx reverse proxy for SPA
│   │   ├── nginx-custom.conf         # Nginx routing (rewrites to index.html for SPA)
│   │   ├── package.json              # Dependencies (Angular 8.1.2, Material, Bootstrap, RxJS)
│   │   └── tsconfig.json             # TypeScript compilation config
│   │
│   └── flutter/
│       ├── lib/
│       │   ├── main.dart             # App entry point
│       │   ├── dependency-injector.dart # Service locator / DI setup
│       │   ├── controllers/          # MobX observables (state management)
│       │   ├── models/               # Data models
│       │   ├── pages/                # UI screens (login, dashboard, transactions)
│       │   ├── repository/           # HTTP clients (Dio) for API communication
│       │   ├── themes/               # Material theme configuration
│       │   ├── widgets/              # Reusable UI components
│       │   └── utils/                # Helpers, extensions
│       ├── android/                  # Android native config (Gradle)
│       ├── ios/                      # iOS native config (Cocoapods, Xcode project)
│       ├── pubspec.yaml              # Flutter dependencies (Dio 3.0.9, MobX, Provider, Intl)
│       └── test/                     # Widget tests
│
├── docker-compose.yml                # Multi-container orchestration: api, client (Nginx), mongo, rabbitmq
└── README.md                         # This file
```

### Key Patterns

| Pattern | Where Used | Purpose | Evidence |
|---------|-----------|---------|----------|
| **CQRS (Command Query Responsibility Segregation)** | Clientes, Movimentacoes contexts | Separate read/write operations; Commands trigger business logic, Events notify side effects. | `Clientes.Commands/`, `Clientes.CommandStack/`, `Movimentacoes.Commands/`, `Movimentacoes.CommandStack/` |
| **MediatR Pipeline** | Core.Domain.CommandHandlers.MediatorHandler | Central command/event router; integrates with RabbitMQ for async queue dispatch. | `Core.Domain/CommandHandlers/MediatorHandler.cs` |
| **Repository Pattern** | All Infra.Data.Mongo projects | Abstract data access; isolate persistence logic from domain. | `*Infra.Data.Mongo/Repository/` classes (ClienteRepository, DepositoRepository, etc.) |
| **Dependency Injection** | Startup.cs, Bootstrappers | Modular service registration; each context (Agencia, Clientes, Movimentacoes) has its own Bootstrapper class. | `BootstrapperAgencia.cs`, `BootstrapperClientes.cs`, `BootstrapperMovimentacoes.cs` |
| **Domain Events** | Entity aggregates (Cliente, Deposito, Transferencia) | Publish events when state changes; async event handlers process side effects (email, queue). | `ClienteCadastradoEvent`, `DepositoSolicitadoEvent`, `TransferenciaSolicitadaEvent` |
| **Value Objects** | Domain entities (e.g., Conta, Cliente in Movimentacoes context) | Immutable domain values; encapsulate business logic without identity. | `Core.Domain/ValueObjects/ValueObject<T>`, `Movimentacoes.Domain/Transferencias/ValueObjects/Conta.cs` |
| **Entity/Aggregate Root** | Each domain context | Root of consistency boundary; responsible for invariant enforcement. | `Entity<T>` base class; Cliente, Deposito, Transferencia aggregates |
| **Specification Pattern** | Clientes.Domain queries | Encapsulate domain queries/rules; e.g., "ClienteDevePossuirApenasUmaContaSpecification". | `*Domain/*Specifications/*.cs` |
| **Unit of Work** | Implicit in Repository + MongoDB sessions | Transaction-like semantics across aggregate operations. | MongoDB session management in repositories |
| **Mediator Handler with Queue Dispatch** | MediatorHandler.SendCommand(enqueue: true) | Deferred/asynchronous command execution; long-running operations (deposit/transfer processing) | `MediatorHandler.SendCommand()` with RabbitMQ publishing |
| **Hosted Service (Background Worker)** | QueueHostedService | Listen for commands on RabbitMQ queue during app lifetime; 30-second delay is demo of async processing. | `Core.Domain/Services/QueueHostedService.cs` (IHostedService) |
| **Retry Policy** | Polly (RabbitMQ connection) | Resilience; ensure application starts only after RabbitMQ is available. | `QueueHostedService`: `Policy.Handle<BrokerUnreachableException>().WaitAndRetryForever()` |
| **JWT Authentication** | API Controllers | Stateless auth; HS256 symmetric key. Policies: "Agencia", "Cliente", "Autenticado", "Bearer". | `ConfiguracoesSeguranca.cs` (IssuerSigningKey, TokenValidationParameters) |
| **Layered Architecture (Traditional)** | Agencia context only | Unlike Clientes/Movimentacoes, Agencia uses direct Domain → Repository → MongoDB without CQRS. | `Agencia.Domain/`, `Agencia.Infra.Data/` (no CommandStack, no events) |
| **Object Mapping** | AutoMapper | Convert domain models ↔ API DTOs; decouple API contracts from domain. | `Bankflix.API/Mapper/`, `AutoMapperConfiguration.RegisterMappings()` |
| **Domain Validation** | FluentValidation + DomainValidator | Fluent rule chain; domain aggregates validate own invariants. | `Core.Domain/Validations/DomainValidator<T>` |

### Runtime / Deployment

**Docker Compose Services:**

```yaml
api:
  Container: ASP.NET Core (port 5002:80)
  Dependencies: mongo, rabbitmq
  Env:
    - mongoConnection__server=mongodb://mongo:27017/bankflix
    - rabbitmq__uri=amqp://guest:guest@rabbitmq:5672/rabbitmq-bankflix

client:
  Container: Node.js build → Nginx (port 5001:80)
  Dependencies: api
  Role: SPA reverse proxy (rewrites to /index.html)

mongo:
  Image: mongo:latest
  Port: 27018 (external) → 27017 (internal)
  Database: bankflix (created on first write)

rabbitmq:
  Image: rabbitmq:3-management
  Ports: 5673 (AMQP) → 5672, 15673 (Management UI) → 15672
  Vhost: rabbitmq-bankflix
  Default credentials: guest:guest
```

**Application Startup Sequence:**

1. **Program.cs Main():**
   - Creates IHostBuilder with Startup configuration
   - On host build, calls ConfigurarAgencia() to initialize default agency (Agencia entity, admin user)
   - Sets up scoped dependency resolution for initial data setup

2. **Startup.cs ConfigureServices():**
   - Registers authentication (JWT) via `ConfigurarAutenticacao()`
   - Registers queue infrastructure via `ConfigurarServicosFila()`
   - Adds MediatR handlers for all contexts (Commands, Events, Validators)
   - Registers module-specific services via Bootstrappers (Agencia, Clientes, Movimentacoes)
   - Adds AutoMapper for DTO mapping
   - Adds QueueHostedService (background worker for RabbitMQ consumer)

3. **QueueHostedService StartAsync():**
   - Connects to RabbitMQ with Polly retry policy (5s backoff) until available
   - Declares queues for each queueable command (EfetuarDepositoCommand, EfetuarTransferenciaCommand)
   - Registers EventingBasicConsumer for each queue
   - On message received: deserialize JSON → find command type → create scope → dispatch via IMediator

**Environment Configuration:**

- **MongoDB:** Connection string from `mongoConnection__server` env var
- **RabbitMQ:** Connection URI from `rabbitmq__uri` env var (AMQP protocol, vhost: rabbitmq-bankflix)
- **API Port:** 5002 (inside container: 80)
- **Client Port:** 5001 (inside container: 80, Nginx serves Angular SPA)
- **Volumes:** None (demo setup; data lost on container stop)

**How to Run:**

```bash
# Clone and navigate
git clone https://github.com/alexandrebeato/bankflix.git
cd bankflix

# Build and start all containers (detached mode)
docker-compose up --build -d

# Containers become available:
# - Web UI:  http://localhost:5001/
# - API:     http://localhost:5002/
# - RabbitMQ Management: http://localhost:15673/ (guest/guest)

# To view logs
docker-compose logs -f api

# To stop
docker-compose down
```

**How to Develop (Local):**

**Backend (.NET/C#):**
- Open `server/Bankflix.Core.sln` in Visual Studio 2019+
- Set `Bankflix.API` as startup project
- Ensure MongoDB and RabbitMQ are running (or use docker-compose for only those)
- Run with IIS Express or dotnet CLI: `dotnet run` from `server/src/Bankflix.API/`
- API listens on http://localhost:5000 (dev) or configured port

**Frontend (Angular):**
- Navigate to `clients/angular/`
- Install: `npm install`
- Serve: `npm start` (ng serve on http://localhost:4200)
- Angular proxy (in `angular.json`) points to API backend
- Build: `npm run build`

**Mobile (Flutter):**
- Navigate to `clients/flutter/`
- Get dependencies: `flutter pub get`
- Run on simulator: `flutter run` (select iOS/Android)
- Build APK (Android): `flutter build apk`
- Build IPA (iOS): `flutter build ios`

### Data Flow

**Synchronous - Typical REST Request (GET):**

```
Client (Angular/Flutter)
  → HTTP GET /api/clientes/{id}
  → Bankflix.API Controller (ClientesController)
  → MediatorHandler.SendCommand(GetClienteQuery)
  → IRequestHandler<GetClienteQuery, Cliente>
  → IClienteRepository.GetById(id)
  → MongoDB: db.clientes.findOne({_id: ...})
  → Domain Model (Cliente entity) returned
  → AutoMapper DTO conversion
  → JSON response to client
```

**Asynchronous - Transaction Processing (CQRS + Queue):**

```
1. User initiates deposit request via Angular
   Client → POST /api/movimentacoes/depositos
   → DepositoController.SolicitarDeposito()
   → MediatorHandler.SendCommand(SolicitarDepositoCommand)  [sync, enqueue=false]
   → DepositoCommandHandler (validation, domain logic)
   → Deposito entity created with status "Pendente"
   → DepositoSolicitadoEvent published (MediatR, in-process)

2. Event triggers queue handler
   DepositoEventHandler receives DepositoSolicitadoEvent
   → MediatorHandler.SendCommand(EfetuarDepositoCommand, enqueue=true)
   → MediatorHandler.PublicarFila() sends JSON command to RabbitMQ
   → Command queued: queue name = "Movimentacoes.Commands.Depositos.EfetuarDepositoCommand"

3. Background worker consumes & executes (after 30s demo delay)
   QueueHostedService listening on all queueable command queues
   → Receives message from RabbitMQ
   → Deserializes JSON → EfetuarDepositoCommand
   → Thread.Sleep(30000) [30-second demo delay]
   → IMediator.Send(EfetuarDepositoCommand)
   → DepositoCommandHandler (execution: update balance, create Movimentacao record)
   → On success: acknowledge message (manual ACK)
   → On failure: return message to queue (retry mechanism)

4. Client polls or subscribes for status update
   Client → GET /api/movimentacoes/depositos/{id}
   → DepositoRepository retrieves updated Deposito
   → Status now "Processado" (Processed) or "Rejeitado" (Rejected)
```

**Event-Driven - Email Notification Side Effect:**

```
1. Client approval triggers event
   AprovarClienteCommand → ClienteAprovadoEvent

2. Event handler captures notification side effect
   ClienteEventHandler receives ClienteAprovadoEvent
   → Email notification (simulated, no actual SMTP)
   → Application event logged
```

**Architectural Boundary - Cross-Context Communication:**

```
Movimentacoes context (Deposito) needs Cliente & Conta info
  → Uses Value Objects (Cliente, Conta) in Movimentacoes.Domain
  → These are references/projections, not full aggregates
  → Queries: IClienteRepository, IContaRepository (via DI)
  → Repositories belong to Clientes context but are injected into Movimentacoes handlers
  → Maintains eventual consistency; no tight coupling between aggregates
```

**Agencia Context - Simple Direct Approach (No CQRS):**

```
GET /api/agencias/{id}
  → AgenciaController
  → IAgenciaRepository.GetById(id)
  → MongoDB
  → Return Agencia DTO
```
(No commands, events, or async processing; direct domain access.)

### Database Schema (MongoDB)

**Collections:**
- `agencias` - Agency records (one per deployment)
- `clientes` - Client profiles (email, nome, CPF, status: "Pendente"/"Aprovado"/"Rejeitado")
- `contas` - Bank accounts (saldo/balance in cents, agencia_id, cliente_id)
- `depositos` - Deposit transactions (valor, status: "Pendente"/"Processado"/"Rejeitado", conta_id)
- `transferencias` - Transfer transactions (valor, conta_origem_id, conta_destino_id, status, cliente_id)
- `movimentacoes` - Final transaction records (linked to deposito/transferencia, posted to ledger)

**Sequence Generation:**
- `sequences` collection tracks MongoDB auto-increment counters (via MongoSequenceRepository)

### Observability

**Logging:**
- Console output in QueueHostedService: `Console.WriteLine()` on message receipt, deserialization, errors
- No centralized logging framework (ELK, Serilog) in current code; indicated as improvement area

**Error Handling:**
- Domain validation errors captured in Entity.ValidationResult (FluentValidation)
- Domain errors propagated via DomainNotification
- Queue message ACK/NACK based on command handler success/failure

**Monitoring Recommendations:**
- Add application logging (Serilog, NLog) to capture request/response, command execution, queue metrics
- Monitor RabbitMQ queue depth & consumer lag (RabbitMQ Management UI at localhost:15673)
- Database query profiling (MongoDB Profiler)
- Application Performance Monitoring (APM): Application Insights, Datadog, or New Relic integration

## Getting Started

To run the application:

```
git clone https://github.com/alexandrebeato/bankflix.git
cd bankflix
docker-compose up --build -d
```

The Angular application (front-end) can be accessed at the endpoint `http://localhost:5001/` and the API (back-end) can be accessed at the endpoint `http://localhost:5002/`.

## About

The **Bankflix** project simulates a digital bank, containing both client and administrative areas, allowing deposits and transfers between accounts within the same bank.

## Give it a star! :star:

If you liked the project or if it helped you, please give it a star ;)

## Attention

This is not a project to be used in production. It is only a demonstration of the technologies and architecture it was built with. **There are adjustments and improvements to be made**.

## Agency Access Data

**CNPJ:** 03569262000160

**Password:** 123456

## Important Information

- All values are internally treated as cents and converted to R$ only for client display.
- Events orchestrated by queues will have a 30-second delay just to demonstrate the use of the queue.
- The AGENCY context does not use CQRS to demonstrate that different patterns can be maintained as needed.
- It is possible to monitor manual ACK with the queue system by re-inserting the transaction into the queue in case of any failure.
- The containers **do not** use volumes, so stopping them will result in data loss.
- The application may take a few seconds to start because the queue service (RabbitMQ) takes some time to become available for connections. There is a Retry policy using Polly to ensure the application starts only when the service is functioning correctly.

## Workflow

- When starting the application for the first time, an agency with an administrator user will be registered.
- When creating an account, the client will have a pending status until the administrator approves the registration.
- Upon approval or rejection, an email event will be triggered (simulation only, no actual email is sent) to notify the client.
- Upon approval, a bank account will be automatically created and linked to the client with a zero balance.
- The client can make online deposits (simulated, any amount can be entered) that will initially be marked as pending and added to the queue for processing.
- The client can transfer funds to other accounts, and the transfer request will be marked as pending and added to the queue for processing or cancellation.
- When deposits or transfers are processed/rejected (canceled), an email event will be triggered (simulation only, no actual email is sent) to notify the clients.
- When deposits or transfers are successfully processed, the transaction will be recorded.

## Author 👦

- **Alexandre Beato** - _Developer_ - [GitHub](https://github.com/alexandrebeato) - [LinkedIn](https://www.linkedin.com/in/alexandrebeato)

## Roadmap 🗺

| Item                 | Date |
| -------------------- | ---- |
| Tests                | TBD  |
| Mobile App (Flutter) | ✔    |

## License 📃

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details
