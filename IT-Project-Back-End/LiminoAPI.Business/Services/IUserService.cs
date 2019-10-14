using System.Collections.Generic;
using LiminoAPI.Data.Models;

namespace LiminoAPI.Business.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        IEnumerable<UserDTO> GetAll();
        UserDTO GetById(long id);
        long Create(UserDTO user);
        void Update(long id, UserDTO user);
        void Delete(long id);
    }
}