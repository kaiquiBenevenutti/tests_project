using ConsoleApp1; // ou o namespace correto do AppDbContext e UserService
using Microsoft.EntityFrameworkCore;
using Xunit;

public class UserServiceTests
{
    private UserService GetInMemoryUserService()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        var context = new AppDbContext(options);
        return new UserService(context);
    }

    [Fact]
    public async Task AddUser_ShouldAddUserToDatabase()
    {
        // Arrange
        var service = GetInMemoryUserService();

        // Act
        await service.AddUserAsync("testuser", "password123");

        // Assert
        var user = await service.GetUserByUsernameAsync("testuser");
        Assert.NotNull(user);
        Assert.Equal("testuser", user.Username);
    }
}
