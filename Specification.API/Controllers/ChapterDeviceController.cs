using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Specification.API.Contracts.AccountingDepContract;
using Specification.API.Contracts.ChapterDeviceContract;
using Specification.API.Contracts.ConstructionDepContract;
using Specification.API.Contracts.TcDepContract;
using Specification.API.Contracts.TmsDepContract;
using Specification.API.Contracts.WarehouseDepContract;
using Specification.Core.Abstractions.Service;
using Specification.Core.Models;
using Specification.Core.Utilities;

namespace Specification.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ChapterDeviceController : Controller
{
    private readonly ITableService<DevicesChapter> _service;
    private readonly IChapterDeviceService _serviceChapterDevice;
 
    public ChapterDeviceController(
        ITableService<DevicesChapter> service,
        IChapterDeviceService serviceChapterDevice
    )
    {
        _service = service;
        _serviceChapterDevice = serviceChapterDevice;
    }

    [HttpGet]
    [Authorize(Roles = "Developer,User")]
    public async Task<ActionResult<List<ChapterDeviceResponse>>> GetChapterDevices()
    {
        List<DevicesChapter> devicesChapters = await _service.Get(Guid.Empty);
        List<ChapterDeviceResponse> responses = devicesChapters
            .Select(s => new ChapterDeviceResponse(
                DeviceChapterId: s.DeviceChapterId,
                SubChapterGuid: s.SubChapterId,
                DeviceId: s.DeviceId,
                StatusId: s.StatusId,
                SerialNum: s.SerialNumber!=null? s.SerialNumber:"",
                CountDevice: s.CountDevice,
                CompId: s.CompId,
                CompName: s.CompName
            ))
            .ToList();
        return Ok(responses);
    }

    [HttpGet("{id:guid}")]
    [Authorize(Roles = "Developer,User")]
    public async Task<ActionResult<List<ChapterDeviceResponse>>> GetChapterDevices(Guid id)
    {
        List<DevicesChapter> devicesChapters = await _service.Get(id);
        List<ChapterDeviceResponse> responses = devicesChapters
            .Select(s => new ChapterDeviceResponse(
                DeviceChapterId: s.DeviceChapterId,
                SubChapterGuid: s.SubChapterId,
                DeviceId: s.DeviceId,
                StatusId: s.StatusId,
                SerialNum: s.SerialNumber != null ? s.SerialNumber : "",
                CountDevice: s.CountDevice,
                CompId: s.CompId,
                CompName: s.CompName
            ))
            .ToList();
        return Ok(responses);
    }


    [HttpGet("/GetDeviceChapIdForChapId/{chapId:guid}")]
    [Authorize(Roles = "Developer,User")]
    public async Task<ActionResult<List<ChapterDeviceResponse>>> GetChapterDevicesId(Guid chapId)
    {
        List<DevicesChapter> devicesChapters = await _serviceChapterDevice.GetNtfData();
        List<GetDeviceChapterIdResponse> responses = devicesChapters
            .Select(s => new GetDeviceChapterIdResponse(
                DeviceChapterId: s.DeviceChapterId
            ))
            .ToList();
        return Ok(responses);
    }

    [HttpGet("/ChapterDevice/NftData/")]
    [Authorize(Roles = "Developer,User")]
    public async Task<ActionResult<List<ChapterDeviceResponse>>> GetChapterDevicesNftData()
    {
        List<DevicesChapter> devicesChapters = await _serviceChapterDevice.GetNtfData();
        List<ChapterDeviceNftDataResponse> responses = devicesChapters
            .Select(s => new ChapterDeviceNftDataResponse(
                DeviceChapterId: s.DeviceChapterId,
                SubChapterGuid: s.SubChapterId,
                StatusId: s.StatusId,
                SerialNum: s.SerialNumber!=null? s.SerialNumber:"",
                DeviceName: s.DeviceName,
                BrandName: s.BrandName,
                StatusName: s.StatusName,
                CountDevice: s.CountDevice,
                CompId: s.CompId,
                CompName: s.CompName
            ))
            .ToList();
        return Ok(responses);
    }

    [HttpGet("/nft/getCdStatusResp/")]
    [Authorize(Roles = "User")]
    public async Task<ActionResult<GetStatusRespResponse>> GetCdStatusResp()
    {
        List<DevicesChapter> devicesChapters = await _serviceChapterDevice.GetWithIncludes(
            Guid.Empty
        );
        List<GetStatusRespResponse> responses = devicesChapters.Select(s => new GetStatusRespResponse(
                Status:s.StatusId,
                EmpId: s.ConstructionDepPart.Select(s=>s.EmpRespId).FirstOrDefault()
            )).ToList();
        return Ok(responses);
    }

