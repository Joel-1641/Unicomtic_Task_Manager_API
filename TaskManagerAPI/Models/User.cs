using System.ComponentModel.DataAnnotations;

namespace TaskManagerAPI.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection <TaskItem>Tasks { get; set; } = new List<TaskItem>();
        public string Phone { get; set; }
        public Address Address { get; set; }
    }
}
