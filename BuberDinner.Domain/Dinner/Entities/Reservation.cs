using BuberDinner.Domain.Bill.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;

namespace BuberDinner.Domain.Dinner.Entities;

public class Reservation : Entity<ReservationId>
{
    public GuestId GuestId { get; }
    public BillId BillId { get; }
    public bool CheckedIn { get; }
    public int GuestCount { get; }
    public DateTime ArrivedOn { get; }
    public DateTime CreatedOn { get; }
    public DateTime ModifiedOn { get; }
    private Reservation(ReservationId reservationId, GuestId guestId, BillId billId, bool checkedIn, int guestCount): base(reservationId){
        GuestId = guestId;
        BillId = billId;
        CheckedIn = checkedIn;
        GuestCount = guestCount;
    }

    public static Reservation Create(GuestId guestId, BillId billId, int guestCount){
        return new(ReservationId.CreateUnique(), guestId, billId, false, guestCount);  
    }
}
