# Placely

This is a site for renting or publishing places. On this site you can:

- **Rent a place**. You can rent a place for a certain period of time.
- **Publish a place**. You can publish a place for rent.
- **Chat with anyone**. You can chat with the someone on the site.
- **Authorize via other service**. You can register or login with an account on other service.
- **Create a contract**. After conversation with landlord, you can generate contract online.

Link to [YouTrack project](https://coldezzt.youtrack.cloud/projects/1364d4b4-ae99-4362-bee6-10367b046493).

## How to run project?

After cloning repository, you need to run two projects. Order is not important.

**The backend** can be started using the following commands:

```bash
cd Placely.Backend/Placely.Main
dotnet run
```

**The frontend** is not available for now.

## Backend

**Architecture**: MVC with React instead of View.

**Architecture style**: Monolith.

**Stack and technologies**:

- ASP.NET
- Entity Framework Core
- JWT
- Hangfire
- SignalR
- Serilog
- SwaggerUI
- FluentValidation
- PostgreSQL

## Frontend (in progress)

**Architecture**: Component approach.

**Stack and technologies**:

- React.js
- Redux
- Webpack
- Babel
- SCSS
- ESLint
