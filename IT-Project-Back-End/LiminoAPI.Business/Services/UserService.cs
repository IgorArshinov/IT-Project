using System;
using System.Collections.Generic;
using System.Linq;
using LiminoAPI.Data.Models;
using LiminoAPI.Data.Repositories.Interfaces;

namespace LiminoAPI.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IBaseRepository<User> _repository;

        public UserService(IBaseRepository<User> repository)
        {
            _repository = repository;
        }
        
        public User Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var user = _repository.GetAllWhere(x => x.Username == username);

            if (user == null)
                return null;

            return !VerifyPasswordHash(password, user.FirstOrDefault().PasswordHash, user.FirstOrDefault().PasswordSalt) ? null : user.FirstOrDefault();
        }

        public IEnumerable<UserDTO> GetAll()
        {
            return MapEntityListToDtoList(_repository.GetAll());
        }

        public UserDTO GetById(long id)
        {
            var user = _repository.GetById(id);
            UserDTO userDTO = MapEntityToDTO(user);
            
            return userDTO;
        }

        public long Create(UserDTO userDTO)
        {
            var user = MapDTOtoEntity(userDTO);
            
            if(string.IsNullOrWhiteSpace(userDTO.Password))
                throw new Exception("Password is required");

            if (_repository.GetAll().Any(x => x.Username == user.Username))
                throw new Exception("This username is already taken");
            
            CreatePasswordHash(userDTO.Password, out var passwordHash, out var passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _repository.Add(user);
            
            return user.Id;
        }

        public void Update(long id, UserDTO userParam)
        {
            var user = _repository.GetById(id);
            
            if(user == null)
                throw new Exception("user not found");

            if (_repository.GetAll().Any(x => x.Username == userParam.Username))
            {
                throw new Exception("This username is already taken");
            }
            user.Username = userParam.Username;

            _repository.Update(user);

        }

        public void Delete(long id)
        {
            var user = _repository.GetById(id);

            if (user != null)
            {
                _repository.Delete(user);
            }
        }
        
        private static bool VerifyPasswordHash(string password, IReadOnlyList<byte> storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Count != 64)
                throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128)
                throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                if (computedHash.Where((t, i) => t != storedHash[i]).Any())
                {
                    return false;
                }
            }

            return true;
        }
        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        
        private static IEnumerable<UserDTO> MapEntityListToDtoList(IEnumerable<User> users)
        {
            return users.Select(user => new UserDTO()
            {
                Id = user.Id,
                Username = user.Username,
                Role = user.Role
            }).ToList();
        }

        private static UserDTO MapEntityToDTO(User user)
        {
            return new UserDTO
            {
                Id = user.Id,
                Username = user.Username,
                Role = user.Role
            };
        }

        private static User MapDTOtoEntity(UserDTO userDTO)
        {
            return new User
            {
                Id = userDTO.Id,
                Username = userDTO.Username,
                Role = userDTO.Role
            };
        }
    }
}