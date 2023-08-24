# Restaurant-Management
Welcome to the Restaurant Management System repository based on the Clean Architecture. This project aims to provide a comprehensive solution for managing various aspects of restaurant operations.

## About the Project
The Restaurant Management System is designed using the principles of Clean Architecture, which emphasizes separation of concerns, maintainability, and scalability. The architecture is divided into distinct layers, each with a specific responsibility:

Presentation Layer: This layer includes the user interface components, such as the web application or mobile app. It interacts with the Application layer to provide a user-friendly interface for restaurant staff and customers, I'll be using ASP.NET Core Web API as presentation Layer In this case but since we are working using Clean Architecture we could add UI like Angular and it will work just perfect.

Application Layer: The Application layer contains the use cases and business logic. It orchestrates the interactions between the Presentation and Domain layers, ensuring that business rules are followed and use cases are executed.

Domain Layer: The heart of the system, the Domain layer, encapsulates the core business logic and entities. It defines the fundamental concepts of the restaurant domain, such as menus, orders, reservations, and staff roles.

Infrastructure Layer: The Infrastructure layer deals with external concerns, such as database access, API integrations, and external services. It supports the higher layers without being tied to specific implementation details.

## Technologies Used

ASP.NET Core: Powering the backend application and API endpoints.

Entity Framework Core: For database interactions and data modeling.

Swagger: Generating API documentation for easy integration.
