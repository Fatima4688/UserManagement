using System.ComponentModel.DataAnnotations;

namespace Common.Models.ViewModels
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
