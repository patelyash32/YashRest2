using CustomerAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CustomerAPI.Models
{
    

    public class CustomerRepo : ICustomerRepo
    {
        private readonly DataContext _context;

        public CustomerRepo(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task AddCustomer(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateCustomer(Customer customer)
        {
            _context.Customers.Update(customer);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null) return false;

            _context.Customers.Remove(customer);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }

}
