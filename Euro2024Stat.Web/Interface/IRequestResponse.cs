using Euro2024Stat.Web.Models;

namespace Euro2024Stat.Web.Interface
{
    public interface IRequestResponse
    {
        Task<ResponseDto?> SendAsync(RequestDto requestDto, bool JWT = true);

    }
}
