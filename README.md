# FarmConnect Admin Panel

> A powerful, secure, and modern administration dashboard for the FarmConnect ecosystem, built with **ASP.NET Core MVC**.

![FarmConnect Banner](https://placehold.co/1200x400?text=FarmConnect+Admin+Panel)

## 📖 Overview

**FarmConnect Admin** is the central control hub for managing the FarmConnect platform. It empowers administrators to oversee user accounts, manage product inventory, and monitor system health through an intuitive and secure interface.

Built with performance and scalability in mind using **.NET 8** and **Entity Framework Core**.

## ✨ Key Features

- **🔐 Secure Authentication**: Robust session-based login system with hashed password security (BCrypt).
- **📊 Dynamic Dashboard**: Real-time overview of system metrics (Total Users, Product Inventory).
- **📦 Product Management (CRUD)**:
  - Add, Edit, and Delete products.
  - Track stock levels (`Quantity`), prices, and units (kg, g, etc.).
  - Automatic timestamps (`CreatedAt`, `UpdatedAt`).
- **👥 User Administration**:
  - View registered users.
  - Manage user roles and details.
  - Duplicate email prevention.
- **🛡️ Role-Based Access**: Protected routes ensuring only authorized admins can access sensitive data.

## 🛠️ Tech Stack

- **Framework**: [ASP.NET Core 8.0 MVC](https://dotnet.microsoft.com/apps/aspnet/mvc)
- **Database**: SQL Server / LocalDB
- **ORM**: [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
- **Frontend**: Razor Views, Bootstrap 5, Custom CSS
- **Security**: `System.Security.Cryptography` for hashing

## 🚀 Getting Started

Follow these steps to set up the project locally.

### Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server Express](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or LocalDB
- Visual Studio 2022 or VS Code

### Installation

1.  **Clone the Repository**

    ```bash
    git clone https://github.com/yourusername/FarmConnect.git
    cd FarmConnect
    ```

2.  **Configure Database**
    Update the connection string in `appsettings.json` if needed (defaults to LocalDB):

    ```json
    "ConnectionStrings": {
      "DefaultConnection": "Server=.;Database=FarmConnectDB;Trusted_Connection=True;TrustServerCertificate=True;"
    }
    ```

3.  **Apply Migrations & Seed Data**
    The application will automatically seed a default admin user on startup if one doesn't exist.

    ```bash
    dotnet ef database update
    ```

    _Alternatively, just run the app and let the `DbSeeder` handle it._

4.  **Run the Application**

    ```bash
    dotnet run --project FarmConnectAdmin
    ```

5.  **Login**
    Access the admin panel at `https://localhost:7045` (or your local port).
    - **Username**: `admin`
    - **Password**: `admin123`

## 📂 Project Structure

```
FarmConnectAdmin/
├── Controllers/       # Core business logic (Auth, Home, Product, User)
├── Models/            # Data entities (Admin, User, Product)
├── Views/             # UI Pages (Razor templates)
├── Data/              # DbContext and Seeder
├── wwwroot/           # Static assets (CSS, JS, Images)
└── Program.cs         # App configuration and middleware
```

## 🤝 Contributing

Contributions are welcome! Please fork the repository and submit a pull request for any enhancements.

1.  Fork the Project
2.  Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3.  Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4.  Push to the Branch (`git push origin feature/AmazingFeature`)
5.  Open a Pull Request

## 📄 License

Distributed under the MIT License. See `LICENSE` for more information.
