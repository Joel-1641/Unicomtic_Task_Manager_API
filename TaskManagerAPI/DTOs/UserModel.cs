using TaskManagerAPI.Models;

namespace TaskManagerAPI.DTOs
{
    public class UserModel
    {
        public Guid? UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Roles Role {  get; set; }


    }
}
