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
    public class CategoriesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoriesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Categories
        [HttpGet]
        public ActionResult<IEnumerable<Category>> Getcategories()
        {
            return _unitOfWork.Category.GetAll();
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public ActionResult<Category> GetCategory(int id)
        {
            var category = _unitOfWork.Category.Get(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutCategory(int id, Category category)
        {
            if (id != category.category_id)
            {
                return BadRequest();
            }

            _unitOfWork.Category.Edit(category);

            return NoContent();
        }

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Category> PostCategory(Category category)
        {
            _unitOfWork.Category.Add(category);
            var response = new
            {
                message = "Category Created Successfully"
            };

            return Ok(response);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var category = _unitOfWork.Category.Get(id);
            if (category == null)
            {
                return NotFound();
            }

            _unitOfWork.Category.Remove(category);

            return NoContent();
        }

        // GET: api/Categories/BooksInsideOneCategory
        [HttpGet("BooksInsideOneCategory")]
        public ActionResult<Category> BooksInsideOneCategory(int id)
        {
            var category = _unitOfWork.Category.Include(id);
            if (category == null)
            {
                return NotFound();
            }
            return category;
        }
    }
}
