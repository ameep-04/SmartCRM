# SmartCRM

A simple and clean CRM system built with ASP.NET Core MVC. Perfect for small businesses or teams that need an easy way to manage customers, leads, and sales without the complexity of enterprise tools.

## What It Does

- **Dashboard** – Get a quick look at what's happening with your leads and sales
- **Customers** – Keep track of everyone you're working with
- **Leads** – Follow your prospects through the pipeline
- **Follow-ups** – Never miss a call or meeting again
- **Sales** – Log deals and see how things are going
- **Login** – Secure access for your team

## How It's Built

- ASP.NET Core 8.0 (MVC)
- SQL Server + Entity Framework Core
- Bootstrap 5 for styling
- jQuery Validation

## Getting Started

1. Update your connection string in `appsettings.json`:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=YOUR_SERVER;Database=SmartCRM;Trusted_Connection=True;TrustServerCertificate=True"
   }
   ```

2. Run the database migrations:
   ```bash
   dotnet ef database update
   ```

3. Start the app:
   ```bash
   dotnet run
   ```

4. Login with:
   - Username: `admin`
   - Password: `admin123`

## Structure

```
SmartCRM/
├── Controllers/      # Request handling
├── Models/            # Database tables
├── Views/             # UI pages
├── Data/              # DbContext setup
├── Migrations/        # DB changes over time
└── wwwroot/          # CSS, JS, images
```

## Questions?

Feel free to open an issue if you run into problems or want to add something new.

## License

MIT
