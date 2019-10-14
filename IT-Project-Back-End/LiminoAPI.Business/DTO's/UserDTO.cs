namespace LiminoAPI.Business
{
    public class UserDTO
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        
        public override bool Equals(object obj)
        {
            if (!(obj is UserDTO userDto))
            {
                return false;
            }
            return Id.Equals(userDto.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}