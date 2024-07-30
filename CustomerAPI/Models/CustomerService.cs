using AutoMapper;
using CustomerAPI.Interfaces;

namespace CustomerAPI.Models
{
   

    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepo _customerRepo;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepo customerRepo, IMapper mapper)
        {
            _customerRepo = customerRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustomerDto>> GetAllCustomers()
        {
            var customers = await _customerRepo.GetAllCustomers();
            return _mapper.Map<IEnumerable<CustomerDto>>(customers);
        }

        public async Task<CustomerDto> GetCustomerById(int id)
        {
            var customer = await _customerRepo.GetCustomerById(id);
            return _mapper.Map<CustomerDto>(customer);
        }

        public async Task<int> CreateCustomer(CustomerDto customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);
            await _customerRepo.AddCustomer(customer);
            return customer.Id;
        }

        public async Task<bool> UpdateCustomer(CustomerDto customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);
            return await _customerRepo.UpdateCustomer(customer);
        }

        public async Task<bool> DeleteCustomer(int id)
        {
            return await _customerRepo.DeleteCustomer(id);
        }
    }

}
