

namespace API.Domain.Entities
{
    public class Users
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public VEmail Email { get; private set; }
        public VPassword Password { get; private set; }

        public VRole Role { get; private set; }

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