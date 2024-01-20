# Application

Dotnet WebApi Application is an HR Management System designed to streamline human resources processes.

## Getting Started

These instructions will help you set up and run the WebApi Application on your local machine.

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) installed
- [Visual Studio Code](https://code.visualstudio.com/) or [Visual Studio](https://visualstudio.microsoft.com/) (optional)

### Installing

1. Clone the repository:

   ```bash
   git clone https://github.com/sirajsalaya/dotnet_webapi.git
   cd dotnet_webapi
   ```

2. Build and run the project:

   ```bash
   dotnet build
   dotnet run --project Dotnet
   ```

   The WebApi Application will be accessible at `https://localhost:5001`.

## Project Structure

The Dotnet WebApi Application is organized into the following components:

- `/Dotnet.WebApi`: Main WebApi Application project.
- `/Dotnet.Business`: Class library for business logic.
- `/Dotnet.Data`: Class library for data access.
- `/Dotnet.Services`: Class library for services.
- `/Dotnet.Utilities`: Class library for utilities.
- `/DTOs`: Data Transfer Objects.

## WebApi API Endpoints

List and briefly describe the API endpoints available in Dotnet WebApi Application.

- `/api/employees`: Get a list of all employees.
- `/api/employees/{id}`: Get details of a specific employee.
- `/api/leave-requests`: Submit and manage leave requests.
- ...

## Dependencies

Dotnet WebApi Application uses various dependencies to enhance functionality:

- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
- [AutoMapper](https://automapper.org/)
- ...

## Configuration

Adjust configuration settings in `appsettings.<EnvironmentName>.json` for customizing Dotnet WebApi Application to your specific needs.
