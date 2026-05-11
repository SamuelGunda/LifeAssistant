---
name: auth
description: JWT authentication, ASP.NET Identity, Auth0, authorization policies, claims-based auth
---

# Authentication & Authorization Skill

Use this skill for:
- JWT auth
- Auth0
- ASP.NET Identity
- Policies
- Claims authorization

## Preferred Patterns

- Claims-based authorization
- Policy-based authorization
- Short-lived access tokens
- Refresh token flows
- Secure secret handling

## Security Rules

- Never store plaintext secrets
- Never log tokens
- Validate issuer/audience/signature
- Use HTTPS everywhere

## Avoid

- Custom crypto
- Long-lived JWTs
- Role checks scattered everywhere
- Hardcoded secrets