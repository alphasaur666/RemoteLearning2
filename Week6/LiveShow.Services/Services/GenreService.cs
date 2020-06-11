﻿using AutoMapper;
using LiveShow.Dal;
using LiveShow.Dal.Models;
using LiveShow.Services.Models.Show;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LiveShow.Services.Services
{
    public class GenreService : IGenreService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GenreService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<GenreDto> CreateGenre(GenreDto genre)
        {
            var createdGenre = mapper.Map<Genre>(genre);
            await unitOfWork.GenreRepository.AddAsync(createdGenre);

            var returnedGenre = mapper.Map<GenreDto>(createdGenre);
            return returnedGenre;
            
        }

        public IEnumerable<GenreDto> GetAllGenres()
        {
            var genres = unitOfWork.GenreRepository.GetAll();
            var genreDtos = mapper.Map<IEnumerable<GenreDto>>(genres);
            return genreDtos;
        }

        public async Task<GenreDto> UpdateGenre(GenreDto genre)
        {
            var updatedGenre = mapper.Map<Genre>(genre);
            await unitOfWork.GenreRepository.UpdateAsync(updatedGenre);

            var updatedGenreDto = mapper.Map<GenreDto>(updatedGenre);
            return updatedGenreDto;

        }

        public async Task<GenreDto> DeleteGenre(int genreId)
        {
            var genre = unitOfWork.GenreRepository.GetAsync(g => g.Id == genreId);
            var deletedGenre = mapper.Map<Genre>(genre);
            await unitOfWork.GenreRepository.DeleteAsync(deletedGenre);

            var deletedGenreDto = mapper.Map<GenreDto>(deletedGenre);
            return deletedGenreDto;
        }

    }
}