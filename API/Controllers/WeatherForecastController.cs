using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly DataContext _context;
         private readonly ILogger<WeatherForecastController> _logger;
        public WeatherForecastController(DataContext context, ILogger<WeatherForecastController> logger)
        {
            _context = context;
            _logger = logger;
            
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Value>>> Get()
        {
           return  Ok( await _context.Values.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Value>> Get(int id)
        {
            var value = await _context.Values.FindAsync(id);
            return Ok(value);
        }
    }
}
