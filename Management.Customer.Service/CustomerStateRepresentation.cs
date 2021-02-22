namespace Management.Customer.Service
{
    public class CustomerStateRepresentation
    {
        public string Name { get; set; }
        public string Password { get; set; }

        public CustomerStateRepresentation(string name, string password)
        {
            Name = name;
            Password = password;
        }

        public CustomerStateRepresentation()
        {
        }
    }
}
