

namespace API.Domain.Entities
{
    public class Users
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public VEmail Email { get; private set; }
        public VPassword Password { get; private set; }
    }
}