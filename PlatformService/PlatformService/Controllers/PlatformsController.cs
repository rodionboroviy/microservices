using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Models;
using System;
using System.Collections.Generic;

namespace PlatformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController()]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformRepo platformRepo;
        private readonly IMapper mapper;

        public PlatformsController(IPlatformRepo platformRepo,
            IMapper mapper)
        {
            this.platformRepo = platformRepo;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
        {
            Console.WriteLine("--> Getting Platforms...");

            var platforms = this.platformRepo.GetAllPlatforms();

            return Ok(this.mapper.Map<IEnumerable<PlatformReadDto>>(platforms));
        }

        [HttpGet("{id}", Name = nameof(GetPlatformById))]
        public ActionResult<PlatformReadDto> GetPlatformById(int id)
        {
            Console.WriteLine("--> Getting an individual Platform...");

            var platform = this.platformRepo.GetPlatformById(id);

            if(platform == null)
            {
                return NotFound();
            }

            return Ok(this.mapper.Map<PlatformReadDto>(platform));
        }

        [HttpPost]
        public ActionResult<PlatformReadDto> CreatePlatform(PlatformCreateDto platformCreateDto)
        {
            var platformModel = this.mapper.Map<Platform>(platformCreateDto);

            this.platformRepo.CreatePlatform(platformModel);
            this.platformRepo.SaveChanges();

            var platformReadDto = this.mapper.Map<PlatformReadDto>(platformModel);

            return CreatedAtRoute(nameof(GetPlatformById), new { Id = platformReadDto.Id }, platformReadDto);
        }
    }
}
