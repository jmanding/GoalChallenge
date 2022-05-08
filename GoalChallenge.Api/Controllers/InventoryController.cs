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
        /// <summary>
        /// Get all Items from Inventory
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public dynamic Get()
        {
            return _itemQuery.GetAllItems();
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


                _logger.Information("Add Item Successful");
            }
            catch (Exception ex)
            {
                _logger.Information(ex.Message);
            }
        }

       

        // DELETE api/<InventoryController>/5
        /// <summary>
        /// Delete a item by name from inventory. If exist same item another inventory, all them will be removed
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
