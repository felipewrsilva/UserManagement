using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.Application.DTOs;

namespace UserManagement.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> GetByIdAsync(int id);
        Task<IEnumerable<UserDTO>> GetAllAsync();
        Task<UserDTO> CreateAsync(UserDTO userDTO);
        Task UpdateAsync(UserDTO userDTO);
        Task DeleteAsync(int id);
    }
}