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
    "hostId": "00000000-0000-0000-0000-000000000000",
    "guestId": "00000000-0000-0000-0000-000000000000",
    "name": "Dinner Name",
    "age": 24,
    "locationDetails": {},
    "userType": 1,
    "createdOn": "",
    "createdBy": "",
    "modifiedOn": "",
    "modifiedBy": ""
}
```