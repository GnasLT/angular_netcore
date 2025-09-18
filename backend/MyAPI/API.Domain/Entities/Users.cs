

namespace API.Domain.Entities
{
    public class Users
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public VEmail Email { get; private set; }
        public VPassword Password { get; private set; }

        public VRole Role { get; private set; }


        public Users(Guid id, string name, VEmail email, VPassword password, VRole role)
        {
            Id = id;
            Name = name ?? throw new InvalidOperationException("Name cannot be null");
            Email = email ?? throw new InvalidOperationException("Email cannot be null");
            Password = password ?? throw new InvalidOperationException("Password cannot be null");
            Role = role;
        }

        public Users(Users user)
        {
            this.Id = user.Id;
            this.Name = user.Name;
            this.Email = user.Email;
            this.Password = user.Password;
            this.Role = user.Role;
        }


        public void SetRole(VRole role)
        {
            Role = role;
        }
        public void ChangePassword(VPassword newpassword, VPassword oldPassword)
        {
            if (!Password.Equals(oldPassword))
            {
                throw new UnauthorizedAccessException("Old password does not match.");
            }
            Password = newpassword;
        }

        public void ChangeEmail(VEmail newEmail)
        {
            Email = newEmail ?? throw new InvalidOperationException("Email cannot be null");;
        }

    }
}