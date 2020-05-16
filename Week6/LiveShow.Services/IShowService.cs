using LiveShow.Services.Models.Show;

namespace LiveShow.Services
{
    public interface IShowService
    {
        ShowDto GetShow(int showId);
    }
}
