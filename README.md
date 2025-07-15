# Online Course Management System (CRUD)

This is a simple ASP.NET Core MVC CRUD application for managing online courses. It demonstrates key concepts of layered architecture, ADO.NET-based database access, service/repository pattern, and Razor views.

---

## 📚 Features

- Add new courses
- View a list of all courses
- Edit existing course details
- View course details
- Delete a course
- DateTime handling with `CreatedDate` field
- Clean separation of concerns using Service and Repository layers
- ADO.NET used instead of Entity Framework

---

## 🛠️ Tech Stack

- ASP.NET Core MVC
- Razor Views
- C# (.NET 6 or 7)
- ADO.NET (with `SqlClient`)
- SQL Server (Local DB)
- Bootstrap (Basic Styling)
- Dependency Injection
- Layered Architecture

---

## 📂 Project Structure

CrudOp/
│
├── Controllers/
│ └── CourseController.cs
│
├── Models/
│ └── Course.cs
│
├── Services/
│ ├── ICourseService.cs
│ └── CourseService.cs
│
├── DataAccessLayer/
│ ├── ICourseRepository.cs
│ └── CourseRepository.cs
│
├── Views/
│ └── Course/
│ ├── Index.cshtml
│ ├── Create.cshtml
│ ├── Edit.cshtml
│ ├── Delete.cshtml
│ └── Details.cshtml
│
├── appsettings.json
└── Program.cs

