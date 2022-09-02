using AutoMapper;
using FindMyPG.Controllers.Base;
using FindMyPG.Core.Entities;
using FindMyPG.Models;
using FindMyPG.Service.Cities;
using FindMyPG.Service.States;
using Microsoft.AspNetCore.Mvc;

namespace FindMyPG.Controllers
{
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class CityController : BaseController
    {
        private readonly ICityService _cityService;
        private readonly IMapper _mapper;
        public CityController(ICityService cityService, IMapper mapper)
        {
            _cityService = cityService;
            _mapper = mapper;   
        }
        [HttpGet]
        [Route("")]
        public IActionResult GetAllCities()
        {
            var cities = _cityService.GetAllCities();
            var cityModels = _mapper.Map<List<CityModel>>(cities);
            return Ok(cityModels);
        }
        [HttpGet]
        [Route("Active")]
        public IActionResult GetAllActiveCities()
        {
            var activeCities = _cityService.GetAllActiveCities();
            var cityModels = _mapper.Map<List<CityModel>>(activeCities);
            return Ok(cityModels);
        }
        [HttpGet]
        [Route("state/{stateId}")]
        public IActionResult GetAllActiveCityByStateId(int stateId)
        {
            var cityModels = _mapper
                .Map<List<CityModel>>(_cityService.GetAllActiveCityByStateId(stateId));
            return Ok(cityModels);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetCityById(int id)
        {
            var City=_cityService.GetCityById(id);
            var cityModel=_mapper.Map<CityModel>(City);
            return Ok(cityModel);
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateCity(int id, CityModelRequest request)
        {
            var city = _cityService.GetCityById(id);
            if (city != null)
            {
                city.Name = request.CityName;
                city.IsActive = request.IsActive;

                _cityService.UpdateCity(city);
                return Ok(city);
            }
            return BadRequest("City not Exist!..");
        }
    }
}
