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
    "id": "00000000-0000-0000-0000-000000000000",
    "dinnerId": "00000000-0000-0000-0000-000000000000",
    "guestId": "00000000-0000-0000-0000-000000000000",
    "paymentStatus": "Paid",
    "amount": 2.99
}
```