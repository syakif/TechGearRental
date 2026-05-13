//The structure we will use when reading data from the database and returning it to the API
public record GearDto(
    int Id,
    string Brand,
    string Model,
    decimal PricePerDay,
    string Status, //it's more readable for API consumers to return string instead of enum
    string CategoryName
);

//While creating a new gear, we expect this structure from the API (we don't want Id or Status)
public record CreateGearDto(
    string Brand,
    string Model,
    string SerialNumber,
    decimal PricePerDay,
    int CategoryId
);