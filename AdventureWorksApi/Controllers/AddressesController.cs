using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventureWorksApi.Interfaces;
using AdventureWorksApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdventureWorksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly IAdressService service;
        public AddressesController(IAdressService service)
        {
            this.service = service ?? throw new ArgumentNullException($"Service {nameof(service)} has null value.");
        }        

        // GET: api/Adresses/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<AddressModel>> Get(int id)
        {
           return await service.GetAddressAsync(id);
        }

        // POST: api/Adresses
        [HttpPost]
        public async Task<ActionResult> Post(RequestAddressModel newAddress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await service.CreateAddressAsync(newAddress);
            return Ok();
        }

    }
}
