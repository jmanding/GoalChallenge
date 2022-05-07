using GoalChallenge.Application.Commands.Items;
using GoalChallenge.Application.Queries;
using GoalChallenge.Common.Models;
using GoalChallenge.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GoalChallenge.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IItemQuery _itemQuery;
        private readonly IMediator _mediator;
        private readonly Serilog.ILogger _logger;
        public InventoryController(IMediator mediator, IItemQuery itemQuery, Serilog.ILogger logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _itemQuery = itemQuery ?? throw new ArgumentNullException(nameof(itemQuery));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // GET: api/<InventoryController>
        [HttpGet]
        public dynamic Get()
        {
            return _itemQuery.GetAllItems();
        }

        // GET api/<InventoryController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<InventoryController>
        [HttpPost]
        public async Task Post([FromBody] InventoryInput inventory)
        {
            try
            {
                var command = new AddItemsToInvetoryCommand(inventory);
                await _mediator.Send(command);


                _logger.Information("Add Item Successful");
            }
            catch (Exception ex)
            {
                _logger.Information(ex.Message);
            }
        }

        // PUT api/<InventoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<InventoryController>/5
        [HttpDelete("{name}")]
        public async Task Delete(string name)
        {
            try
            {
                var command = new RemoveItemFromInventoryByNameCommand(name);
                await _mediator.Send(command);
            }
            catch (Exception ex)
            {
                _logger.Information(ex.Message);
            }
        }
    }
}
