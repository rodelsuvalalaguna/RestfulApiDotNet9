using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using RestfulApi.Application.DTOs;
using RestfulApi.Application.Interfaces;
using RestfulApi.Domain.Models;

namespace RestfulApi.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
           => _mapper.Map<IEnumerable<UserDto>>(await _repo.GetAllAsync());

        public async Task<UserDto> GetByIdAsync(int id)
            => _mapper.Map<UserDto>(await _repo.GetByIdAsync(id));

        public async Task CreateAsync(UserDto dto)
            => await _repo.AddAsync(_mapper.Map<User>(dto));

        public async Task UpdateAsync(UserDto dto)
            => await _repo.UpdateAsync(_mapper.Map<User>(dto));

        public async Task DeleteAsync(int id) => await _repo.DeleteAsync(id);
    }
}
