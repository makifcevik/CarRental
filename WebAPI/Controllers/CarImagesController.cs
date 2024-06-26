﻿using Business.Abstract;
using Core.Utilities.Helpers.FileHelpers;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;
        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] IFormFile file, [FromForm] CarImage carImage)
        {
            var result = _carImageService.Add(file, carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm] IFormFile file, [FromForm] CarImage carImage)
        {
            var result = _carImageService.Update(file, carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(CarImage carImage)
        {
            var image = _carImageService.GetByImageId(carImage.Id).Data;
            var result = _carImageService.Delete(image);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carImageService.GetByImageId(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpDelete("deletebyid")]
        public IActionResult DeleteById(int id)
        {
            var carImage = _carImageService.GetByImageId(id);
            if (carImage.Data == null)
            {
                return BadRequest(carImage);
            }

            var result = _carImageService.Delete(carImage.Data);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
