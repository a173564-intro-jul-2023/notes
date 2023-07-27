using Alba;
using EmployeeDirectoryApi.Controllers;
using EmployeeDirectoryApi.Models;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace EmployeeDirectoryApi.ContractTests.OnCallDeveloper;



public class GettingTheOnCallDeveloper
{
    [Fact]
    public async Task MakingTheDuringBusinessRequest()
    {
        // Given
        await using var host = await AlbaHost.For<Program>(builder =>
        {
            builder.ConfigureServices(services =>
            {
                var stubbedClock = new Mock<IProvideTheBusinessClock>();
                stubbedClock.Setup(x => x.AreWeOpen()).Returns(true);
                services.AddSingleton<IProvideTheBusinessClock>(stubbedClock.Object);
            });
        });
        var expectedOnCallDeveloper = new OnCallDeveloperResponseModel
        {
            Name = "Eli",
            Email = "eli@aol.com",
            PhoneNumber = "555-1212"
        };



        var responseMessage = await host.Scenario(api =>
        {
            api.Get.Url("/on-call-developer");
            api.StatusCodeShouldBeOk();



        });



        var response = responseMessage.ReadAsJson<OnCallDeveloperResponseModel>();
        Assert.NotNull(response);



        Assert.Equal(expectedOnCallDeveloper, response);
    }



    [Fact]
    public async Task MakingTheRequestOutsideBusinessHours()
    {
        // Given
        await using var host = await AlbaHost.For<Program>(builder =>
        {
            builder.ConfigureServices(services =>
            {
                var stubbedClock = new Mock<IProvideTheBusinessClock>();
                stubbedClock.Setup(x => x.AreWeOpen()).Returns(false);
                services.AddSingleton<IProvideTheBusinessClock>(stubbedClock.Object);
            });
        });
        var expectedOnCallDeveloper = new OnCallDeveloperResponseModel
        {
            Name = "Becky",
            Email = "becky@aol.com",
            PhoneNumber = "555-9999"
        };



        var responseMessage = await host.Scenario(api =>
        {
            api.Get.Url("/on-call-developer");
            api.StatusCodeShouldBeOk();



        });



        var response = responseMessage.ReadAsJson<OnCallDeveloperResponseModel>();
        Assert.NotNull(response);



        Assert.Equal(expectedOnCallDeveloper, response);
    }
}
