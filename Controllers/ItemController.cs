using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DotNetCore_RestApi_Sqlite.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase
    {
        MyContext _context { get; set; }
        private readonly ILogger<ItemController> _logger;

        public ItemController(MyContext myContext, ILogger<ItemController> logger)
        {
            _context = myContext;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Item> Get()
        {
            List<Item> items = _context.Items.ToList();
            return items;
        }
    }
}
