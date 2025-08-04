# UrlShortener

A simple URL shortening service built with ASP.NET Core, Entity Framework Core, Redis, and PostgreSQL. This project demonstrates a clean architecture approach with separation of concerns across Application, Domain, and Infrastructure layers.

## Features
- Shorten long URLs to compact, shareable links
- Resolve shortened URLs to their original destinations
- Caching with Redis for fast lookups
- Persistent storage with PostgreSQL
- Clean architecture with CQRS (Command Query Responsibility Segregation)
- Unit and integration tests

## Project Structure
```
UrlShortener.sln                # Solution file
UrlShortener/                   # Main project
├── Api/                        # API controllers
├── Application/                # Application logic, CQRS handlers, interfaces
│   ├── Commands/               # Command definitions and handlers
│   └── Queries/                # Query definitions and handlers
├── Domain/                     # Domain models/entities
├── Infrastructure/             # Infrastructure (DB, cache, etc.)
│   ├── Cache/                  # Redis cache implementation
│   └── Persistance/            # EF Core DbContext and repository
├── appsettings.json            # Configuration files
└── Program.cs                  # Entry point
UrlShortener.Tests/             # Test project
├── Application/                # Application layer tests
└── Shortening/                 # Shortening handler tests
```

## Getting Started

### Prerequisites
- [.NET 9 SDK](https://dotnet.microsoft.com/)
- [PostgreSQL](https://www.postgresql.org/)
- [Redis](https://redis.io/)

### Setup
1. **Clone the repository:**
   ```sh
   git clone <repo-url>
   cd UrlShortener/dot_net/UrlShortener
   ```
2. **Configure the database and cache:**
   - Update `appsettings.json` with your PostgreSQL and Redis connection strings.
3. **Apply database migrations:**
   ```sh
   dotnet ef database update --project UrlShortener/Infrastructure/Persistance/UrlDbContext.cs
   ```
4. **Run the application:**
   ```sh
   dotnet run --project UrlShortener
   ```
5. **Run tests:**
   ```sh
   dotnet test
   ```

## API Usage
- **Shorten URL:** `POST /api/url/shorten`
- **Resolve URL:** `GET /api/url/{shortCode}`

See `UrlShortener.http` for example requests.

## Deployment
- Kubernetes deployment manifests for PostgreSQL and Redis are provided (`postgres-deployment.yaml`, `redis-deployment.yaml`).

## Contributing
Pull requests are welcome! For major changes, please open an issue first to discuss what you would like to change.

## License
MIT

