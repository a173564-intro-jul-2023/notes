using EmployeeDirectoryApi.Models;
using Microsoft.AspNetCore.Mvc;



namespace EmployeeDirectoryApi.Controllers;



public class OnCallDeveloperController : ControllerBase
{
    private readonly IProvideTheBusinessClock _businessClock;

    public OnCallDeveloperController(IProvideTheBusinessClock businessClock)
    {
        _businessClock = businessClock;
    }

    [HttpGet("/on-call-developer")]
    public async Task<ActionResult> Get()
    {
        bool isDuringBusinessHours = _businessClock.AreWeOpen();
        OnCallDeveloperResponseModel response;
        if (isDuringBusinessHours)
        {
            response = new OnCallDeveloperResponseModel
            {
                Name = "Eli",
                PhoneNumber = "555-1212",
                Email = "eli@aol.com"
            };
        }
        else
        {
            response = new OnCallDeveloperResponseModel
            {
                Name = "Becky",
                PhoneNumber = "555-9999",
                Email = "becky@aol.com"
            };
        }



        return Ok(response);
    }
}
