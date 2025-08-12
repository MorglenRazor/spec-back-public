using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Specification.API.Contracts.DeviceContract;
using Specification.Core.Abstractions.Service;
using Specification.Core.Models;

namespace Specification.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeviceController : Controller
    {
        private readonly ITableService<Device> _deviceService;
        private readonly IDeviceService _serv;

        public DeviceController(ITableService<Device> deviceService, IDeviceService serv)
        {
            _deviceService = deviceService;
            _serv = serv;
        }

        /// <summary>
        /// Http запрос на получения списка устройств
        /// </summary>
        /// <returns>Список устройств</returns>
        [HttpGet]
        [Authorize(Roles = "Developer,User")]
        public async Task<ActionResult<List<DeviceResponse>>> GetDevice()
        {
            List<Device> devices = await _deviceService.Get(Guid.Empty);
            List<DeviceResponse> responses = devices
                .Select(s => new DeviceResponse(
                    DeviceId: s.DeviceId,
                    Name: s.Name,
                    BrandName: s.BrandName,
                    CategoryId: s.CategoryDeviceId
                ))
                .ToList();
            return Ok(responses);
        }

        /// <summary>
        /// Http запрос на получения списка устройств
        /// </summary>
        /// <returns>Список устройств</returns>
        [HttpGet("/Device/{id:guid}")]
        [Authorize(Roles = "Developer,User")]
        public async Task<ActionResult<List<DeviceResponse>>> GetDevice(Guid id)
        {
            List<Device> devices = await _deviceService.Get(id);
            List<DeviceResponse> responses = devices
                .Select(s => new DeviceResponse(
                    DeviceId: s.DeviceId,
                    Name: s.Name,
                    BrandName: s.BrandName,
                    CategoryId: s.CategoryDeviceId
                ))
                .ToList();
            return Ok(responses);
        }

        /// <summary>
        /// Http запрос на получения списка устройств
        /// </summary>
        /// <returns>Список устройств</returns>
        [HttpGet("/Device/GetFilt/{ctId:guid}")]
        [Authorize(Roles = "Developer,User")]
        public async Task<ActionResult<List<DeviceResponse>>> GetFilt(Guid? ctId, Guid? subCtId = null)
        {
            List<Device> devices = await _serv.GetFilt(ctId, subCtId);
            List<DeviceResponse> responses = devices
                .Select(s => new DeviceResponse(
                    DeviceId: s.DeviceId,
                    Name: s.Name,
                    BrandName: s.BrandName,
                    CategoryId: s.CategoryDeviceId
                ))
                .ToList();
            return Ok(responses);
        }

        /// <summary>
        /// Http запрос на Добавление нового устройства
        /// </summary>
        /// <param name="request">Данные с клиента</param>
        /// <returns>Ответ сервера(100,200,300,400,500)</returns>
        [HttpPost]
        [Authorize(Roles = "Developer,Admin,EngineerCD")]
        public async Task<ActionResult<Guid>> AddDevice([FromBody] DeviceRequest request)
        {
            var newGuid = Guid.NewGuid();
            var (dev, err) = Device.Create(
                id: newGuid,
                name: request.Name,
                brandName: request.BrandName,
                categoryId: request.CategoryId
            );
            await _deviceService.Add(dev);
            return Ok(newGuid);
        }

        /// <summary>
        /// Http запрос на Обновление существующего устройства
        /// </summary>
        /// <param name="id">Индификатор обновляемой записи</param>
        /// <param name="request">Данные с клиенета</param>
        /// <returns>Ответ сервера(100,200,300,400,500)</returns>
        [HttpPut("{id:guid}")]
        [Authorize(Roles = "Developer,Admin")]
        public async Task<ActionResult> UpdateDevice(Guid id, [FromBody] DeviceRequest request)
        {
            var (dev, err) = Device.Create(
                id: id,
                name: request.Name,
                brandName: request.BrandName,
                categoryId: request.CategoryId
            );
            await _deviceService.Update(id, dev);
            return Ok();
        }

        /// <summary>
        /// Http запрос на удаление существующего устройства
        /// </summary>
        /// <param name="id">Индификатор удаляемой записи</param>
        /// <returns>Ответ сервера(100,200,300,400,500)</returns>
        [HttpDelete("{id:guid}")]
        [Authorize(Roles = "Developer,Admin")]
        public async Task<ActionResult> DeleteDevice(Guid id)
        {
            await _deviceService.Delete(id);
            return Ok();
        }
    }
}
