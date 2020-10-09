using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Items.Commands.CreateItem;
using CleanArchitecture.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.IntegrationTests.Items.Commands
{
    using static Testing;

    public class CreateItemTests : TestBase
    {
        [Test]
        public void ShouldRequireMinimumFields()
        {
            var command = new CreateItemCommand();

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<ValidationException>();
        }

        [Test]
        public async Task ShouldCreateItem()
        {
            var userId = await RunAsDefaultUserAsync();

            var command = new CreateItemCommand
            {
                Name = "Tasks"
            };

            var itemId = await SendAsync(command);

            var item = await FindAsync<Item>(itemId);

            item.Should().NotBeNull();
            item.Name.Should().Be(command.Name);
            item.CreatedBy.Should().Be(userId);
            item.Created.Should().BeCloseTo(DateTime.Now, 10000);
            item.LastModifiedBy.Should().BeNull();
            item.LastModified.Should().BeNull();
        }
    }
}
