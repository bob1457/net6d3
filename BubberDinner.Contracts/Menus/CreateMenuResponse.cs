namespace BubbberDinner.Contracts.Menus;

public record CreateMenuResponse(
    string Id,
    string Name,
    string Description,
    float? AverageRating,
    List<MenuSectionResponse> Sections,
    string HostId,
    List<string> DinnerIds,
    List<MenuSectionResponse> SectionResponse,
    DateTime CreationDateTime,
    DateTime UpdateDateTime);

public record MenuSectionResponse(
    string Id,
    string Name,
    string Description,
    List<MenuItemResponse> ItemsResponse);

public record MenuItemResponse(string Id,
                               string Name,
                               string Description);
