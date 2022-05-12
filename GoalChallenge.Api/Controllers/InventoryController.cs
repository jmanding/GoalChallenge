using GoalChallenge.Application.Commands.Items;
using GoalChallenge.Common.Models;
using GoalChallenge.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GoalChallenge.Api.Controllers
{
    /// <summary>
    /// Inventory operations
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        
        private readonly IMediator _mediator;
        private readonly Serilog.ILogger _logger;
        /// <summary>
        /// Inventory Controller Constructor
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="logger"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public InventoryController(IMediator mediator, Serilog.ILogger logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // GET: api/<InventoryController>
        /// <summary>
        /// Get all Items from Inventory
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<Inventory>> Get()
        {
            return await _mediator.Send(new GetAllItemsFromInvetoryCommand());
        }

        // POST api/<InventoryController>
        /// <summary>
        /// Insert a item or several items into inventory
        /// </summary>
        /// <param name="inventory"></param>
        /// <remarks> 
        /// 
        /// Sample message
        /// 
        ///     {
        ///         "name": "Invent1",
        ///         "description": "Description",
        ///         "items": [
        ///             {
        ///                 "name": "Item1",
        ///                 "expirationDate": "2022-05-16T23:13:27.576Z",
        ///                 "type": 1
        ///             },
        ///             {
        ///                 "name": "Item2",
        ///                 "expirationDate": "2022-05-26T23:13:27.576Z",
        ///                 "type": 3
        ///             }
        ///         ]
        ///      }
        /// </remarks>
        /// <returns></returns>
        [HttpPost]
        public async Task Post([FromBody] InventoryInput inventory)
        {
            try
            {
                var command = new AddItemsToInvetoryCommand(inventory);
                await _mediator.Send(command);
            }
            catch (Exception ex)
            {
                _logger.Information(ex.Message);
            }
        }

       

        // DELETE api/<InventoryController>/5
        /// <summary>
        /// Delete an item by name from inventory. If exist same item another inventory, all them will be removed
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
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
