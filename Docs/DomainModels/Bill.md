# Domain Models

## Bill

```csharp
class Bill
{
    Bill Create(Bill bill);
    void updatePaymentStatus(boolean isPaid);
    void updateAmount(float newAmount);
}
```

```json
{
    "id": { "value": "00000000-0000-0000-0000-000000000000" },
    "dinnerId": { "value": "00000000-0000-0000-0000-000000000000" },
    "guestId": { "value": "00000000-0000-0000-0000-000000000000" },
    "hostId": { "value": "00000000-0000-0000-0000-000000000000" },
    "price": {
        "amount": 10.99,
        "currency": "USD"
    },
    "createdOn": "2020-01-01T00:00:00.0000000Z",
    "modifiedOn": "2020-01-01T00:00:00.0000000Z"
}
```