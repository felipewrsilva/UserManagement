namespace UserManagement.Domain.Entities
{
    public class Phone
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public int ContactId { get; set; }
        public Contact Contact { get; set; }

        public Phone(string value)
        {
            Value = value;
        }
    }
}