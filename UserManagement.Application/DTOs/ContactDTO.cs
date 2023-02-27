using System.Collections.Generic;

namespace UserManagement.Application.DTOs
{
    public class ContactDTO
    {
        public int Id { get; set; }
        public ICollection<string> Emails { get; set; }
        public ICollection<string> Phones { get; set; }
    }
}