# Weather Application

## Overview
This Weather Application allows users to fetch current weather data for various cities using a Weather API. The application is built using C# and provides full CRUD (Create, Read, Update, Delete) operations for managing weather-related data in a PostgreSQL database. API testing and documentation are done using Postman.

## Features
- **Fetch Weather Data**: Retrieve current weather information from the Weather API.
- **CRUD Operations**: Manage weather data (Create, Read, Update, Delete) stored in a PostgreSQL database.
- **API Testing with Postman**: Use Postman to test API endpoints.

## Technologies Used
- **C# (.NET Core)**: Backend development.
- **PostgreSQL**: Database for storing weather data.
- **Postman**: API testing and documentation.
- **Weather API**: External API to fetch real-time weather data.

## Prerequisites
Before running this project, ensure you have the following installed:
- [.NET Core SDK](https://dotnet.microsoft.com/download)
- [PostgreSQL](https://www.postgresql.org/download/)
- [Postman](https://www.postman.com/downloads/)
- Weather API Key (e.g., from [OpenWeatherMap](https://openweathermap.org/))

## Getting Started

### 1. Clone the Repository
```bash
git clone https://github.com/your-username/weather-application.git
cd weather-application
2. Configure PostgreSQL Database
Create a PostgreSQL database and configure the connection string in the appsettings.json file:

json
Copy code
"ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=WeatherDB;Username=postgres;Password=yourpassword"
}
Run migrations (if applicable) to set up the database schema.

3. Get Your Weather API Key
Sign up at OpenWeatherMap or any other weather data provider to get an API key. In appsettings.json, add your API key:

json
Copy code
"WeatherApi": {
    "BaseUrl": "https://api.openweathermap.org/data/2.5/",
    "ApiKey": "your-api-key-here"
}
4. Build and Run the Project
bash
Copy code
dotnet build
dotnet run
The application will be available at https://localhost:5001/.

API Endpoints
1. Fetch Current Weather from External API
GET /api/weather/{city}
Fetch current weather data for the given city from the external Weather API.
Example Request:
http
Copy code
GET /api/weather/London
2. Create Weather Data (Manual Entry)
POST /api/weather
Store weather data in the PostgreSQL database.
Request Body Example:
json
Copy code
{
    "city": "London",
    "temperature": 15.5,
    "humidity": 80,
    "description": "Cloudy"
}
3. Read All Stored Weather Data
GET /api/weather
Retrieve all stored weather data from the PostgreSQL database.
4. Update Weather Data
PUT /api/weather/{id}
Update weather data entry for a specific ID.
Request Body Example:
json
Copy code
{
    "city": "New York",
    "temperature": 20.3,
    "humidity": 65,
    "description": "Sunny"
}
5. Delete Weather Data
DELETE /api/weather/{id}
Remove a specific weather data entry from the database.
Postman Collection
You can test these APIs using Postman by importing the following Postman collection:

Open Postman.
Import the Weather Application Postman Collection.
Test all endpoints with predefined requests.
Database Schema
The database schema for the weather data is as follows:

sql
Copy code
CREATE TABLE WeatherData (
    Id SERIAL PRIMARY KEY,
    City VARCHAR(100) NOT NULL,
    Temperature DECIMAL(5, 2),
    Humidity INT,
    Description VARCHAR(255),
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);
Running Unit Tests
To run the unit tests (if any are included), use the following command:

bash
Copy code
dotnet test
Contributing
If you'd like to contribute to this project, feel free to submit a pull request. Please ensure all tests pass and the code is properly documented.

License
This project is licensed under the MIT License. See the LICENSE file for details.

Author
Mohammed Naseek
GitHub
