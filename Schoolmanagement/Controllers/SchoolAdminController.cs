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
    public class SchoolAdminController : ControllerBase
    {
        /// <summary>
        /// Creating Referancce variable of IAdminSchoolServices and injecting Referance into constructor
        /// </summary>
        private readonly IAdminSchoolServices _aSServices;

        public SchoolAdminController(IAdminSchoolServices adminSchoolServices)
        {
            _aSServices = adminSchoolServices;
        }
        /// <summary>
        /// Add new student in Db Collection
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("newstudent")]
        public async Task<IActionResult> Addnewstudent([FromBody] StudentViewModel model)
        {
            //Do Code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Delete a student from Db Collction
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteStudent/{StudentId}")]
        public async Task<IActionResult> DeleteStudent(string studentId)
        {
            //Do Code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Update Student informtion
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Updatestudent/{StudentId}")]
        public async Task<IActionResult> UpdateStudent(string studentId, [FromBody] Student student)
        {
            //Do Code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Add new notice Db Collection
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("newnotice")]
        public async Task<IActionResult> Addnewnotice([FromBody] NoticeViewModel model)
        {
            //Do Code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Delete an existing notice by Notice Id
        /// </summary>
        /// <param name="noticeId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Deletenotice/{NoticeId}")]
        public async Task<IActionResult> DeleteNotice(string noticeId)
        {
            //Do Code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Update existing student by passing student id and student infromation with StudentId
        /// </summary>
        /// <param name="noticeId"></param>
        /// <param name="notice"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Updatenotice/{NoticeId}")]
        public async Task<IActionResult> UpdateNotice(string noticeId, [FromBody] Notice notice)
        {
            //Do Code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Add new book to Library DbCollection
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("newbook")]
        public async Task<IActionResult> Addnewbook([FromBody] LibraryViewModel model)
        {
            //Do Code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Delete Book from library collection
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Deletebook/{BookId}")]
        public async Task<IActionResult> DeleteBook(string bookId)
        {
            //Do Code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Upadte a existing book
        /// </summary>
        /// <param name="bookId"></param>
        /// <param name="library"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Updatebook/{BookId}")]
        public async Task<IActionResult> UpdateBook(string bookId, [FromBody] Library library)
        {
            //Do Code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Add new Teachers
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("newteacher")]
        public async Task<IActionResult> Addnewteachers([FromBody] TeacherViewModel model)
        {
            //Do Code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Delete teacher from DbCollection
        /// </summary>
        /// <param name="teacherId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Deleteteacher/{TeacherId}")]
        public async Task<IActionResult> DeleteTeacher(string teacherId)
        {
            //Do Code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Update existing teachers
        /// </summary>
        /// <param name="teacherId"></param>
        /// <param name="teacher"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Updateteacher/{TeacherId}")]
        public async Task<IActionResult> UpdateTeacher(string teacherId, [FromBody] Teacher teacher)
        {
            //Do Code Here
            throw new NotImplementedException();
        }
    }
}
