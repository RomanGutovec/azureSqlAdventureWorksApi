using AdventureWorksApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureWorksApi.Interfaces
{
    public interface IAdressService
    {
        Task<AddressModel> GetAddressAsync(int id);
        Task CreateAddressAsync(RequestAddressModel address);
    }
}
