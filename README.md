
# Blazor JWT Authentication 🔐

This project demonstrates how to implement **JWT (JSON Web Token) Authentication** in a **Blazor** application. It serves as a guide for integrating secure authentication mechanisms in Blazor, using JWT to handle user authentication and authorization.

## Features
- 🔒 **JWT-based authentication** for securing API endpoints.
- 👤 **Login and user authentication** with token generation.
- 🔐 **Token storage** and validation using local storage.
- ⚡ **Secure API calls** using the generated JWT for authorization.
- 🧩 **Blazor WebAssembly** as the front-end framework.

## Tech Stack
- **Blazor WebAssembly** for the client-side.
- **ASP.NET Core** for the backend.
- **JWT (JSON Web Tokens)** for authentication and authorization.
- **Entity Framework Core** for database operations.

## Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/MarvynHarry/Blazor-JTW-Auth.git
   ```

2. Navigate to the project folder:
   ```bash
   cd Blazor-JWT-Auth
   ```

3. Restore dependencies:
   ```bash
   dotnet restore
   ```

4. Update the `appsettings.json` file with your database connection and JWT secret:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "YourDatabaseConnectionString"
     },
     "JwtSettings": {
       "SecretKey": "YourSuperSecretKey"
     }
   }
   ```

5. Run the project:
   ```bash
   dotnet run
   ```

## Usage

- **Sign up** for a new user account.
- **Log in** to receive a JWT token.
- Use the token to access secure endpoints by passing it in the Authorization header.

### Sample Authorization Header
```http
Authorization: Bearer your-jwt-token-here
```

## Project Structure

- **/Client**: Blazor WebAssembly front-end.
- **/Server**: ASP.NET Core Web API for authentication and data processing.
- **/Shared**: Shared models and classes between the client and server.

## Support My Work
If you enjoy my work or want to support what I do, feel free to [Buy Me a Coffee](https://buymeacoffee.com/marvynharry)!

## Contributing
Feel free to submit a pull request or report issues to help improve the project!

## License
This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Contact
For any questions or support, please reach out via [GitHub Issues](https://github.com/MarvynHarry/Blazor-JTW-Auth/issues).
