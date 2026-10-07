# InventoryHub
> A streamlined, full-stack inventory management system demonstrating seamless frontend-backend integration.

![Build Status](https://img.shields.io/badge/build-passing-brightgreen)
![.NET Version](https://img.shields.io/badge/.NET-8.0-blue)
![React Version](https://img.shields.io/badge/React-18-blue)
![License](https://img.shields.io/badge/license-MIT-green)

## Features
* **Full CRUD Operations**: Create, read, update, and delete product inventory records.
* **Intelligent Search & Filtering**: Quickly find products by name, category, or SKU.
* **Dashboard Analytics**: View total products, inventory value, and category breakdowns at a glance.
* **Low-Stock Detection**: Automatic visual warnings for items running low or out of stock.
* **Optimized API Integration**: Built with RESTful principles, structured JSON responses, and Entity Framework Core `AsNoTracking` for fast reads.

## Prerequisites & Installation

### Prerequisites
* [Node.js](https://nodejs.org/) (v18 or higher)
* [.NET 8.0 SDK](https://dotnet.microsoft.com/)

### Installation

1. **Clone the repository**
   ```bash
   git clone <your-repo-url>
   cd "InventoryHub - Full-Stack Inventory Management System"
   ```

2. **Start the Backend API**
   ```bash
   cd backend
   dotnet restore
   dotnet build
   dotnet run
   ```
   *The API will start on `http://localhost:5000` (or the port specified in your console).*

3. **Start the Frontend Application**
   Open a new terminal window and navigate to the project root.
   ```bash
   cd frontend
   npm install
   npm run dev
   ```
   *The application will launch on `http://localhost:5173`.*

## Usage

Navigate to `http://localhost:5173` in your browser. From the dashboard, you can click **Add Product** to create new inventory items, or use the search bar to filter the existing seeded products.

**Sample API Request (GET Products):**
```bash
curl -X GET "http://localhost:5000/api/products?page=1&pageSize=10" -H "accept: text/plain"
```

## Configuration / Environment Variables

Currently, the application runs entirely locally using an In-Memory SQLite Database and zero-configuration defaults.

If you wish to configure CORS or logging differently, adjust the backend configuration file:
* `backend/appsettings.json`

## Contributing

1. Fork the project.
2. Create your feature branch (`git checkout -b feature/AmazingFeature`).
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`).
4. Push to the branch (`git push origin feature/AmazingFeature`).
5. Open a Pull Request.

## License

Distributed under the MIT License. See `LICENSE` for more information.
