using System.ComponentModel.DataAnnotations;

namespace TaskManagerAPI.Models
{
    public class UserLogin
    {
        [Key]
        public Guid UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public Roles Roles { get; set; }
    }
}
