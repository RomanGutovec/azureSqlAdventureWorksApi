using AdventureWorksApi.EF.Context;
using AdventureWorksApi.EF.Models;
using AdventureWorksApi.Interfaces;
using AdventureWorksApi.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace AdventureWorksApi.Services
{
    public class AddressService : IAdressService
    {
        private readonly AdventureWorksContext context;
        private readonly IMapper mapper;

        public AddressService(AdventureWorksContext context, IMapper mapper)
        {
            this.context = context ?? throw new ArgumentNullException($"Context {nameof(context)} has null value");
            this.mapper = mapper ?? throw new ArgumentNullException($"Mapper {nameof(mapper)} has null value");
        }

        public async Task CreateAddressAsync(RequestAddressModel address)
        {
            try
            {
                var addressToAdd = mapper.Map<Address>(address);
                Address tempAddress=new Address();
                mapper.Map(address, tempAddress);
            await context.Address.AddAsync(mapper.Map<Address>(address));
            }
            catch (Exception)
            {

                throw;
            }
            try
            {

            await context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<AddressModel> GetAddressAsync(int id)
        {

            var address=await context.Address.SingleAsync(x=>x.AddressId==id);

            return mapper.Map<AddressModel>(address);
        }
    }
}
