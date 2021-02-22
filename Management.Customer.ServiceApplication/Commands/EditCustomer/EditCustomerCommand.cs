using System;
using Management.Common;

namespace Management.Customer.Service.Application.Commands.EditCustomer
{
    public class EditCustomerCommand : ICommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public EditCustomerCommand(Guid id, string name, string password)
        {
            Id = id;
            Name = name;
            Password = password;
        }
    }
}