    [HttpGet("/nft/getWdStatusResp/")]
    [Authorize(Roles = "User")]
    public async Task<ActionResult<GetStatusRespResponse>> GetWdStatusResp()
    {
        List<DevicesChapter> devicesChapters = await _serviceChapterDevice.GetWithIncludes(
            Guid.Empty
        );
        List<GetStatusRespResponse> responses = devicesChapters.Select(s => new GetStatusRespResponse(
                Status: s.StatusId,
                EmpId: s.WarehouseDepPart.Select(s => s.EmpRespId).FirstOrDefault()
            )).ToList();
        return Ok(responses);
    }

    [HttpGet("/nft/getAdStatusResp/")]
    [Authorize(Roles = "User")]
    public async Task<ActionResult<GetStatusRespResponse>> GetAdStatusResp()
    {
        List<DevicesChapter> devicesChapters = await _serviceChapterDevice.GetWithIncludes(
            Guid.Empty
        );
        List<GetStatusRespResponse> responses = devicesChapters.Select(s => new GetStatusRespResponse(
                Status: s.StatusId,
                EmpId: s.AccountingDepPart.Select(s => s.EmpRespId).FirstOrDefault()
            )).ToList();
        return Ok(responses);
    }

    [HttpGet("/nft/getMtsStatusResp/")]
    [Authorize(Roles = "User")]
    public async Task<ActionResult<GetStatusRespResponse>> GetMtsStatusResp()
    {
        List<DevicesChapter> devicesChapters = await _serviceChapterDevice.GetWithIncludes(
            Guid.Empty
        );
        List<GetStatusRespResponse> responses = devicesChapters.Select(s => new GetStatusRespResponse(
                Status: s.StatusId,
                EmpId: s.TmsDepPart.Select(s => s.EmpRespId).FirstOrDefault()
            )).ToList();
        return Ok(responses);
    }

    [HttpGet("/nft/getTcStatusResp/")]
    [Authorize(Roles = "User")]
    public async Task<ActionResult<GetStatusRespResponse>> GetTcStatusResp()
    {
        List<DevicesChapter> devicesChapters = await _serviceChapterDevice.GetWithIncludes(
            Guid.Empty
        );
        List<GetStatusRespResponse> responses = devicesChapters.Select(s => new GetStatusRespResponse(
                Status: s.StatusId,
                EmpId: s.TcDepPart.Select(s => s.EmpRespId).FirstOrDefault()
            )).ToList();
        return Ok(responses);
    }


   
    [HttpGet("/inc/")]
    [Authorize(Roles = "Developer,User")]
    public async Task<ActionResult<List<ChapterDeviceResponse>>> GetChapterDevicesInc()
    {
        List<DevicesChapter> devicesChapters = await _serviceChapterDevice.GetWithIncludes(Guid.Empty);
        List<ChapterDeviceResponseInc> responses = devicesChapters
            .Select(s => new ChapterDeviceResponseInc(
                DeviceChapterId: s.DeviceChapterId,
                SubChapterGuid: s.SubChapterId,
                StatusId: s.StatusId,
                DeviceId: s.DeviceId,
                SerialNum: s.SerialNumber!=null? s.SerialNumber:"",
                CountDevice: s.CountDevice,
                CompId: s.CompId,
                CompName: s.CompName,
                ConstructionDep: s.ConstructionDepPart.Select(ctDep => new ConstructionDepResponse(
                        Id: ctDep.ConstructionDepId,
                        //CountDevice: ctDep.CountDevice,
                        Comment: ctDep.Comment,
                        UnitId: ctDep.UnitId,
                        EmpRespId: ctDep.EmpRespId,
                        DeviceChapterId: ctDep.ChapterDeviceId
                    ))
                    .ToList(),
                TechMaterialSuppDep: s.TmsDepPart.Select(tms => new TmsDepResponse(
                        Id: tms.TmsDepId,
                        NameBrandForPurchase: tms.NameBrandForPurchase,
                        Count: tms.Count,
                      //  DodContract: tms.DodContract,
                        DodPlan: tms.DodPlan,
                        DodFact: tms.DodFact,
                        PriceNoTax: tms.PriceNoTax,
                        PriceWithTax: tms.PriceWithTax,
                        Amount: tms.Amount,
                        AccountNumber: tms.AccountNumber,
                        DateAccount: tms.DateAccount,
                        //FirstPay: tms.FirstPay,
                        //DateFirstPay: tms.DateFirstPay,
                        ////SecondPay: tms.SecondPay,
                        //DateSecondPay: tms.DateSecondPay,
                        //ThirdPay: tms.ThirdPay,
                        //DateThirdPay: tms.DateThirdPay,
                        //PaymentBalance: tms.PaymentBalance,
                        //CostOfRefand: tms.CostOfRefand,
                        Comment: tms.Comment,
                        DeviceChapterId: tms.ChapDeviceId,
                        ContId: tms.ContId,
                        EmpRespId: tms.EmpRespId
                    ))
                    .ToList(),
                TechControlDep: s.TcDepPart.Select(tc => new TcDepResponse(
                        Id: tc.TcDepId,
                        NameBrandInDoc: tc.NameBrandInDoc,
                        Count: tc.Count,
                        //SerialNum: tc.SerialNum,
                        CompKit: tc.CompKit,
                        CompTechDocAvailable: tc.CompTechDocAvailable,
                        CompTechDocMissing: tc.CompTechDocMissing,
                        Defects: tc.Defects,
                        Conclusion: tc.Conclusion,
                        Comment: tc.Comment,
                        UnitId: tc.UnitId,
                        EmpRespId: tc.EmpRespId,
                        DeviceChapterId: tc.ChapterDeviceId
                    ))
                    .ToList(),
                WarehouseDep: s.WarehouseDepPart.Select(wd => new WarehouseDepResponse(
                        Id: wd.WarehouseDepId,
                        CountOnStorage: wd.CountOnStorage,
                        CountAfterPurchase: wd.CountAfterPurchase,
                        RemainsCountAfterPurchase: wd.RemainsCountAfterPurchase,
                        //SerialNumber: wd.SerialNumber,
                        //WriteOfDoc: wd.WriteOfDoc,
                        //WriteOfDate: wd.WriteOfDate,
                        //AcceptSets: wd.AcceptSets,
                        Comment: wd.Comment,
                        GenUnitId: wd.GenUnitId,
                        RemainsUnitId: wd.RemainsUnitId,
                        DeviceChapterId: wd.ChapterDeviceId,
                        EmpRespId: wd.EmpRespId
                    ))
                    .ToList(),
                AccountingDep: s.AccountingDepPart.Select(ad => new AccountingDepResponse(
                        Id: ad.AccountingDepId,
                        NameBrandForUpd: ad.NameBrandForUpd,
                        CountFact: ad.CountFact,
                        PriceOnOneTax: ad.PriceOnOneTax,
                        AmountTax: ad.AmountTax,
                        Article: ad.Article,
                        AcompDoc: ad.AcompDoc,
                        DateDev: ad.DateDev,
                        Price: ad.Price,
                        Comment: ad.Comment,
                        UnitId: ad.UnitId,
                        EmpRespId: ad.EmpRespId,
                        ChapterDeviceId: ad.ChapterDeviceId
                    ))
                    .ToList()
            ))
            .ToList();
        return Ok(responses);
    }

