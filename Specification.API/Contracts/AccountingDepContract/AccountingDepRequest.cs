namespace Specification.API.Contracts.AccountingDepContract;

public record AccountingDepRequest(
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
    int UnitId,
    Guid? EmpRespId,
    Guid ChapterDeviceId
);
