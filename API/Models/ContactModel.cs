using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class ContactModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; } 

        public string LastName { get; set; } 

        public string Phone { get; set; }
    }
}
