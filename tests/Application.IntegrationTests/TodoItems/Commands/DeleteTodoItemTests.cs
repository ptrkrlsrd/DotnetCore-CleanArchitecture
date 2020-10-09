using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Items.Commands.CreateItem;
using CleanArchitecture.Application.Items.Commands.DeleteItem;
using CleanArchitecture.Domain.Entities;
using FluentAssertions;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CleanArchitecture.Application.IntegrationTests.Items.Commands
{
    using static Testing;

    public class DeleteItemTests : TestBase
    {
        [Test]
        public void ShouldRequireValidItemId()
        {
            var command = new DeleteItemCommand { Id = 99 };

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<NotFoundException>();
        }

        [Test]
        public async Task ShouldDeleteItem()
        {
            var itemId = await SendAsync(new CreateItemCommand
            {
                Name = "New Item"
            });

            await SendAsync(new DeleteItemCommand
            {
                Id = itemId
            });
        }
    }
}
