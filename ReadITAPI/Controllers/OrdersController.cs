using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ReadITAPI.Models;
using ReadITAPI.Repository;

namespace ReadITAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrdersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Orders
        [HttpGet]
        public ActionResult<IEnumerable<Order>> Getorders()
        {
            return _unitOfWork.order.GetAll();
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public ActionResult<Order> GetOrder(int id)
        {
            var order = _unitOfWork.order.Get(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutOrder(int id, Order order)
        {
            if (id != order.order_Id)
            {
                return BadRequest();
            }

            _unitOfWork.order.Edit(order);

            return NoContent();
        }

        // POST: api/Orders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Order> PostOrder(Order order)
        {
            _unitOfWork.order.GetAll();
            var response = new
            {
                message = "Order Created Successfully"
            };

            return Ok(response);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            var order = _unitOfWork.order.Get(id);
            if (order == null)
            {
                return NotFound();
            }

            _unitOfWork.order.Remove(order);

            return NoContent();
        }

        // POST: api/OrderNow
        [HttpPost("OrderNow")]
        public IActionResult OrderNow(int? user, int? isbn)
        {
            if (user == null && isbn == null)
            {
                return BadRequest();
            }

            var response = new
            {
                orderSuccess = "Order Created Successfully",
                requestSuccess = "Request Created Successfully"
            };

            if (_unitOfWork.order.order(user!.Value, isbn!.Value))
                return Ok(response);
            else
                return BadRequest();
        }

        // POST: api/BuyNow
        [HttpPost("BuyNow")]
        public IActionResult BuyNow(int? user, int? isbn)
        {
            if (user == null && isbn == null)
            {
                return BadRequest();
            }
            var response = new
            {
                message = "purchase done successfully"
            };
            
            if (_unitOfWork.order.Buy(user!.Value, isbn!.Value))
                return Ok(response);
            else
                return BadRequest();
        }
    }
}
