using API.Application.Abstractions;
using API.Domain.Entities;


namespace API.Infrastructure.Persistence
{
    public class UserRepository : IUserRepository
    {
        IEnumerable<Users> users = new List<Users>();

        public UserRepository()
        {
            users = new List<Users>()
            {
                new Users(1,"Sang" , new VEmail("sang@gmail.com"), new VPassword("123456"), new VRole("Admin")),
                new Users(2,"gnas" , new VEmail("gnas@gmail.com"), new VPassword("123456"), new VRole("Seller")),
                new Users(3,"Truc" , new VEmail("truc@gmail.com"), new VPassword("123456"), new VRole("Customer")),
                new Users(4,"test" , new VEmail("user@example.com"), new VPassword("string"), new VRole("User"))
            };
        }
        public void AddUser(string name, VEmail email, VPassword password, VRole role)
        {
            throw new NotImplementedException();
        }

        public void DeteleUser(VEmail email)
        {
            throw new NotImplementedException();
        }

        public Users GetUserByEmail(VEmail email)
        {
            foreach (var user in this.users)
            {
                if (user.Email.Equals(email))
                {
                    return user;
                }
            }
            return null;
        }

        public bool UserExists(string email)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(Users user)
        {
            throw new NotImplementedException();
        }
    }
    
}