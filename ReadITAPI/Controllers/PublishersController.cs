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
    public class PublishersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public PublishersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Publishers
        [HttpGet]
        public ActionResult<IEnumerable<Publisher>> Getpublishers()
        {
            return _unitOfWork.publisher.GetAll();
        }

        // GET: api/Publishers/5
        [HttpGet("{id}")]
        public ActionResult<Publisher> GetPublisher(int id)
        {
            var publisher = _unitOfWork.publisher.Get(id);

            if (publisher == null)
            {
                return NotFound();
            }

            return publisher;
        }

        // PUT: api/Publishers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutPublisher(int id, Publisher publisher)
        {
            if (id != publisher.Publisher_Id)
            {
                return BadRequest();
            }

            _unitOfWork.publisher.Edit(publisher);

            return NoContent();
        }

        // POST: api/Publishers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Publisher> PostPublisher(Publisher publisher)
        {
            _unitOfWork.publisher.Add(publisher);
            var response = new
            {
                message = "Publisher Created Successfully"
            };

            return Ok(response);
        }

        // DELETE: api/Publishers/5
        [HttpDelete("{id}")]
        public IActionResult DeletePublisher(int id)
        {
            var publisher = _unitOfWork.publisher.Get(id);
            if (publisher == null)
            {
                return NotFound();
            }

            _unitOfWork.publisher.Remove(publisher);

            return NoContent();
        }
    }
}
