---
name: testing
description: xUnit, integration tests, API testing, mocking, SQLite, Testcontainers, ASP.NET Core testing
---

# Testing Skill

Use this skill for:
- Unit tests
- Integration tests
- API tests
- Test infrastructure

## Preferred Testing Style

- Prefer integration tests for APIs
- Use real databases where possible
- Use SQLite or Testcontainers
- Mock only external systems

## Preferred Libraries

- xUnit
- AwesomeAssertions
- Moq
- WebApplicationFactory

## Integration Test Pattern

```csharp
await using var app = new TestApplicationFactory();

var client = app.CreateClient();

var response = await client.PostAsJsonAsync(
    "/api/users",
    request);

response.StatusCode.Should().Be(HttpStatusCode.Created);
```

## Avoid

- Manual test setup
- Hardcoded secrets
- Manual test teardown
- Testing implementation details
- Massive fixture setup
- Overmocking