---
name: aspnet-api
description: ASP.NET Core Web API endpoints, controllers, minimal APIs, middleware, validation, ProblemDetails, OpenAPI
---

# ASP.NET Core API Skill

Use this skill for:
- API endpoint creation
- Controllers
- Minimal APIs
- Middleware
- Validation
- REST API design
- OpenAPI

## Preferred Patterns

- Thin controllers
- DTO-based contracts
- ProblemDetails for errors
- FluentValidation for validation
- CancellationToken everywhere
- Typed responses
- Versioned APIs for public contracts

## Preferred Stack

- ASP.NET Core 10+
- FluentValidation
- Carter or Controllers
- OpenAPI

## DTO Mapping

- Prefer explicit mapping methods over AutoMapper unless mapping complexity is substantial.

## Versioning

- Prefer API versioning over route versioning.

## Error Handling

- Prefer ProblemDetails for error responses.
- Make use of Global Error Handling.

## Avoid

- Business logic inside controllers
- Returning entities directly
- Large controllers
- Manual model validation duplication
- Catch(Exception) in endpoints