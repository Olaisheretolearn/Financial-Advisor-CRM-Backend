# Financial Advisor CRM Backend

## Overview

The Financial Advisor CRM Backend is an ASP.NET Core Web API application that simulates an internal Customer Relationship Management (CRM) system used by a financial advisory firm.  

The system is designed to model enterprise-grade backend architecture with a focus on relational domain modeling, audit logging, concurrency control, and role-based system structure.

This project is intended to demonstrate backend engineering practices aligned with financial services environments.

---

## Purpose

This application was built to:

- Model a financial advisory CRM domain
- Demonstrate layered backend architecture
- Implement audit logging for regulatory traceability
- Apply optimistic concurrency control
- Enforce normalized relational database design
- Prepare for future external CRM system integration

The system emphasizes backend structure and maintainability rather than front-end implementation.

---

## Core Features

### User & Role Management
- Create and manage users (Admin, Advisor, Compliance roles)
- Role-based domain modeling
- Future support for authorization policies

### Client Management
- Assign clients to advisors
- Track risk tolerance and KYC completion
- Support optimistic concurrency via version control
- Maintain normalized client address records

### Interaction Logging (Notes)
- Record advisor-client interactions
- Categorize interactions (Call, Meeting, Email)
- Track which user created each note

### Document Management
- Store client document metadata
- Associate documents with clients
- Track uploader identity
- Implement soft delete pattern

### Audit Logging
- Track entity-level changes (Client, Note, Document, etc.)
- Store old and new values as serialized JSON
- Record user responsible for change
- Timestamp all modifications

---

## Planned API Endpoints

### Users
- GET /api/users
- GET /api/users/{id}
- POST /api/users
- PUT /api/users/{id}
- DELETE /api/users/{id}

### Clients
- GET /api/clients
- GET /api/clients/{id}
- GET /api/clients/by-advisor/{advisorId}
- POST /api/clients
- PUT /api/clients/{id}
- DELETE /api/clients/{id}

### Notes
- GET /api/clients/{clientId}/notes
- POST /api/clients/{clientId}/notes
- DELETE /api/notes/{id}

### Documents
- GET /api/clients/{clientId}/documents
- POST /api/clients/{clientId}/documents
- DELETE /api/documents/{id} (soft delete)

### Audit Logs
- GET /api/auditlogs
- GET /api/auditlogs/entity/{entityName}/{entityId}

---

## Architecture

The application follows a layered architecture:

- Controllers (API layer)
- Services (business logic layer)
- Repositories (data access layer)
- Entity Framework Core (ORM)
- Relational database (planned SQL Server)

### Cross-Cutting Concerns

- Audit logging
- Optimistic concurrency handling
- Soft delete implementation
- Role-based access design (planned)
- JWT authentication (planned)

---

## Technology Stack

- ASP.NET Core Web API
- C#
- Entity Framework Core (planned)
- SQL Server (planned)
- JWT Authentication (planned)
- Azure Blob Storage integration (planned)
- Background job processing for external CRM sync (planned)

---

## Future Enhancements

- External CRM synchronization service
- Azure deployment configuration
- Background processing for retry logic
- API versioning
- Caching layer
- Enhanced authorization policies

---

## Running the Application

```bash
dotnet restore
dotnet run
