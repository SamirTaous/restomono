## 🍽️ RestoMono - Restaurant Management App

RestoMono is a modern, cross-platform restaurant management application built using **.NET MAUI**. Designed for both learning and prototyping, it provides a full suite of features for managing dishes, orders, reservations, users, and admin statistics.

---

### ✨ Features

- 📋 **Menu Display** – View and paginate through a grid of available dishes.
- 🛒 **Order Cart** – Add/remove items, adjust quantities, and view totals.
- 💳 **Simulated Payment** – Validate orders based on user wallet balance.
- 👤 **User Login System** – Login with wallet tracking and profile viewing.
- 🔐 **Admin Login Mode** – Access a dashboard for statistics and full CRUD.
- 📊 **Statistics Page** – View total dishes and clients with management tools.
- 🧾 **SQLite Integration** – Local database to persist users and dishes.
- 💡 **MVVM Architecture** – Clean separation of UI, logic, and data.

---

### 🚀 Technologies Used

- [.NET MAUI](https://learn.microsoft.com/en-us/dotnet/maui/) – Cross-platform UI
- SQLite + Entity Framework Core – Local database management
- CommunityToolkit.MVVM – Lightweight MVVM binding
- CommunityToolkit.Maui – For popups, toasts, and visuals

---

### 📂 Project Structure

```
restomono/
│
├── Models/           # Data models (Plat, User, CartItem)
├── ViewModels/       # MVVM ViewModels for each page
├── Views/            # UI Pages (Menu, CartPopup, Payment, etc.)
├── Services/         # DatabaseService, AuthService
├── Resources/        # Styles, images, etc.
├── App.xaml.cs       # App lifecycle and initialization
├── AppShell.xaml     # Shell routing and structure
└── restomono.csproj  # Project definition
```

---

### 🧪 Sample Test Users

| Name     | Wallet |
|----------|--------|
| `admin`  | `1000` |
| `user1`  | `200`  |
| `client` | `500`  |

---

### 🛠️ How to Run

1. Clone the repo:
   ```bash
   git clone https://github.com/SamirTaous/restomono.git
   cd restomono
   ```

2. Open in **Visual Studio 2022+** with .NET MAUI workload installed

3. Build and run the app on:
   - Windows

4. On first run, sample dishes and users will be seeded into the SQLite database.

---