    [HttpGet("/inc/{id:guid}")]
    [Authorize(Roles = "Developer,User")]
    public async Task<ActionResult<List<ChapterDeviceResponse>>> GetChapterDevicesInc(Guid id)
    {
        List<DevicesChapter> devicesChapters = await _serviceChapterDevice.GetWithIncludes(id);
        List<ChapterDeviceResponseInc> responses = devicesChapters
            .Select(s => new ChapterDeviceResponseInc(
                DeviceChapterId: s.DeviceChapterId,
                SubChapterGuid: s.SubChapterId,
                StatusId: s.StatusId,
                DeviceId: s.DeviceId,
                SerialNum: s.SerialNumber!=null? s.SerialNumber:"",
                CountDevice: s.CountDevice,
                CompId: s.CompId,
                CompName: s.CompName,
                ConstructionDep: s.ConstructionDepPart.Select(ctDep => new ConstructionDepResponse(
                        Id: ctDep.ConstructionDepId,
                        //CountDevice: ctDep.CountDevice,
                        Comment: ctDep.Comment,
                        UnitId: ctDep.UnitId,
                        EmpRespId: ctDep.EmpRespId,
                        DeviceChapterId: ctDep.ChapterDeviceId
                    ))
                    .ToList(),
                TechMaterialSuppDep: s.TmsDepPart.Select(tms => new TmsDepResponse(
                        Id: tms.TmsDepId,
                        //IsReady: tms.IsReady,
                        NameBrandForPurchase: tms.NameBrandForPurchase,
                        Count: tms.Count,
                        //DodContract: tms.DodContract,
                        DodPlan: tms.DodPlan,
                        DodFact: tms.DodFact,
                        PriceNoTax: tms.PriceNoTax,
                        PriceWithTax: tms.PriceWithTax,
                        Amount: tms.Amount,
                        AccountNumber: tms.AccountNumber,
                        DateAccount: tms.DateAccount,
                        //FirstPay: tms.FirstPay,
                        //DateFirstPay: tms.DateFirstPay,
                        //SecondPay: tms.SecondPay,
                        //DateSecondPay: tms.DateSecondPay,
                       // ThirdPay: tms.ThirdPay,
                       // DateThirdPay: tms.DateThirdPay,
                       // PaymentBalance: tms.PaymentBalance,
                       // CostOfRefand: tms.CostOfRefand,
                        Comment: tms.Comment,
                        DeviceChapterId: tms.ChapDeviceId,
                        ContId: tms.ContId,
                        EmpRespId: tms.EmpRespId
                    ))
                    .ToList(),
                TechControlDep: s.TcDepPart.Select(tc => new TcDepResponse(
                        Id: tc.TcDepId,
                        //  Status:tc.Status,
                        NameBrandInDoc: tc.NameBrandInDoc,
                        Count: tc.Count,
                       // SerialNum: tc.SerialNum,
                        CompKit: tc.CompKit,
                        CompTechDocAvailable: tc.CompTechDocAvailable,
                        CompTechDocMissing: tc.CompTechDocMissing,
                        Defects: tc.Defects,
                        Conclusion: tc.Conclusion,
                        Comment: tc.Comment,
                        UnitId: tc.UnitId,
                        EmpRespId: tc.EmpRespId,
                        DeviceChapterId: tc.ChapterDeviceId
                    ))
                    .ToList(),
                WarehouseDep: s.WarehouseDepPart.Select(wd => new WarehouseDepResponse(
                        Id: wd.WarehouseDepId,
                        // ExistOnStorage: wd.ExistOnStorage,
                        CountOnStorage: wd.CountOnStorage,
                        CountAfterPurchase: wd.CountAfterPurchase,
                        RemainsCountAfterPurchase: wd.RemainsCountAfterPurchase,
                        //SerialNumber: wd.SerialNumber,
                        //WriteOfDoc: wd.WriteOfDoc,
                        //WriteOfDate: wd.WriteOfDate,
                        //AcceptSets: wd.AcceptSets,
                        Comment: wd.Comment,
                        GenUnitId: wd.GenUnitId,
                        RemainsUnitId: wd.RemainsUnitId,
                        DeviceChapterId: wd.ChapterDeviceId,
                        EmpRespId: wd.EmpRespId
                    ))
                    .ToList(),
                AccountingDep: s.AccountingDepPart.Select(ad => new AccountingDepResponse(
                        Id: ad.AccountingDepId,
                        // DocIsSubmitted: ad.DocIsSubmitted,
                        NameBrandForUpd: ad.NameBrandForUpd,
                        CountFact: ad.CountFact,
                        PriceOnOneTax: ad.PriceOnOneTax,
                        AmountTax: ad.AmountTax,
                        Article: ad.Article,
                        AcompDoc: ad.AcompDoc,
                        DateDev: ad.DateDev,
                        Price: ad.Price,
                        Comment: ad.Comment,
                        UnitId: ad.UnitId,
                        EmpRespId: ad.EmpRespId,
                        ChapterDeviceId: ad.ChapterDeviceId
                    ))
                    .ToList()
            ))
            .ToList();
        return Ok(responses);
    }

