using System;

namespace Management.Customer.Service.Domain
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public Customer(Guid id, string name, string password)
        {
            Id = id;
            SetName(name);
            SetPassword(password);
        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name of the customer cannot be empty!");
            }
            Name = name;
        }

        public void SetPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Password of the customer cannot be empty!");
            }
            Password = password;
        }
    }
}
