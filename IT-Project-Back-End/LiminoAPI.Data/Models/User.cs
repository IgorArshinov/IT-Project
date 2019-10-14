namespace LiminoAPI.Data.Models
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Role { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        
    }
}