public record RentalDto(
    int Id,
    int GearId,
    string GearModel,
    DateTime StartDate,
    DateTime EndDate,
    decimal TotalPrice,
    string Status
);

public record CreateRentalDto(
    int GearId,
    int UserId,
    DateTime StartDate,
    DateTime EndDate
);