using CustomerMicroService.Models;

namespace CustomerMicroService.Repository
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetCustomers();
        Customer GetCustomerById(int customer);
        void InsertCustomert(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(int CustomerId);
    }
}