    [HttpGet("/details/")]
    [Authorize(Roles = "Developer,User")]
    public async Task<ActionResult<List<ChapterDeviceResponseDetails>>> GetChapterDevicesDetails(Guid id)   
    {
        List<DevicesChapter> devicesChapters = await _serviceChapterDevice.GetDetails(id);
        List<ChapterDeviceResponseDetails> responses = devicesChapters
            .Select(s => new ChapterDeviceResponseDetails(
                DeviceChapterId: s.DeviceChapterId,
                SubChapterGuid: s.SubChapterId,
                StatusId: s.StatusId,
                SerialNum: s.SerialNumber!=null ? s.SerialNumber:"",
                StatusName: s.StatusName,
                StatusRank: s.StatusRank,
                DepName: s.DepName,
                DeviceName: s.DeviceName,
                BrandName: s.BrandName,
                CountDevice: s.CountDevice,
                CompId: s.CompId,
                CompName: s.CompName,
                ReqProdDate: [s.RequiredProdDate.Year, s.RequiredProdDate.Month, s.RequiredProdDate.Day,
                s.RequiredProdDate.Hour, s.RequiredProdDate.Minute, s.RequiredProdDate.Second],
                DateToEditing: [s.DateToEditing.Year, s.DateToEditing.Month, s.DateToEditing.Day,
                s.DateToEditing.Hour, s.DateToEditing.Minute, s.DateToEditing.Second],
                DateToFilling: [s.DateToFilling.Year, s.DateToFilling.Month, s.DateToFilling.Day,
                s.DateToFilling.Hour, s.DateToFilling.Minute, s.DateToFilling.Second],
                DeviceId: s.DeviceId,
                ConstructionDep: s.ConstructionDepPart.Select(
                        ctDep => new ConstructionDepResponseDetails(
                            Id: ctDep.ConstructionDepId,
                            //CountDevice: ctDep.CountDevice,
                            Comment: ctDep.Comment,
                            UnitName: ctDep.UnitNameCd,
                            EmpShortName: ctDep.EmpShortName,
                            DeviceChapterId: ctDep.ChapterDeviceId,
                            UnitId: ctDep.UnitId,
                            EmpRespId: ctDep.EmpRespId
                        )
                    )
                    .ToList(),
                TechMaterialSuppDep: s.TmsDepPart.Select(tms => new TmsDepResponseDetails(
                        Id: tms.TmsDepId,
                        NameBrandForPurchase: tms.NameBrandForPurchase,
                        Count: tms.Count,
                      //  DodContract:[tms.DodContract.Year, 
                      //      tms.DodContract.Month, 
                      //      tms.DodContract.Day, 
                      //      tms.DodContract.Hour, 
                      //      tms.DodContract.Minute, 
                      //      tms.DodContract.Second],
                        DodPlan: [tms.DodPlan.Year,
                            tms.DodPlan.Month,
                            tms.DodPlan.Day,
                            tms.DodPlan.Hour,
                            tms.DodPlan.Minute,
                            tms.DodPlan.Second], 
                        DodFact: [tms.DodFact.Year,
                            tms.DodFact.Month,
                            tms.DodFact.Day,
                            tms.DodFact.Hour,
                            tms.DodFact.Minute,
                            tms.DodFact.Second] ,
                        PriceNoTax: tms.PriceNoTax,
                        PriceWithTax: tms.PriceWithTax,
                        Amount: tms.Amount,
                        AccountNumber: tms.AccountNumber,
                        DateAccount: [tms.DateAccount.Year,
                            tms.DateAccount.Month,
                            tms.DateAccount.Day,
                            tms.DateAccount.Hour,
                            tms.DateAccount.Minute,
                            tms.DateAccount.Second],
                       // FirstPay: tms.FirstPay,
                        //DateFirstPay: [tms.DateFirstPay.Year,
                        //    tms.DateFirstPay.Month,
                        //    tms.DateFirstPay.Day,
                        //    tms.DateFirstPay.Hour,
                        //    tms.DateFirstPay.Minute,
                        //    tms.DateFirstPay.Second],
                        //SecondPay: tms.SecondPay,
                       // DateSecondPay: [tms.DateSecondPay.Year,
                       //     tms.DateSecondPay.Month,
                       //     tms.DateSecondPay.Day,
                       //     tms.DateSecondPay.Hour,
                       //     tms.DateSecondPay.Minute,
                       //     tms.DateSecondPay.Second] ,
                       // ThirdPay: tms.ThirdPay,
                       // DateThirdPay: [tms.DateThirdPay.Year,
                       //     tms.DateThirdPay.Month,
                       //     tms.DateThirdPay.Day,
                       //     tms.DateThirdPay.Hour,
                       //     tms.DateThirdPay.Minute,
                       //     tms.DateThirdPay.Second],
                       // PaymentBalance: tms.PaymentBalance,
                       // CostOfRefand: tms.CostOfRefand,
                        Comment: tms.Comment,
                        DeviceChapterId: tms.ChapDeviceId,
                        ContName: tms.ContName,
                        ContInn: tms.ContInn,
                        EmpShortName: tms.EmpShortName,
                        ContId: tms.ContId,
                        EmpRespId: tms.EmpRespId
                    ))
                    .ToList(),
                TechControlDep: s.TcDepPart.Select(tc => new TcDepResponseDetails(
                        Id: tc.TcDepId,
                        NameBrandInDoc: tc.NameBrandInDoc,
                        Count: tc.Count,
                      //  SerialNum: tc.SerialNum,
                        CompKit: tc.CompKit,
                        CompTechDocAvailable: tc.CompTechDocAvailable,
                        CompTechDocMissing: tc.CompTechDocMissing,
                        Defects: tc.Defects,
                        Conclusion: tc.Conclusion,
                        Comment: tc.Comment,
                        UnitName: tc.UnitName,
                        EmpShortName: tc.EmpShortName,
                        DeviceChapterId: tc.ChapterDeviceId,
                        UnitId: tc.UnitId,
                        EmpRespId: tc.EmpRespId
                    ))
                    .ToList(),
                WarehouseDep: s.WarehouseDepPart.Select(wd => new WarehouseDepResponseDetails(
                        Id: wd.WarehouseDepId,
                        CountOnStorage: wd.CountOnStorage,
                        CountAfterPurchase: wd.CountAfterPurchase,
                        RemainsCountAfterPurchase: wd.RemainsCountAfterPurchase,
                        //SerialNumber: wd.SerialNumber,
                        //WriteOfDoc: wd.WriteOfDoc,
                        //WriteOfDate: [wd.WriteOfDate.Year, wd.WriteOfDate.Month, wd.WriteOfDate.Day,
                        //wd.WriteOfDate.Hour, wd.WriteOfDate.Minute, wd.WriteOfDate.Second],
                        //AcceptSets: wd.AcceptSets,
                        Comment: wd.Comment,
                        GenUnitName: wd.GenUnitName,
                        RemainsUnitName: wd.RemainsUnitName,
                        DeviceChapterId: wd.ChapterDeviceId,
                        EmpShortName: wd.EmpShortName,
                        GenUnitId: wd.GenUnitId,
                        RemUnitId: wd.RemainsUnitId,
                        EmpRespId: wd.EmpRespId
                    ))
                    .ToList(),
                AccountingDep: s.AccountingDepPart.Select(ad => new AccountingDepResponseDetails(
                        Id: ad.AccountingDepId,
                        NameBrandForUpd: ad.NameBrandForUpd,
                        CountFact: ad.CountFact,
                        PriceOnOneTax: ad.PriceOnOneTax,
                        AmountTax: ad.AmountTax,
                        Article: ad.Article,
                        AcompDoc: ad.AcompDoc,
                        DateDev: [ad.DateDev.Year, ad.DateDev.Month, ad.DateDev.Day, ad.DateDev.Hour, ad.DateDev.Minute, ad.DateDev.Second],
                        Price: ad.Price,
                        Comment: ad.Comment,
                        UnitName: ad.UnitName,
                        EmpShortName: ad.EmpShortName,
                        ChapterDeviceId: ad.ChapterDeviceId,
                        UnitId: ad.UnitId,
                        EmpRespId: ad.EmpRespId
                    ))
                    .ToList()))
            .ToList();
       // await _serviceChapterDevice.GetRepeatRecord(Guid.Parse("5d0a942f-3d14-4c2e-8f8f-136e8dc06901"), "");
        return Ok(responses);
    }

