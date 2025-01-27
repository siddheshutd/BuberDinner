namespace BuberDinner.Domain.Bill.Entities;

public class Price
{
    public float Amount { get; set; }
    public string Currency { get; set; }
    private Price(int amount, string currency){
        Amount = amount;
        Currency = currency;
    }
    public static Price Create(int amount, string currency = "USD"){
        return new Price(amount, currency);
    }
}
