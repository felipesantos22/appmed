using appmed.Application.Controllers;
using appmed.Domain.Entities;
using appmed.Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

public class DoctorControllerTests
{
    [Fact]
    public async Task Create_ValidDoctor_ReturnsOkResult()
    {
        // Arrange
        var mockRepository = new Mock<DoctorRepository>();
        var controller = new DoctorController(mockRepository.Object);

        var newDoctor = new Doctor { Name = "Dr. John", CRM = "123456" };

        mockRepository.Setup(repo => repo.Create(It.IsAny<Doctor>()))
            .ReturnsAsync(newDoctor);

        // Act
        var result = await controller.Create(newDoctor);

        // Assert
        var actionResult = Assert.IsType<OkObjectResult>(result.Result);
        var createdDoctor = Assert.IsType<Doctor>(actionResult.Value);
        Assert.Equal(newDoctor, createdDoctor);
    }

    [Fact]
    public async Task Index_ReturnsListOfDoctors()
    {
        // Arrange
        var mockRepository = new Mock<DoctorRepository>();
        var controller = new DoctorController(mockRepository.Object);

        var expectedDoctors = new List<Doctor>
        {
            new Doctor { Id = 1, Name = "Dr. Smith", CRM = "123456" },
            new Doctor { Id = 2, Name = "Dr. Johnson", CRM = "654321" }
        };

        mockRepository.Setup(repo => repo.Index())
            .ReturnsAsync(expectedDoctors);

        // Act
        var result = await controller.Index();

        // Assert
        var actionResult = Assert.IsType<OkObjectResult>(result.Result);
        var actualDoctors = Assert.IsAssignableFrom<List<Doctor>>(actionResult.Value);
        Assert.Equal(expectedDoctors, actualDoctors);
    }
}