    [HttpGet("/groupDeviceChapter/{id:guid}")]
    [Authorize(Roles = "Developer,User")]
    public async Task<ActionResult<List<ChapterDeviceResponseDetails>>> GetChapterDevicesGroup(Guid id)
    {
        List<DevicesChapter> devicesChapters = await _serviceChapterDevice.GetGroupDeviceChapters(id);
        List<ChapterDeviceResponseDetails> responses = devicesChapters
            .Select(s => new ChapterDeviceResponseDetails(
                DeviceChapterId: s.DeviceChapterId,
                SubChapterGuid: s.SubChapterId,
                StatusId: s.StatusId,
                SerialNum: s.SerialNumber!=null? s.SerialNumber:"",
                StatusName: s.StatusName,
                StatusRank: s.StatusRank,
                DepName: s.DepName,
                DeviceName: s.DeviceName,
                BrandName: s.BrandName,
                CountDevice: s.CountDevice,
                CompId: s.CompId,
                CompName: s.CompName,
                ReqProdDate: [s.RequiredProdDate.Year, s.RequiredProdDate.Month, s.RequiredProdDate.Day,
                s.RequiredProdDate.Hour, s.RequiredProdDate.Minute, s.RequiredProdDate.Second],
                DateToEditing: [s.DateToEditing.Year, s.DateToEditing.Month, s.DateToEditing.Day,
                s.DateToEditing.Hour, s.DateToEditing.Minute, s.DateToEditing.Second],
                DateToFilling: [s.DateToFilling.Year, s.DateToFilling.Month, s.DateToFilling.Day,
                s.DateToFilling.Hour, s.DateToFilling.Minute, s.DateToFilling.Second],
                DeviceId: s.DeviceId,
                ConstructionDep: s.ConstructionDepPart.Select(
                        ctDep => new ConstructionDepResponseDetails(
                            Id: ctDep.ConstructionDepId,
                            //CountDevice: ctDep.CountDevice,
                            Comment: ctDep.Comment,
                            UnitName: ctDep.UnitNameCd,
                            EmpShortName: ctDep.EmpShortName,
                            DeviceChapterId: ctDep.ChapterDeviceId,
                            UnitId: ctDep.UnitId,
                            EmpRespId: ctDep.EmpRespId
                        )
                    )
                    .ToList(),
                TechMaterialSuppDep: s.TmsDepPart.Select(tms => new TmsDepResponseDetails(
                        Id: tms.TmsDepId,
                        NameBrandForPurchase: tms.NameBrandForPurchase,
                        Count: tms.Count,
                        //  DodContract:[tms.DodContract.Year, 
                        //      tms.DodContract.Month, 
                        //      tms.DodContract.Day, 
                        //      tms.DodContract.Hour, 
                        //      tms.DodContract.Minute, 
                        //      tms.DodContract.Second],
                        DodPlan: [tms.DodPlan.Year,
                            tms.DodPlan.Month,
                            tms.DodPlan.Day,
                            tms.DodPlan.Hour,
                            tms.DodPlan.Minute,
                            tms.DodPlan.Second],
                        DodFact: [tms.DodFact.Year,
                            tms.DodFact.Month,
                            tms.DodFact.Day,
                            tms.DodFact.Hour,
                            tms.DodFact.Minute,
                            tms.DodFact.Second],
                        PriceNoTax: tms.PriceNoTax,
                        PriceWithTax: tms.PriceWithTax,
                        Amount: tms.Amount,
                        AccountNumber: tms.AccountNumber,
                        DateAccount: [tms.DateAccount.Year,
                            tms.DateAccount.Month,
                            tms.DateAccount.Day,
                            tms.DateAccount.Hour,
                            tms.DateAccount.Minute,
                            tms.DateAccount.Second],
                       // FirstPay: tms.FirstPay,
                       // DateFirstPay: [tms.DateFirstPay.Year,
                       //     tms.DateFirstPay.Month,
                       //     tms.DateFirstPay.Day,
                       //     tms.DateFirstPay.Hour,
                        //    tms.DateFirstPay.Minute,
                       //     tms.DateFirstPay.Second],
                       // SecondPay: tms.SecondPay,
                       // DateSecondPay: [tms.DateSecondPay.Year,
                       //     tms.DateSecondPay.Month,
                       //     tms.DateSecondPay.Day,
                       //     tms.DateSecondPay.Hour,
                       //     tms.DateSecondPay.Minute,
                       //     tms.DateSecondPay.Second],
                      //  ThirdPay: tms.ThirdPay,
                      //  DateThirdPay: [tms.DateThirdPay.Year,
                      //      tms.DateThirdPay.Month,
                      //      tms.DateThirdPay.Day,
                       //     tms.DateThirdPay.Hour,
                      //      tms.DateThirdPay.Minute,
                       //     tms.DateThirdPay.Second],
                      //  PaymentBalance: tms.PaymentBalance,
                       // CostOfRefand: tms.CostOfRefand,
                        Comment: tms.Comment,
                        DeviceChapterId: tms.ChapDeviceId,
                        ContName: tms.ContName,
                        ContInn: tms.ContInn,
                        EmpShortName: tms.EmpShortName,
                        ContId: tms.ContId,
                        EmpRespId: tms.EmpRespId
                    ))
                    .ToList(),
                TechControlDep: s.TcDepPart.Select(tc => new TcDepResponseDetails(
                        Id: tc.TcDepId,
                        NameBrandInDoc: tc.NameBrandInDoc,
                        Count: tc.Count,
                      //  SerialNum: tc.SerialNum,
                        CompKit: tc.CompKit,
                        CompTechDocAvailable: tc.CompTechDocAvailable,
                        CompTechDocMissing: tc.CompTechDocMissing,
                        Defects: tc.Defects,
                        Conclusion: tc.Conclusion,
                        Comment: tc.Comment,
                        UnitName: tc.UnitName,
                        EmpShortName: tc.EmpShortName,
                        DeviceChapterId: tc.ChapterDeviceId,
                        UnitId: tc.UnitId,
                        EmpRespId: tc.EmpRespId
                    ))
                    .ToList(),
                WarehouseDep: s.WarehouseDepPart.Select(wd => new WarehouseDepResponseDetails(
                        Id: wd.WarehouseDepId,
                        CountOnStorage: wd.CountOnStorage,
                        CountAfterPurchase: wd.CountAfterPurchase,
                        RemainsCountAfterPurchase: wd.RemainsCountAfterPurchase,
                        //SerialNumber: wd.SerialNumber,
                        //WriteOfDoc: wd.WriteOfDoc,
                        //WriteOfDate: [wd.WriteOfDate.Year, wd.WriteOfDate.Month, wd.WriteOfDate.Day,
                        //wd.WriteOfDate.Hour, wd.WriteOfDate.Minute, wd.WriteOfDate.Second],
                        //AcceptSets: wd.AcceptSets,
                        Comment: wd.Comment,
                        GenUnitName: wd.GenUnitName,
                        RemainsUnitName: wd.RemainsUnitName,
                        DeviceChapterId: wd.ChapterDeviceId,
                        EmpShortName: wd.EmpShortName,
                        GenUnitId: wd.GenUnitId,
                        RemUnitId: wd.RemainsUnitId,
                        EmpRespId: wd.EmpRespId
                    ))
                    .ToList(),
                AccountingDep: s.AccountingDepPart.Select(ad => new AccountingDepResponseDetails(
                        Id: ad.AccountingDepId,
                        NameBrandForUpd: ad.NameBrandForUpd,
                        CountFact: ad.CountFact,
                        PriceOnOneTax: ad.PriceOnOneTax,
                        AmountTax: ad.AmountTax,
                        Article: ad.Article,
                        AcompDoc: ad.AcompDoc,
                        DateDev: [ad.DateDev.Year, ad.DateDev.Month, ad.DateDev.Day, ad.DateDev.Hour, ad.DateDev.Minute, ad.DateDev.Second],
                        Price: ad.Price,
                        Comment: ad.Comment,
                        UnitName: ad.UnitName,
                        EmpShortName: ad.EmpShortName,
                        ChapterDeviceId: ad.ChapterDeviceId,
                        UnitId: ad.UnitId,
                        EmpRespId: ad.EmpRespId
                    ))
                    .ToList()))
            .ToList();
        return Ok(responses);
    }

