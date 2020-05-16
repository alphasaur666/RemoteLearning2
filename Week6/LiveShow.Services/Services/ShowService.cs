using LiveShow.Dal;
using LiveShow.Services.Models.Show;

namespace LiveShow.Services.Services
{
    public class ShowService : IShowService
    {
        private readonly IUnitOfWork unitOfWork;

        public ShowService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public ShowDto GetShow(int showId)
        {
            return new ShowDto
            {
                Id = showId
            };
        }
    }
}
