using AdventureWorksApi.EF.Models;
using AdventureWorksApi.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AdventureWorksApi.Mappers
{
    public class AdventureWorksMappingProfile : Profile
    {
        public AdventureWorksMappingProfile()
        {
            CreateMap<Address, AddressModel>();
            CreateMap<AddressModel, Address>();
            CreateMap<RequestAddressModel, Address>();
            CreateMap<Address, RequestAddressModel>();
        }
    }
}
