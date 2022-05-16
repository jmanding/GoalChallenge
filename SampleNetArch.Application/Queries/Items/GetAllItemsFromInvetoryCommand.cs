using MediatR;
using SampleNetArch.Domain.Models;

namespace SampleNetArch.Application.Queries.Items
{
    public class GetAllItemsFromInvetoryCommand : IRequest<List<Inventory>>
    {
    }
}
