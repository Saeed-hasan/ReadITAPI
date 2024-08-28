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
    public class RequstionsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public RequstionsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Requstions
        [HttpGet]
        public ActionResult<IEnumerable<Requstion>> GetRequstions()
        {
            return _unitOfWork.request.GetAll();
        }

        // GET: api/Requstions/5
        [HttpGet("{id}")]
        public ActionResult<Requstion> GetRequstion(int id)
        {
            var requstion = _unitOfWork.request.Get(id);

            if (requstion == null)
            {
                return NotFound();
            }

            return requstion;
        }

        // PUT: api/Requstions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutRequstion(int id, Requstion requstion)
        {
            if (id != requstion.Id)
            {
                return BadRequest();
            }

            _unitOfWork.request.Edit(requstion);

            return NoContent();
        }

        // POST: api/Requstions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Requstion> PostRequstion(Requstion requstion)
        {
            _unitOfWork.request.Add(requstion);
            var response = new
            {
                message = "Request Created Successfully"
            };

            return Ok(response);
        }

        // DELETE: api/Requstions/5
        [HttpDelete("{id}")]
        public IActionResult DeleteRequstion(int? id)
        {
            if (id == null || id == 0)
            {
                return BadRequest();
            }
            Requstion request = _unitOfWork.request.Get(id!.Value);
            if (request == null)
            {
                return NotFound();
            }
            _unitOfWork.request.Remove(request);
            _unitOfWork.Save();
            var response = new
            {
                message = "request Deleted successfully"
            };

            return Ok(response);
        }
    }
}
