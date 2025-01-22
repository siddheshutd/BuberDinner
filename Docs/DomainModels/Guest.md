# Domain Models

## Guest

```csharp
class Guest
{
    void AddRating(GuestRating rating);
    void AddDinner(Guid dinnerId);
    void RemoveDinner(Guid dinnerId);
    void AddBill(Guid billId);
    void RemoveBill(Guid billId);
}
```

```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "dinnerIds": ["00000000-0000-0000-0000-000000000000"],
    "billIds": ["00000000-0000-0000-0000-000000000000"],
    "menuReviewIds": ["00000000-0000-0000-0000-000000000000"],
    "userId": "00000000-0000-0000-0000-000000000000",
    "guestRatings": [
        {
            "dinnerId": "",
            "hostId": "",
            "rating": 4.5
        }
    ],
    "createdOn": "",
    "createdBy": "",
    "modifiedOn": "",
    "modifiedBy": ""
}
```