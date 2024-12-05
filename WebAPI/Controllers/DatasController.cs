using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Services;
using Domain.Models;
using Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class DatasController : ControllerBase
    {
        private readonly IDataService _dataService;

        public DatasController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Data>> GetDatas()
        {
            return _dataService.GetDatas();
        }

        [HttpPost(Name = "SaveData")]
        public async Task<ActionResult> SaveDataAsync(Data data)
        {
            await _dataService.SaveDataAsync(data);
            return CreatedAtAction("SaveData", data);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateDataAsync(int id, Data data)
        {
            if (id != data.Id)
            {
                return BadRequest();
            }
            await _dataService.UpdateDataAsync(data);
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> RemoveDataAsync(int id)
        {
            await _dataService.RemoveDataAsync(id);
            return NoContent();
        }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class EdataController : ControllerBase
    {
        private readonly EdataService _edataService;

        public EdataController(EdataService edataService)
        {
            _edataService = edataService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Edata>>> GetAllEdata()
        {
            return await _edataService.GetAllEdataAsync();
        }

        [HttpPost]
        public async Task<IActionResult> AddEdata([FromBody] Edata edata)
        {
            if (edata == null)
            {
                return BadRequest();
            }

            var createdEdata = await _edataService.AddEdataAsync(edata);
            return CreatedAtAction(nameof(GetEdataById), new { id = createdEdata.Environmentid }, createdEdata);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEdataById(int id)
        {
            var edata = await _edataService.GetEdataByIdAsync(id);
            if (edata == null)
            {
                return NotFound();
            }

            return Ok(edata);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEdata(int id, [FromBody] Edata edata)
        {
            if (id != edata.Environmentid)
            {
                return BadRequest();
            }

            await _edataService.UpdateEdataAsync(edata);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEdata(List<Edata> edataList)
        {
            foreach (var edata in edataList)
            {
                await _edataService.UpdateEdataAsync(edata);
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEdata(int id)
        {
            var edata = await _edataService.GetEdataByIdAsync(id);
            if (edata == null)
            {
                return NotFound();
            }

            await _edataService.DeleteEdataAsync(id);
            return NoContent();
        }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class GreenHouseController : ControllerBase
    {
        private readonly EdataService _edataService;

        public GreenHouseController(EdataService edataService)
        {
            _edataService = edataService;
        }

        [HttpGet]
        public async Task<ActionResult<List<GreenHouse>>> GetAllGreenHouse()
        {
            return await _edataService.GetAllGreenHouseAsync();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateGreenHouse(List<GreenHouse> greenHouseList)
        {
            foreach (var greenhouse in greenHouseList)
            {
                await _edataService.UpdateGreenHouseAsync(greenhouse);
            }
            return NoContent();
        }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class WaterController : ControllerBase
    {
        private readonly EdataService _edataService;

        public WaterController(EdataService edataService)
        {
            _edataService = edataService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Water>>> GetAllWater()
        {
            return await _edataService.GetAllWaterAsync();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateWater(List<Water> waterList)
        {
            foreach (var water in waterList)
            {
                await _edataService.UpdateWater(water);
            }
            return NoContent();
        }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class WasteController : ControllerBase
    {
        private readonly EdataService _edataService;

        public WasteController(EdataService edataService)
        {
            _edataService = edataService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Waste>>> GetAllWaste()
        {
            return await _edataService.GetAllWasteAsync();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateWaste(List<Waste> wasteList)
        {
            foreach (var waste in wasteList)
            {
                await _edataService.UpdateWaste(waste);
            }
            return NoContent();
        }
    }
}