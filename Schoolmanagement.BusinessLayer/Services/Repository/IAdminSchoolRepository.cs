using Schoolmanagement.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Schoolmanagement.BusinessLayer.Services.Repository
{
    public interface IAdminSchoolRepository
    {
        Task<Notice> AddNotice(Notice notice);
        Task<Notice> GetNoticeById(string noticeId);
        Task<bool> DeleteNoticeById(string noticeId);
        Task<Notice> UpdateNotice(string noticeId, Notice notice);
        Task<Student> AddStudent(Student student);
        Task<Student> GetStudentById(string studentId);
        Task<bool> DeleteStudentById(string studentId);
        Task<Student> UpdateStudent(string studentId, Student student);
        Task<Library> NewBook(Library library);
        Task<Library> GetBookById(string bookId);
        Task<bool> DeleteBookById(string bookId);
        Task<Library> UpdateBook(string bookId, Library library);
        Task<Teacher> AddTeacher(Teacher teacher);
        Task<Teacher> GetTeacherById(string teacherId);
        Task<bool> DeleteTeacherById(string noticeId);
        Task<Teacher> UpdateTeacher(string teacherId, Teacher teacher);
    }
}
