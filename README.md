# SmartTask API 

A secure and modern RESTful Task Management API built with **ASP.NET Core**, **Entity Framework Core**, and **JWT authentication**.

---

## 🔧 Features

- Full CRUD operations (Create, Read, Update, Delete) for task management
-  Clean architecture using **DTOs**, **AutoMapper**, and dependency injection
-  **JWT-based user authentication** with token generation and protected routes
-  Interactive API documentation via **Swagger**
-  Query filtering (e.g., `/api/tasks?isComplete=true`)
-  Powered by lightweight **SQLite** database

---

##  Tech Stack

- **Backend**: ASP.NET Core (.NET 8)
- **Database**: SQLite with Entity Framework Core
- **Authentication**: JWT (JSON Web Token)
- **Object Mapping**: AutoMapper
- **Documentation**: Swagger / OpenAPI

---

##  Getting Started

### 1. Clone the repository
git clone https://github.com/MesumAbbas51214/smart-task-api.git


### 2. Restore dependencies
dotnet restore
cd smart-task-api


### 3. Apply the database migration
dotnet ef database update
(If EF is not installed: dotnet tool install --global dotnet-ef)

### 4. Run the project
dotnet run


**Then open:**
 https://localhost:{port}/swagger
or
 http://localhost:{port}/swagger


### **JWT Login Credentials**
Use this to generate a token via POST /api/auth/login:
{
  "username": "admin",
  "password": "password123"
}
Copy the token and click  Authorize in Swagger UI to access protected endpoints.

### **Project Structure**
/Controllers        → API endpoints
/Models             → Database models
/DTOs               → Data Transfer Objects
/Data               → DbContext
/Mappings           → AutoMapper profiles


### **Future Improvements**
Connect a React frontend
Add user registration and role-based auth
Add pagination and sorting
Deploy to Azure / Render


### **📬 Contact**
Mesum Abbas
https://www.linkedin.com/in/mesum-abbas-aa38a519a/
https://github.com/MesumAbbas51214



---

###  How to Use

1. Save this content in your project root as `README.md`
2. Git add, commit, and push:

```bash
git add README.md
git commit -m "Add professional README"
git push

