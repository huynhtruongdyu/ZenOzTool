using ZenOzTool.Models.Response;

namespace ZenOzTool.Applications.Services
{
    public interface IGoldRateService
    {
        SjcGoldRateXML GetSJC();
    }
}