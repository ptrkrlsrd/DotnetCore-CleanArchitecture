using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Items.Commands.CreateItem;
using CleanArchitecture.Application.Items.Commands.DeleteItem;
using CleanArchitecture.Application.Items.Commands.UpdateItem;
using CleanArchitecture.Application.Items.Queries.GetItemsWithPagination;
using CleanArchitecture.Application.TodoLists.Queries.GetItems;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CleanArchitecture.API.Controllers
{
    public class ItemsController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult<PaginatedList<ItemDto>>> GetItemsWithPagination([FromQuery] GetItemsWithPaginationQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateItemCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateItemCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteItemCommand { Id = id });

            return NoContent();
        }
    }
}
