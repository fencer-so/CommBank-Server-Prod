using CommBank.Controllers;
using CommBank.Services;
using CommBank.Models;
using Microsoft.AspNetCore.Mvc;

namespace CommBank.Tests;

public class GoalControllerTests
{
    [Fact]
    public async void GetAll()
    {
        // Arrange
        var goalOne = new Goal() { Id = "1", Name = "House" };
        var goalTwo = new Goal() { Id = "2", Name = "Vacation" };

        var goals = new List<Goal>()
        {
            goalOne,
            goalTwo
        };

        IGoalsService service = new FakeGoalsService(goals, goalOne);
        GoalController controller = new GoalController(service);

        // Act
        var httpContext = new Microsoft.AspNetCore.Http.DefaultHttpContext();
        controller.ControllerContext.HttpContext = httpContext;

        var result = await controller.Get();

        // Assert
        var index = 0;

        foreach (Goal goal in result)
        {
            Assert.IsAssignableFrom<Goal>(goal);
            Assert.Equal(goals[index].Id, goal.Id);
            Assert.Equal(goals[index].Name, goal.Name);

            index++;
        }
    }

    [Fact]
    public async void Get()
    {
        // Arrange
        var goalOne = new Goal() { Id = "1", Name = "House" };
        var goalTwo = new Goal() { Id = "2", Name = "Vacation" };

        var goals = new List<Goal>()
        {
            goalOne,
            goalTwo
        };

        IGoalsService service = new FakeGoalsService(goals, goalOne);
        GoalController controller = new GoalController(service);

        // Act
        var httpContext = new Microsoft.AspNetCore.Http.DefaultHttpContext();
        controller.ControllerContext.HttpContext = httpContext;

        var result = await controller.Get("1");

        // Assert

        Assert.IsAssignableFrom<Goal>(result.Value);
        Assert.Equal(goalOne, result.Value);
        Assert.NotEqual(goalTwo, result.Value);
    }
}
