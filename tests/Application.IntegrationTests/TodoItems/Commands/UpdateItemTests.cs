using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Items.Commands.CreateItem;
using CleanArchitecture.Application.Items.Commands.UpdateItem;
using CleanArchitecture.Domain.Entities;
using FluentAssertions;
using System.Threading.Tasks;
using NUnit.Framework;
using System;

namespace CleanArchitecture.Application.IntegrationTests.Items.Commands
{
    using static Testing;

    public class UpdateItemTests : TestBase
    {
        [Test]
        public void ShouldRequireValidItemId()
        {
            var command = new UpdateItemCommand
            {
                Id = 99,
                Name = "New Title"
            };

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<NotFoundException>();
        }

        [Test]
        public async Task ShouldUpdateItem()
        {
            var userId = await RunAsDefaultUserAsync();


            var itemId = await SendAsync(new CreateItemCommand
            {
                Name = "New Item"
            });

            var command = new UpdateItemCommand
            {
                Id = itemId,
                Name = "Updated Item Title"
            };

            await SendAsync(command);

            var item = await FindAsync<Item>(itemId);

            item.Name.Should().Be(command.Name);
            item.LastModifiedBy.Should().NotBeNull();
            item.LastModifiedBy.Should().Be(userId);
            item.LastModified.Should().NotBeNull();
            item.LastModified.Should().BeCloseTo(DateTime.Now, 1000);
        }
    }
}
