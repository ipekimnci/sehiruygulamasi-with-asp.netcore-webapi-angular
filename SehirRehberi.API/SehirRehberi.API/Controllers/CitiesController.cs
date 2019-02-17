using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SehirRehberi.API.Data;
using SehirRehberi.API.Dtos;
using SehirRehberi.API.Models;

namespace SehirRehberi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private IRepository _repository;
        private IMapper _mapper;
        public CitiesController(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public ActionResult GetCities()
        {
            var cities = _repository.GetCities();
            var citiesToReturn = _mapper.Map<List<CityForListDto>>(cities);
            return Ok(citiesToReturn);
        }

        [HttpPost]
        [Route("create")]
        public ActionResult Create([FromBody]City city)
        {
            _repository.Insert(city);
            _repository.SaveAll();
            return Ok(city);
        }

        [HttpGet]
        [Route("detail")]
        public ActionResult GetCityById(int id)
        {
            var city = _repository.GetCityById(id);
            var cityToReturn = _mapper.Map<CityForDetailDto>(city);
            return Ok(cityToReturn);
        }

        [HttpGet]
        [Route("photos")]
        public ActionResult GetPhotosByCity(int cityId)
        {
            var photos = _repository.GetPhotosByCity(cityId);
            return Ok(photos);
        }
    }
}