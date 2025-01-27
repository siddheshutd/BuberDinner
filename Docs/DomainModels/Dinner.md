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
            "id": "00000000-0000-0000-0000-000000000000",
            "guestId": "00000000-0000-0000-0000-000000000000",
            "billId": "00000000-0000-0000-0000-000000000000",
            "checkedIn": true,
            "guestCount": 2,
            "arrivalDateTime": null,
            "createdDateTime": "2020-01-01T00:00:00.0000000Z",
            "updatedDateTime": "2020-01-01T00:00:00.0000000Z"
        }
    ],
    "status": "In-Progress",
    "startDateTime": "2020-01-01T00:00:00.0000000Z",
    "endDateTime": "2020-01-01T00:00:00.0000000Z",
    "startedDateTime": null,
    "endedDateTime": null,
    "isPublic": true,
    "maxGuests": 10,
    "price": {
        "amount": 10.99,
        "currency": "USD"
    },
    "createdOn": "2020-01-01T00:00:00.0000000Z",
    "modifiedOn": "2020-01-01T00:00:00.0000000Z"
}
```