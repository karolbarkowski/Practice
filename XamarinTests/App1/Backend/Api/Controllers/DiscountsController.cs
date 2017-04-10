using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace Api.Controllers
{
    [Route("api/discounts")]
    public class DiscountsController : Controller
    {
        // GET: api/discounts
        [HttpGet]
        public IEnumerable<Discount> Get()
        {
            return new Discount[] {
                new Discount() {
                    Percentage = 20,
                    Price = 100,
                    ProductName = "Test Product",
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                },
                new Discount() {
                    Percentage = 25,
                    Price = 200,
                    ProductName = "Test Product 2",
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                }
            };
        }
        

        // GET api/discounts/5
        [HttpGet("{id}")]
        public Discount Get(int id)
        {
            return new Discount()
            {
                Percentage = 20,
                Price = 100,
                ProductName = "Test Product",
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now
            };
        }

        // POST api/discounts
        [HttpPost]
        public void Post(Discount value)
        {
        }

        // PUT api/discounts/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Discount value)
        {
        }

        // DELETE api/discounts/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
