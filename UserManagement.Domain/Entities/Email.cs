namespace UserManagement.Domain.Entities
{
    public class Email
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public int ContactId { get; set; }
        public Contact Contact { get; set; }

        public Email(string value)
        {
            Value = value;
        }
    }
}