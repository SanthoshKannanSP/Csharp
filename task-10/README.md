# Task-10 - Building a Mini Microservice with ASP.NET Core

## Objective
- Create a small RESTful API that manages a resource (e.g., Products, Orders, or Books) using ASP.NET Core.

## Requirements
- **Project Setup**
  - Set up a new ASP.NET Core Web API project
  - Configure routing and controllers
- **Dependency Injection**
  - Implement a service layer and register services using ASP.NET Core’s dependency injection.
- **Data Access**
  - Use Entity Framework Core with an in-memory database (or SQLite) to perform CRUD operations
- **Asynchronous Operations**
  - Use async/await in your controller actions to handle database operations
- **Error Handling and Logging**
  - Implement middleware or filters for global exception handling.
  - Integrate basic logging to record actions and errors.
- **Testing and Documentation**
  - Write unit tests for your controllers and services.
  - Document the API endpoints (using tools like Swagger).
- **Advanced Considerations (Optional)**
  - Incorporate design patterns such as Repository and Unit of Work.
  - Implement custom middleware for request/response logging or authentication.

## Dependencies
- Microsoft.EntityFrameworkCore.InMemory  
- Swashbuckle.AspNetCore


## To Run Program
```
dotnet run
```

## Swagger UI
```
http://localhost:5093/swagger/index.html
```

## API Endpoints Documentation
[api-doc.json](api-doc.json)

## References
- https://www.youtube.com/watch?v=H3EbflpXVmo
- https://www.youtube.com/watch?v=6YIRKBsRWVI
- https://www.youtube.com/watch?v=RgoytbbYbr8
- https://www.youtube.com/watch?v=GMYCNfDXQIk
- https://www.youtube.com/watch?v=3BsESpxSzzw
- https://www.youtube.com/watch?v=GZY7M4v-d68