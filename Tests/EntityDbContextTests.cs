﻿using Microsoft.EntityFrameworkCore;
using System.Linq;
using Xunit;
using Teams.Models.Entities;

namespace Tests
{
    public class EntityDbContextTests : IClassFixture<EntityDbContextTestsClassSetupFixture>
    {
        private readonly EntityDbContextTestsClassSetupFixture _testContext;
        public EntityDbContextTests(EntityDbContextTestsClassSetupFixture testContext)
        {
            _testContext = testContext;
        }

        [Fact]
        public void AddMessageTest()
        {
            //Arrange
            var messageEntity = new Message
            {
                Title = "testsMessage",
                Text = "testText"
            };

            //Act
            _testContext.EntityDbContextSUT.Messages.Add(messageEntity);
            _testContext.EntityDbContextSUT.SaveChanges();


            //Assert
            using (var dbx = _testContext.CreateEntityDbContext())
            {
                var retrievedMessage = dbx.Messages.First(entity => entity.Id == messageEntity.Id);

                // use this if possible // TODO to repair for greater precision
                // Assert.Equal(messageEntity, retrievedMessage, messageEntity.DescriptionNameIdComparer);

               Assert.Equal(messageEntity.Id, retrievedMessage.Id);
            }
        }

    }
}
