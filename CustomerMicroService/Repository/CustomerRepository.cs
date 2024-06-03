using CustomerMicroService.Data;
using CustomerMicroService.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerMicroService.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerDbContext _dbContext;

        public CustomerRepository(CustomerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeleteCustomer(int CustomerId)
        {
            var customer = _dbContext.customers.Find(CustomerId);
            if (customer != null)
            {
                _dbContext.customers.Remove(customer);
                _dbContext.SaveChanges();
            }
        }

        public Customer GetCustomerById(int customer)
        {
            return _dbContext.customers.Find(customer);
        }

        public IEnumerable<Customer> GetCustomers()
        {
            var customers = _dbContext.customers.ToList();
            return customers;
        }

        public void InsertCustomert(Customer customer)
        {
            _dbContext.customers.Add(customer);
            _dbContext.SaveChanges();
        }

        public void UpdateCustomer(Customer customer)
        {
            _dbContext.Entry(customer).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
