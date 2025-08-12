namespace Specification.API.Contracts.AccountingDepContract;

public record AccountingDepResponse(
    int Id,
    // bool DocIsSubmitted,
    string NameBrandForUpd,
    float CountFact,
    decimal PriceOnOneTax,
    decimal AmountTax,
    string Article,
    string AcompDoc,
    DateTime DateDev,
    decimal Price,
    string Comment,
    int UnitId,
    Guid? EmpRespId,
    Guid ChapterDeviceId
);

public record AccountingDepResponseDetails(
    int Id,
    // bool DocIsSubmitted,
    string NameBrandForUpd,
    float CountFact,
    decimal PriceOnOneTax,
    decimal AmountTax,
    string Article,
    string AcompDoc,
    int[] DateDev,
    decimal Price,
    string Comment,
    string UnitName,
    string EmpShortName,
    Guid ChapterDeviceId,
    int UnitId,
    Guid? EmpRespId
);
