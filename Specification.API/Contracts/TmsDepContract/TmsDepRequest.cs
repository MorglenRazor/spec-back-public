namespace Specification.API.Contracts.TmsDepContract;

public record TmsDepRequest(
    //bool IsReady,
    string NameBrandForPurchase,
    int Count,
    //int[] DodContract,
    int[] DodPlan,
    int[] DodFact,
    decimal PriceNoTax,
    decimal PriceWithTax,
    decimal Amount,
    string AccountNumber,
    int[] DateAccount,
    //decimal FirstPay,
    //int[] DateFirstPay,
    //decimal SecondPay,
    //int[] DateSecondPay,
    //decimal ThirdPay,
    //int[] DateThirdPay,
    //decimal PaymentBalance,
    //decimal CostOfRefand,
    string Comment,
    Guid DeviceChapterId,
    int ContId,
    Guid? EmpRespId
);
