using FirstApp.Models;

namespace FirstApp.Services;

public class StatusService
{
    public StatusResponseModel GetCurrentStatus()
    {
        return new StatusResponseModel();
    }
}

