using GoalChallenge.Api.Models;
//using GoalChallenge.Api.Query.Queries.Items;
using GoalChallenge.Application.Commands.Items;
using GoalChallenge.Application.Queries;
using GoalChallenge.Infrastructure.Data.Repositories.Items;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GoalChallenge.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ItemController : ControllerBase
    {
        //        private readonly IItemQuery _itemQuery;
        private readonly IItemQuery _itemQuery;
        private readonly IMediator _mediator;
        public ItemController(IMediator mediator, IItemQuery itemQuery)
        {
            //_itemQuery = itemQuery ?? throw new ArgumentNullException(nameof(itemQuery));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _itemQuery = itemQuery ?? throw new ArgumentNullException(nameof(itemQuery));
        }


        // GET: api/<ItemController>
        [HttpGet]
        public dynamic GetAll()
        {
            return _itemQuery.GetAllItems();
            //return await _itemQuery.GetAllItems();
        }

        // GET api/<ItemController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ItemController>
        [HttpPost]
        public async Task Post([FromBody] ItemInput itemInput)
        {
            var command = new AddItemCommand(itemInput.Name, itemInput.ExpirationDate, itemInput.Type);

            await _mediator.Send(command);
        }

        // PUT api/<ItemController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ItemController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
