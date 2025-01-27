# Domain Models

## User

```csharp
class User
{
    User Create(User user);
    void Update(User user);
    void Delete(User user);
}
```

```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "firstName": "Tiffany",
    "lastName": "Doe",
    "email": "user@gmail.com",
    "password": "Amiko1232!",
    "createdOn": "2020-01-01T00:00:00.0000000Z",
    "modifiedOn": "2020-01-01T00:00:00.0000000Z"
}
```