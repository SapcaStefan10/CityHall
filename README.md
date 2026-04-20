# City Hall Management System (CHMS)

The **City Hall Management System (CHMS)** is a professional, web-based client-server application designed to modernize administrative activities within a city hall. It facilitates efficient management of documents, organizational departments, citizen communication, and hearing schedules.

## Key Features
- **User Account Management**: Secure registration, authentication, and role-based access control (Citizen, Employee, Admin).
- **Citizen Request Management**: Submission, tracking, and processing of official requests.
- **Organizational Structure**: Dynamic management of departments and public officials.
- **Document Management**: Centralized repository for uploading, searching, and archiving official documents.
- **Hearings & Communication**: Scheduling of online hearings and real-time chat sessions.
- **Notifications & Monitoring**: Dashboard statistics, system announcements, and automated email alerts.

## Technology Stack
- **Backend**: ASP.NET Core MVC (Optimized for performance and security).
- **Frontend**: Vanilla HTML5, CSS3 (Premium Design System), and ES6+ JavaScript.
- **Database**: MySQL (Version 8.0 compatible schema).
- **Security**: Password hashing, JWT/Session-based authentication, and HTTPS focus.

## Getting Started
1. Execute the `Database/db_schema.sql` on your MySQL server.
2. Update the `appsettings.json` with your MySQL connection string.
3. Run the application using `dotnet run`.
4. Access the dashboard at `https://localhost:5001`.

## Documentation
- [SRS Document](SRS.md)
- [Implementation Plan](implementation_plan.md)
