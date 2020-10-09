using AutoMapper;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.TodoLists.Queries.GetItems
{
    public class ItemDto : IMapFrom<Item>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool Checked { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Item, ItemDto>();
        }
    }
}
