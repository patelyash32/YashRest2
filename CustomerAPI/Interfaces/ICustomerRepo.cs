using CustomerAPI.Models;

namespace CustomerAPI.Interfaces
{
    public interface ICustomerRepo
    {
        Task<IEnumerable<Customer>> GetAllCustomers();
        Task<Customer> GetCustomerById(int id);
        Task AddCustomer(Customer customer);
        Task<bool> UpdateCustomer(Customer customer);
        Task<bool> DeleteCustomer(int id);
    }
}
