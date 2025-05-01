using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestfulApi.Application.DTOs;

namespace RestfulApi.Application.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<UserDto> GetByIdAsync(int id);
        Task CreateAsync(UserDto userDto);
        Task UpdateAsync(UserDto userDto);  
        Task DeleteAsync(int id);   
    }
}
