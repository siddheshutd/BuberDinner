using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.MenuReview.ValueObjects;

namespace BuberDinner.Domain.MenuReview;

public sealed class MenuReview : AggregateRoot<MenuReviewId>
{
    public float Rating { get; set; }
    public string Comment { get; set; }
    public HostId HostId{ get; set; }
    public MenuId MenuId{ get; set; }
    public GuestId GuestId{ get; set; }
    public DinnerId DinnerId{ get; set; }
    public DateTime CreatedOn { get; }
    public DateTime ModifiedOn { get; }

    private MenuReview(MenuReviewId menuReviewId, float rating, string comment, HostId hostId, MenuId menuId, GuestId guestId, DinnerId dinnerId, DateTime createdOn, DateTime modifiedOn) : base(menuReviewId) {
        Rating = rating;
        Comment = comment;
        HostId = hostId;
        MenuId = menuId;
        GuestId = guestId;
        DinnerId = dinnerId;
        CreatedOn = createdOn;
        ModifiedOn = modifiedOn;
    }

    public static MenuReview Create(float rating, string comment, HostId hostId, MenuId menuId, GuestId guestId, DinnerId dinnerId){
        return new MenuReview(MenuReviewId.CreateUnique(), rating, comment, hostId, menuId, guestId, dinnerId, DateTime.UtcNow, DateTime.UtcNow);
    }
}
