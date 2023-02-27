using AutoMapper;
using FluentValidation;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.Application.DTOs;
using UserManagement.Application.Interfaces;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Interfaces.Repositories;

namespace UserManagement.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        private readonly IValidator<UserDTO> _validator;

        public UserService(IUserRepository userRepository, IMapper mapper, IValidator<UserDTO> userValidator)
        {
            _repository = userRepository;
            _mapper = mapper;
            _validator = userValidator;
        }

        public async Task<UserDTO> GetByIdAsync(int id)
        {
            var user = await _repository.GetByIdAsync(id);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<IEnumerable<UserDTO>> GetAllAsync()
        {
            var users = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserDTO>>(users);
        }

        public async Task<UserDTO> CreateAsync(UserDTO userDTO)
        {
            await _validator.ValidateAndThrowAsync(userDTO);
            var user = _mapper.Map<User>(userDTO);
            var createdUser = await _repository.CreateAsync(user);
            return _mapper.Map<UserDTO>(createdUser);
        }

        public async Task UpdateAsync(UserDTO userDTO)
        {
            await _validator.ValidateAndThrowAsync(userDTO);
            var user = _mapper.Map<User>(userDTO);
            await _repository.UpdateAsync(user);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}