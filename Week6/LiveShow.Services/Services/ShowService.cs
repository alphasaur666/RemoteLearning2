using AutoMapper;
using LiveShow.Dal;
using LiveShow.Dal.Models;
using LiveShow.Services.Models.Show;
using LiveShow.Services.Models.User;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace LiveShow.Services.Services
{
    public class ShowService : IShowService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ShowService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ShowDto> GetShow(int showId)
        {
            var show = await unitOfWork.ShowRepository.GetAsync(s => s.Id == showId);
            var showDto = mapper.Map<ShowDto>(show);
            return showDto;            
        }
        
        public IEnumerable<ShowDto> GetAllShows()
        {
            var shows = unitOfWork.ShowRepository.GetAll();
            var showsDto = mapper.Map<IEnumerable<ShowDto>>(shows);
            return showsDto;
        }

        public IEnumerable<ShowDto> GetAllShowsByArtist(UserDto artist)
        {
            var Artist = mapper.Map<User>(artist);
            var shows = unitOfWork.ShowRepository.GetAll(u => u.Artist == Artist).GetAsyncEnumerator();
            var showsDto = mapper.Map<IEnumerable<ShowDto>>(shows);
            return showsDto;
        }

        public IEnumerable<ShowDto> GetAllShowsByVenue(string Venue)
        {
            var shows = unitOfWork.ShowRepository.GetAll(u => u.Venue == Venue ).GetAsyncEnumerator();
            var showsDto = mapper.Map<IEnumerable<ShowDto>>(shows);
            return showsDto;
        }

        public async Task<ShowDto> AddShow(ShowDto show)
        {
            var addedShow = mapper.Map<Show>(show);
            await unitOfWork.ShowRepository.AddAsync(addedShow);
            var returnedShow = mapper.Map<ShowDto>(addedShow);
            return returnedShow;

        }

        public async Task<ShowDto> UpdateShow(ShowDto show)
        {
            var showToUpdate = mapper.Map<Show>(show);
            await unitOfWork.ShowRepository.UpdateAsync(showToUpdate);

            var returnedUpdatedShow = mapper.Map<ShowDto>(showToUpdate);
            return returnedUpdatedShow;
        }

        
        public async Task<ShowDto> DeleteShow(int showId)
        {
            var show = await unitOfWork.ShowRepository.GetAsync(s => s.Id == showId);
            await unitOfWork.ShowRepository.DeleteAsync(show);
            var returnedDeletedShow = mapper.Map<ShowDto>(show);
            return returnedDeletedShow;
        }
    }
}
