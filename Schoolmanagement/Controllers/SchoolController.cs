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
            //Do Code Here
            throw new NotImplementedException();
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
            //Do Code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get all student bu Db Collection
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("allstudent")]
        public async Task<IEnumerable<Student>> GetAllStudent()
        {
            //Do Code Here
            throw new NotImplementedException();
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
            //Do Code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get all book list fron Db Collection
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("booklist")]
        public async Task<IEnumerable<Library>> GetBookList()
        {
            //Do Code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// All teachers from Db ollection
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("allteacher")]
        public async Task<IEnumerable<Teacher>> GetAllTeacher()
        {
            //Do Code Here
            throw new NotImplementedException();
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
            //Do Code Here
            throw new NotImplementedException();
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
            //Do Code Here
            throw new NotImplementedException();
        }
    }
}
