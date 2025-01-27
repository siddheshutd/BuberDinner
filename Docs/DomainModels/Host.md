# Domain Models

## Host

```csharp
class Host
{
    void AddDinner(Guid dinnerId);
    void AddMenu(Guid menuId);
    void RemoveMenu(Guid menuId);
}
```

```json
{
    "id": { "value": "00000000-0000-0000-0000-000000000000" },
    "firstName": "Tiffany",
    "lastName": "Doe",
    "profileImage": "https://www.gravatar.com/avatar/00000000000000000000000000000000?d=mp",
    "averageRating": 4.5,
    "userId": { "value": "00000000-0000-0000-0000-000000000000" },
    "menuIds": [
        { "value": "00000000-0000-0000-0000-000000000000" }
    ],
    "dinnerIds": [
        { "value": "00000000-0000-0000-0000-000000000000" }
    ],
    "createdOn": "2020-01-01T00:00:00.0000000Z",
    "modifiedOn": "2020-01-01T00:00:00.0000000Z"
}
```