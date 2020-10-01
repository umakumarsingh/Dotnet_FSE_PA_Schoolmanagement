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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Student students = new Student
            {
                Name = model.Name,
                DOB = model.DOB,
                Phone = model.Phone,
                FatherName = model.FatherName,
                classList = model.classList,
                Section = model.Section
            };
            await _aSServices.AddStudent(students);
            return Ok("Student Added...");
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
            if (studentId == null)
            {
                return BadRequest();
            }
            try
            {
                var result = await _aSServices.DeleteStudentById(studentId);
                if (result == false)
                {
                    return NotFound();
                }
                return Ok("Student Deleted...");
            }
            catch (Exception)
            {
                return BadRequest();
            }
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
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var getstudent = _aSServices.GetStudentById(studentId);
            if (getstudent == null)
            {
                return NotFound();
            }
            await _aSServices.UpdateStudent(studentId, student);
            return CreatedAtAction("GetAllStudent", "School", new { studentId = student.StudentId }, student);
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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Notice notices = new Notice
            {
                Name = model.Name,
                NoticeDate = model.NoticeDate,
                classList = model.classList,
                Event = model.Event,
                ChiefGuest = model.ChiefGuest,
                Remarks = model.Remarks
            };
            await _aSServices.AddNotice(notices);
            return Ok("Notice Added...");
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
            if (noticeId == null)
            {
                return BadRequest();
            }
            try
            {
                var result = await _aSServices.DeleteNoticeById(noticeId);
                if (result == false)
                {
                    return NotFound();
                }
                return Ok("Notice Deleted...");
            }
            catch (Exception)
            {
                return BadRequest();
            }
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
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var getnotice = _aSServices.GetNoticeById(noticeId);
            if (getnotice == null)
            {
                return NotFound();
            }
            await _aSServices.UpdateNotice(noticeId, notice);
            return CreatedAtAction("GetAllNotice", "School", new { noticeId = notice.NoticeId }, notice);
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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Library librarys = new Library
            {
                BookName = model.BookName,
                Publication = model.Publication,
                Writer = model.Writer,
                Stock = model.Stock
            };
            await _aSServices.NewBook(librarys);
            return Ok("New Book Added to library...");
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
            if (bookId == null)
            {
                return BadRequest();
            }
            try
            {
                var result = await _aSServices.DeleteBookById(bookId);
                if (result == false)
                {
                    return NotFound();
                }
                return Ok("Book Deleted from library collection...");
            }
            catch (Exception)
            {
                return BadRequest();
            }
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
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var getbook = _aSServices.GetBookById(bookId);
            if (getbook == null)
            {
                return NotFound();
            }
            await _aSServices.UpdateBook(bookId, library);
            return CreatedAtAction("GetBookList", "School", new { bookId = library.BookId }, library);
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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Teacher teachers = new Teacher
            {
                Name = model.Name,
                Address = model.Address,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Subject = model.Subject,
                Experience = model.Experience,
                Remark = model.Remark
            };
            await _aSServices.AddTeacher(teachers);
            return Ok("New Teacher Added...");
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
            if (teacherId == null)
            {
                return BadRequest();
            }
            try
            {
                var result = await _aSServices.DeleteTeacherById(teacherId);
                if (result == false)
                {
                    return NotFound();
                }
                return Ok("Teacher Deleted from collection...");
            }
            catch (Exception)
            {
                return BadRequest();
            }
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
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var getbook = _aSServices.GetTeacherById(teacherId);
            if (getbook == null)
            {
                return NotFound();
            }
            await _aSServices.UpdateTeacher(teacherId, teacher);
            return CreatedAtAction("GetAllTeacher", "School", new { teacherId = teacher.TeacherId }, teacher);
        }
    }
}
