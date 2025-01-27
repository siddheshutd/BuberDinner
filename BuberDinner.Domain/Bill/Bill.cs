using BuberDinner.Domain.Bill.Entities;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.Bill.ValueObjects;

namespace BuberDinner.Domain.Bill;

public sealed class Bill : AggregateRoot<BillId>
{
    public DinnerId DinnerId { get; }
    public GuestId GuestId { get; }
    public HostId HostId { get; }
    public Price Price { get; }
    public DateTime CreatedOn { get; }
    public DateTime ModifiedOn { get; }
    private Bill(BillId billId, DinnerId dinnerId, GuestId guestId, HostId hostId, Price price) : base(billId){
        GuestId = guestId;
        DinnerId = dinnerId;
        HostId = hostId;
        Price = price;
        CreatedOn = DateTime.UtcNow;
        ModifiedOn = DateTime.UtcNow;
    } 

    public static Bill Create(BillId billId, DinnerId dinnerId, GuestId guestId, HostId hostId, int price){
        return new Bill(billId, dinnerId, guestId, hostId, Price.Create(price));
    }

    public void UpdateAmount(int newAmount){
        Price.Amount = newAmount;
    }
}