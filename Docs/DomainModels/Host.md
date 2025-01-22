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
    "id": "00000000-0000-0000-0000-000000000000",
    "userId": "00000000-0000-0000-0000-000000000000",
    "menuIds": ["00000000-0000-0000-0000-000000000000"],
    "dinnerIds": ["00000000-0000-0000-0000-000000000000"],
    "createdOn": "",
    "createdBy": "",
    "modifiedOn": "",
    "modifiedBy": ""
}
```