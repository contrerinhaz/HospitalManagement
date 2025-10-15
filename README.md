# HospitalManagement

## Table of Contents
1. Introduction  
2. Features  
3. Project Structure  
4. Technologies  
5. Installation & Setup  
6. Usage  
7. Architecture Overview  
8. Error Handling  
9. Future Improvements  
10. Contributing  
11. License  
12. Contact  

---

## 1. Introduction

**HospitalManagement** is a C# console application that simulates a simple hospital management system.  
It is designed using a layered architecture pattern (Models, Interfaces, Repositories, Services, Utils) to promote modularity and maintainability.  

The system allows users to manage patients, employees, appointments, and users through an interactive command-line interface.  
All data is stored **in memory** during runtime, which makes it suitable for learning, testing, or demonstrating object-oriented and layered design principles.

---

## 2. Features

### User Management
- Create and authenticate users.
- Assign roles or access levels.
- Update or remove users.

### Patient Management
- Register new patients.
- View, update, or delete patient records.
- Link patients to appointments or staff.

### Employee Management
- Add, update, and remove employees (doctors, nurses, administrative staff).
- Assign roles or departments.

### Appointment Management
- Schedule, modify, or cancel appointments.
- Validate employee and patient availability.
- Display appointment summaries.

### Service and Repository Layers
- Clean separation of business logic (Services) and data handling (Repositories).
- Repositories manage in-memory collections.
- Interfaces define contracts for all service and repository classes.

### Utility Components
- Input validation.
- Console formatting.
- Error handling and logging helpers.

---

## 3. Project Structure

```
HospitalManagement/
├── Data/
├── Interfaces/
├── Models/
├── Repositories/
├── Services/
├── Utils/
├── Program.cs
├── HospitalManagement.csproj
└── HospitalManagement.sln
```

| Folder / File | Description |
|----------------|-------------|
| **Data** | Contains initialization or seeding logic for in-memory data. |
| **Interfaces** | Contains interface definitions (e.g., `IRepository<T>`, `IService<T>`). |
| **Models** | Holds entity classes like `Patient`, `Employee`, `User`, `Appointment`. |
| **Repositories** | Implements CRUD operations for each model. |
| **Services** | Contains core business logic and validation rules. |
| **Utils** | Provides helper classes for logging, input validation, and formatting. |
| **Program.cs** | Entry point of the application; contains the main console menu and startup logic. |

---

## 4. Technologies

- **Language**: C#  
- **Framework**: .NET (Core or 6+)  
- **Architecture**: Layered (Interfaces, Repositories, Services, Utils)  
- **Data Storage**: In-memory collections (no external database)  
- **IDE Recommended**: Visual Studio or VS Code  

---

## 5. Installation & Setup

### Prerequisites
- [.NET SDK](https://dotnet.microsoft.com/download) (6.0 or later)
- Git (optional, for cloning)
- Visual Studio or VS Code

### Steps

1. **Clone the Repository**
   ```bash
   git clone https://github.com/contrerinhaz/HospitalManagement.git
   cd HospitalManagement
   ```

2. **Open the Project**
   Open `HospitalManagement.sln` in Visual Studio or the `.csproj` file in VS Code.

3. **Restore Dependencies**
   ```bash
   dotnet restore
   ```

4. **Build the Project**
   ```bash
   dotnet build
   ```

5. **Run the Application**
   ```bash
   dotnet run --project HospitalManagement
   ```

---

## 6. Usage

Once the application starts, it will present a text-based menu in the console.  
You can navigate using numeric or text commands to perform operations such as:

- Add or view patients  
- Register employees  
- Schedule or cancel appointments  
- Display summaries of current data  

Example interaction:
```
1. Manage Patients
2. Manage Employees
3. Manage Appointments
4. Exit
Select an option:
```

All actions take place in memory. Closing the program clears all current data.

---

## 7. Architecture Overview

The system follows a **multi-layered design**:

| Layer | Responsibility |
|-------|----------------|
| **Models** | Define the structure of domain entities. |
| **Interfaces** | Define contracts for repositories and services. |
| **Repositories** | Handle CRUD logic for entities using in-memory lists. |
| **Services** | Contain business logic and orchestrate repository operations. |
| **Utils** | Provide general-purpose functionality such as input validation and logging. |
| **Program.cs** | Entry point; manages user interaction and application flow. |

This structure supports scalability — for example, replacing in-memory repositories with database-backed ones without changing the service logic.

---

## 8. Error Handling

- All user input is validated through service and utility layers.  
- Exceptions are caught and logged via helper utilities.  
- The program displays clear error messages without crashing.  

Example:
```
Error: Patient ID not found.
Please try again.
```

---

## 9. Future Improvements

- Add persistent storage (e.g., SQL Server or SQLite).  
- Implement user authentication and roles.  
- Introduce unit testing for repositories and services.  
- Expand the appointment scheduling system with conflict detection.  
- Add configuration files for runtime settings.

---

## 10. Contributing

1. Fork the repository.  
2. Create a feature branch (`feature/your-feature-name`).  
3. Make your changes and commit them with clear messages.  
4. Submit a pull request for review.  

Follow consistent C# naming conventions and maintain code clarity.

---

## 11. License

This project is released under the [MIT License](LICENSE).  
You are free to use, modify, and distribute it with attribution.

---

## 12. Contact

**Author:** [contrerinhaz](https://github.com/contrerinhaz)  
**Repository:** [https://github.com/contrerinhaz/HospitalManagement](https://github.com/contrerinhaz/HospitalManagement)