    [HttpPost]
    [Authorize(Roles = "Developer,EngineerCD")]
    public async Task<ActionResult<Guid>> AddChapterDevice([FromBody] ChapterDeviceRequest request)
    {
        //var newGuid = Guid.NewGuid();
       // var newGuid = Guid.NewGuid();
        var (chd, err) = DevicesChapter.Create(
            deviceChapId: request.ChapterDeviceId,
            subChapId: request.SubChapterId,
            deviceId: request.DeviceId,
            statusId: request.StatusId,
            serialNum: request.SerialNum,
            countDevice: request.CountDevice,
            compId: request.CompId,
            compName: request.CompName,
            reqProdDate: ConvertArrDate.ArrIntToDate(request.ReqProdDate),
            dateToEdit: ConvertArrDate.ArrIntToDate(request.DateToEditing),
            dateToFill: ConvertArrDate.ArrIntToDate(request.DateToFilling)
        );
        //await _service.Add(chd);

        var guid = await _serviceChapterDevice.CreateChapterDetail(chd);

        return Ok(guid);
    }

    [HttpPut("{id:guid}")]
    [Authorize(Roles = "Developer,EngineerCD")]
    public async Task<ActionResult> UpdateChapterDevice(
        Guid id,
        [FromBody] ChapterDeviceRequest request
    )
    {
        var (chd, err) = DevicesChapter.Create(
            deviceChapId: id,
            subChapId: request.SubChapterId,
            deviceId: request.DeviceId,
            statusId: request.StatusId,
            serialNum: request.SerialNum,
            reqProdDate: ConvertArrDate.ArrIntToDate(request.ReqProdDate),
            dateToEdit: ConvertArrDate.ArrIntToDate(request.DateToEditing),
            dateToFill: ConvertArrDate.ArrIntToDate(request.DateToFilling),
            countDevice: request.CountDevice,
            compId: request.CompId,
            compName: request.CompName
        );
        await _service.Update(id, chd);
        return Ok();
    }

