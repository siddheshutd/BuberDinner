namespace BuberDinner.Contracts.Menu;

public record MenuResponse(
    string MenuId,
    string HostId,
    string Name,
    string Description,
    List<MenuSectionResponse> Sections,
    float AverageRating,
    List<string> DinnerIds,
    List<string> MenuReviewIds,
    DateTime CreatedOn,
    DateTime ModifiedOn
);

public record MenuSectionResponse(
    string MenuSectionId,
    string Name,
    string Description,
    List<MenuItemResponse> Items
);

public record MenuItemResponse(
    string MenuItemId,
    string Name,
    string Description
);