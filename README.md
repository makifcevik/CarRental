# CAR RENTAL
Click [here](https://github.com/makifcevik/car-rental-angular) to see the front-end implementation of the application.

## Overview
Car Rental is a comprehensive back-end application designed to manage the operations of a car rental business.

## Technologies Implemented

1. **Enterprise Layered Architecture**:
    - The application is organized into multiple layers: Business, Core, DataAccess, Entities, and WebAPI, each serving a distinct purpose to maintain separation of concerns and scalability.

2. **Entity Framework**:
    - An Object-Relational Mapping (ORM) framework that simplifies data access by allowing developers to work with a database using .NET objects.

3. **Autofac**:
    - A powerful Inversion of Control (IoC) container for dependency injection, enabling better management of dependencies. It supports Aspect-Oriented Programming (AOP) techniques like validation, caching and performance. Additionally, Autofac facilitates the use of design patterns like Singleton, ensuring that a class has only one instance throughout the application's lifecycle.

4. **Fluent Validation**:
    - A library for building strongly-typed validation rules for business objects, ensuring data integrity and consistency.

5. **SQL Server**:
    - The relational database management system (RDBMS) used to store and manage application data securely and efficiently.

6. **Authentication & Authorization**:
    - **Authentication**: Verifies user identities using credentials.
    - **Authorization**: Controls access to resources and actions based on user roles and permissions.

7. **JWT Tokens**:
    - JSON Web Tokens are used for securely transmitting information between the server and the client as a compact, URL-safe token, primarily for user authentication and session management.

8. **Caching & Performance Optimization**:
    - Implemented caching strategies to reduce database load and improve application response times, ensuring a smooth and efficient user experience.

## Usage
After running the application, you can interract with the API using tools like Postman or Swagger UI.

## API Response Structure
All API responses follow a consistent structure:
```
{
  "data": [/* The actual list of objects (data) returned by the endpoint, if any */],
  "success": true, /* A boolean indicating if the request was successful */
  "message": "Operation completed successfully" /* A message providing additional details */
}
```

## Acknowledgements
I would like thank [Mr. Engin Demiroğ](https://github.com/engindemirog) and [Kodlama.io](https://www.kodlama.io/) for their amazing course on C# .Net technologies and Angular Framework.
