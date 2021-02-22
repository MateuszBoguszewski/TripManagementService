using Management.Common;

namespace Management.Customer.Service.Application.Commands.CreateCustomer
{
    public class CreateCustomerCommand : ICommand
    {
        public string Name { get; set; }
        public string Password { get; set; }

        public CreateCustomerCommand(string name, string password)
        {
            Name = name;
            Password = password;
        }
    }
}
