
using API.Domain.Entities;

namespace API.Application.Abstractions
{
    public interface IUserRepository
    {

        public void AddUser(string name, VEmail email, VPassword password, VRole role);

        public bool UserExists(string email);

        public Users GetUserByEmail(VEmail email);

        public void DeteleUser(VEmail email);

        public void UpdateUser(Users user);

    }
}