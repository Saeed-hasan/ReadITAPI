using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReadITAPI.Models;
using ReadITAPI.Repository;

namespace ReadITAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public SalesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Sales
        [HttpGet]
        public ActionResult<IEnumerable<Sales>> GetSales()
        {
            return _unitOfWork.sales.GetAll();
        }

        // GET: api/Sales/5
        [HttpGet("{id}")]
        public ActionResult<Sales> GetSales(int id)
        {
            var sales = _unitOfWork.sales.Get(id);

            if (sales == null)
            {
                return NotFound();
            }

            return sales;
        }

        // PUT: api/Sales/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSales(int id, Sales sales)
        {
            if (id != sales.Id)
            {
                return BadRequest();
            }

            _unitOfWork.sales.Edit(sales);

            return NoContent();
        }

        // POST: api/Sales
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Sales> PostSales(Sales sales)
        {
            _unitOfWork.sales.Add(sales);
            var response = new
            {
                message = "Sale Created Successfully"
            };

            return Ok(response);
        }

        // DELETE: api/Sales/5
        [HttpDelete("{id}")]
        public IActionResult DeleteSales(int id)
        {
            var sales = _unitOfWork.sales.Get(id);
            if (sales == null)
            {
                return NotFound();
            }

            _unitOfWork.sales.Remove(sales);

            return NoContent();
        }
    }
}
