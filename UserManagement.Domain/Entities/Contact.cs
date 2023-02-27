using System.Collections.Generic;

namespace UserManagement.Domain.Entities
{
    public class Contact
    {
        public int Id { get; set; }
        public ICollection<Email> Emails { get; set; }
        public ICollection<Phone> Phones { get; set; }
    }
}