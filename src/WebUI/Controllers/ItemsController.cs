using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopBridge.Application.Common.Models;
using ShopBridge.Application.InventoryItems.Commands.CreateItem;
using ShopBridge.Application.InventoryItems.Commands.DeleteItem;
using ShopBridge.Application.InventoryItems.Commands.UpdateItem;
using ShopBridge.Application.InventoryItems.Queries.GetItemsWithPagination;

namespace ShopBridge.WebUI.Controllers;
[Authorize]
public class ItemsController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedList<ItemDto>>> GetItemsWithPagination([FromQuery] GetItemsWithPaginationQuery query)
    {
        //throw new Exception("sadasd");

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
        await Mediator.Send(new DeleteItemCommand(id));

        return NoContent();
    }
}
