using AutoMapper;
using AutoMapper.QueryableExtensions;
using DotNetCore_RestApi_Sqlite.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace DotNetCore_RestApi_Sqlite.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly MyContext _context;
        private readonly ILogger<ItemController> _logger;

        public ItemController(MyContext myContext, ILogger<ItemController> logger, IMapper mapper)
        {
            _context = myContext;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var items = await _context
            .Items
            .Include(item => item.SubItems)
            .ProjectTo<ItemDTO>(_mapper.ConfigurationProvider)
            .ToListAsync();
            return Ok(items);
        }
    }
}
