# Dine

**Dine** is a recipe management and weekly meal planning application built with .NET 8 and Blazor. Users can add recipes, generate a weekly food menu, and browse recipes in a randomized feed.

## Table of Contents

- [Project Overview](#project-overview)
- [Features](#features)
- [Technologies](#technologies)
- [Setup](#setup)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
- [Configuration](#configuration)
- [Usage](#usage)
- [Project Structure](#project-structure)
- [Contributing](#contributing)
- [License](#license)

---

## Project Overview

Dine enables users to:
- Add, edit, and view recipes, with images and ingredient lists.
- Generate a randomized weekly menu.
- View a feed of randomly selected recipes.
  
Dine is designed for an interactive user experience, with dynamic loading, modals for quick recipe views, and a simple, clean interface.

## Features

- **Recipe Management**: Users can add new recipes with ingredients and instructions.
- **Weekly Meal Planner**: Users can generate a random weekly menu based on their recipes.
- **Dynamic Feed**: Infinite scroll feed of random recipes from the database.
- **Authentication**: Secure login system allowing users to manage their private recipes.

## Technologies

- **Backend**: .NET 8, Entity Framework Core
- **Frontend**: Blazor (Server-Side), CSS
- **Database**: SQL Server (configured via Entity Framework)
- **Authentication**: ASP.NET Core Identity

## Setup

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server or SQL Server LocalDB](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Node.js and npm](https://nodejs.org/) (for JavaScript package management if needed)

### Installation

1. **Clone the repository:**

   ```bash
   git clone https://github.com/yourusername/dine.git
   cd dine

2. **Set up the database:**

Open appsettings.json and configure the connection string for your SQL Server.
Default configuration example:
   ```bash
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=DineDb;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```
3. ***Run Entity Framework Migrations:***

In the project root, run the following commands to create and seed the database:
   ```bash
dotnet ef database update
 ```
4. **Install JavaScript Dependencies (optional):**

Some components may rely on JavaScript libraries (e.g., for modals or scrolling). If so, run:
 ```bash
npm install