    [HttpPut("/updCountDevice/{id:guid}&{count:float}")]
    [Authorize(Roles = "Developer,EngineerCD,EmployeeWD,ControllerTCD,EmployeeMTS,EmployeeAD")]
    public async Task<ActionResult> UpdateChapterDeviceCountDevice(Guid id, float count)
    {
        await _serviceChapterDevice.UpdateCountDevice(id, count);
        return Ok();
    }

    [HttpPut("/updChaptDevStatus/{id:guid}&{status:guid}")]
    [Authorize(Roles = "Developer,EngineerCD,EmployeeWD,ControllerTCD,EmployeeMTS,EmployeeAD")]
    public async Task<ActionResult> UpdateChapterDeviceStatus(Guid id, Guid status)
    {
        await _serviceChapterDevice.UpdateStatus(id, status);
        return Ok();
    }

    [HttpPut("/UpdSerNum/{devceChapId:guid}&{serialNum}")]
    [Authorize(Roles = "Developer,EmployeeWD,ControllerTCD")]
    public async Task<ActionResult> UpdateSerialNumber(Guid devceChapId, string serialNum)
    {
        await _serviceChapterDevice.UpdateSerialNumber(devceChapId, serialNum);
        return Ok();
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "Developer,EngineerCD")]
    public async Task<ActionResult> DeleteChapterDevice(Guid id)
    {
        await _service.Delete(id);
        return Ok(1);
    }

}
