# Domain Models

## Dinner

```csharp
class Dinner
{
    Dinner Create();
    void StartDinner(Guid dinnerId);
    void EndDinner(Guid dinnerId);
    List<Reservation> GetReservations(Guid dinnerId);
}
```

```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "hostId": "00000000-0000-0000-0000-000000000000",
    "menuId": "00000000-0000-0000-0000-000000000000",
    "name": "Dinner Name",
    "description": "Some Description",
    "reservations": [
        {
            "dinnerId": "00000000-0000-0000-0000-000000000000",
            "guestId": "00000000-0000-0000-0000-000000000000",
            "billId": "00000000-0000-0000-0000-000000000000",
            "checkedIn": true
        }
    ],
    "status": "In-Progress",
    "createdOn": "",
    "createdBy": "",
    "modifiedOn": "",
    "modifiedBy": ""
}
```