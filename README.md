# Projex HR Desk Application

Projex HR Desk Application is an HR Management System designed to streamline human resources processes.

## Getting Started

These instructions will help you set up and run the HR Desk Application on your local machine.

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) installed
- [Visual Studio Code](https://code.visualstudio.com/) or [Visual Studio](https://visualstudio.microsoft.com/) (optional)

### Installing

1. Clone the repository:

    ```bash
    git clone https://github.com/your-username/projex-hr.git
    cd projex-hr
    ```

2. Build and run the project:

    ```bash
    dotnet build
    dotnet run --project Dotnet
    ```

    The HR Desk Application will be accessible at `https://localhost:5001`.

## Project Structure

The Projex HR Desk Application is organized into the following components:

- `/Dotnet`: Main HR Desk Application project.
- `/Dotnet.BusinessLogic`: Class library for HR business logic.
- `/Dotnet.DataAccess`: Class library for data access.
- `/Dotnet.Services`: Class library for HR services.
- `/Dotnet.Utilities`: Class library for utilities.
- `/DTOs`: Data Transfer Objects.

## HR Desk API Endpoints

List and briefly describe the API endpoints available in Projex HR Desk Application.

- `/api/employees`: Get a list of all employees.
- `/api/employees/{id}`: Get details of a specific employee.
- `/api/leave-requests`: Submit and manage leave requests.
- ...

## Dependencies

Projex HR Desk Application uses various dependencies to enhance functionality:

- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
- [AutoMapper](https://automapper.org/)
- ...

## Configuration

Adjust configuration settings in `appsettings.<EnvironmentName>.json` for customizing Projex HR Desk Application to your specific needs.
