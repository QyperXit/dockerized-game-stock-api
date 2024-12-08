# Game Store Backend

This repository contains the backend for the Game Store application, built using .NET 9 Web API. It is designed to manage the application's game inventory and user interactions, offering a robust and scalable API. This project also supports Docker for seamless containerized deployment and integration with the frontend.

## Features

- Built with .NET 9 Web API for modern backend development
- RESTful API design for smooth interaction with the frontend
- SQLite integration for lightweight and portable database storage
- Dockerized for easy deployment and scalability
- Configurable environment settings for development and production

## Prerequisites

- **.NET 9 SDK**
- **Docker** (for containerized deployment)
- Optional: **Postman** or **cURL** for API testing

## Getting Started

### Local Development

1. Clone the repository:

   ```bash
   git clone https://github.com/QyperXit/dockerized-game-stock-api.git
   cd dockerized-game-store-api

2. **Build the Docker image:**

   Ensure Docker is running, then build the image with the following command:

   ```bash
   docker build -t gamestore-backend .

   ```

23 **Run the Docker container:**

   Use the following command to run the Docker container:

   ```bash
   docker run -p 5000:5000 gamestore-backend

   ```

   The application will be accessible at [http://localhost:5000](http://localhost:5000).
