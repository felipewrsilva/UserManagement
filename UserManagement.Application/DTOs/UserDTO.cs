using System.Collections.Generic;

namespace UserManagement.Application.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
        public ICollection<DocumentDTO> Documents { get; set; }
        public ICollection<AddressDTO> Addresses { get; set; }
        public ICollection<ContactDTO> Contacts { get; set; }
    }
}