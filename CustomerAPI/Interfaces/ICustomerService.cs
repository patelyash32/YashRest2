using CustomerAPI.Models;

namespace CustomerAPI.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDto>> GetAllCustomers();
        Task<CustomerDto> GetCustomerById(int id);
        Task<int> CreateCustomer(CustomerDto customerDto);
        Task<bool> UpdateCustomer(CustomerDto customerDto);
        Task<bool> DeleteCustomer(int id);
    }
}
