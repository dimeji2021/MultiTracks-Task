﻿using Microsoft.AspNetCore.Mvc;
using MultiTracks.API.Controllers;
using MultiTracks.API.Domain.Core.Services.IService;
using MultiTracks.API.Domain.Models.Dtos;
using MultiTracks.API.Infrastructure.IRepositories;
using Serilog;

namespace MultiTracksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        private readonly ISongService _songService;
        private readonly ILogger<SongController> _log;

        public SongController(ISongService songService, ILogger<SongController> log)
        {
            _songService = songService;
            _log = log;
        }

        [HttpGet, Route("list")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get([FromQuery] RequestParam requestParam)
        {
            _log.LogInformation("Executing Get Songs endpoint..............");

            var songs = await _songService.GetAllSongsAsync(requestParam);
            if (songs is not null)
            {
                _log.LogInformation("Get Songs Endpoint executed successfully.........");
                return Ok(songs);
            }
            _log.LogError("Bad request, error occur While trying to list songs");
            return BadRequest();
        }
    }
}
