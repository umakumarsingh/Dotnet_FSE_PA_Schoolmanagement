using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Schoolmanagement.BusinessLayer.Interfaces;
using Schoolmanagement.BusinessLayer.ViewModels;
using Schoolmanagement.Entities;

namespace Schoolmanagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        /// <summary>
        /// Creating Referancce variable of ISchoolServices and injecting Referance into constructor
        /// </summary>
        private readonly ISchoolServices _schoolServices;

        public SchoolController(ISchoolServices schoolServices)
        {
            _schoolServices = schoolServices;
        }
        /// <summary>
        /// Get all notice list from Db collection
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<Notice>> GetAllNotice()
        {
            return await _schoolServices.AllNotice();
        }
        /// <summary>
        /// Find Notice by name, event from Db Collection
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Searchnotice/{Name}")]
        public async Task<IActionResult> SearchNotice(string name)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var findnotice = await _schoolServices.FindNotice(name);
            if (findnotice == null)
            {
                return NotFound();
            }
            return CreatedAtAction("GetAllNotice", findnotice);
        }
        /// <summary>
        /// Get all student bu Db Collection
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("allstudent")]
        public async Task<IEnumerable<Student>> GetAllStudent()
        {
            return await _schoolServices.AllStudent();
        }
        /// <summary>
        /// Find Student by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Searchstudent/{Name}")]
        public async Task<IActionResult> SearchStudent(string name)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var findstudent = await _schoolServices.FindStudent(name);
            if (findstudent == null)
            {
                return NotFound();
            }
            return CreatedAtAction("GetAllStudent", findstudent);
        }
        /// <summary>
        /// Get all book list fron Db Collection
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("booklist")]
        public async Task<IEnumerable<Library>> GetBookList()
        {
            return await _schoolServices.BookList();
        }
        /// <summary>
        /// All teachers from Db ollection
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("allteacher")]
        public async Task<IEnumerable<Teacher>> GetAllTeacher()
        {
            return await _schoolServices.AllTeacher();
        }
        /// <summary>
        /// Borrow Book from Library and collect from counter
        /// </summary>
        /// <param name="BookId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Borrowbook")]
        public async Task<IActionResult> Borrowbook(string BookId, [FromBody] BookBorrowViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            BookBorrow bookborrrow = new BookBorrow
            {
                FromDate = model.FromDate,
                Todate = model.Todate
            };
            await _schoolServices.BorrowBook(BookId, bookborrrow);
            return Ok("Book Borrowed, Collect from Counter...");
        }
        /// <summary>
        /// Get Book Borrow Information by borrow id
        /// </summary>
        /// <param name="borrowId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("borrowinfo/{BorrowId}")]
        public async Task<IActionResult> BorrowBookInfor(string borrowId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var info = await _schoolServices.BorrowInfo(borrowId);
            if (info == null)
            {
                return NotFound();
            }
            return CreatedAtAction("GetBookList", info);
        }
    }
}
