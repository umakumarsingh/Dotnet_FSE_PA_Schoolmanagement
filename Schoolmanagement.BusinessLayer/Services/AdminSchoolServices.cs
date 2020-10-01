using Schoolmanagement.BusinessLayer.Interfaces;
using Schoolmanagement.BusinessLayer.Services.Repository;
using Schoolmanagement.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Schoolmanagement.BusinessLayer.Services
{
    public class AdminSchoolServices : IAdminSchoolServices
    {
        /// <summary>
        /// Creating Referancce variable of IAdminSchoolRepository and injecting Referance into constructor
        /// </summary>
        private readonly IAdminSchoolRepository _aSRepository;

        public AdminSchoolServices(IAdminSchoolRepository adminSchoolRepository)
        {
            _aSRepository = adminSchoolRepository;
        }

        public async Task<Notice> AddNotice(Notice notice)
        {
            var resultnotice = await _aSRepository.AddNotice(notice);
            return resultnotice;
        }

        public async Task<Student> AddStudent(Student student)
        {
            var resultstudent = await _aSRepository.AddStudent(student);
            return resultstudent;
        }

        public async Task<Teacher> AddTeacher(Teacher teacher)
        {
            var resultteacher = await _aSRepository.AddTeacher(teacher);
            return resultteacher;
        }

        public async Task<bool> DeleteBookById(string bookId)
        {
            var result = await _aSRepository.DeleteBookById(bookId);
            return result;
        }

        public async Task<bool> DeleteNoticeById(string noticeId)
        {
            var result = await _aSRepository.DeleteNoticeById(noticeId);
            return result;
        }

        public async Task<bool> DeleteStudentById(string studentId)
        {
            var result = await _aSRepository.DeleteStudentById(studentId);
            return result;
        }

        public async Task<bool> DeleteTeacherById(string noticeId)
        {
            var result = await _aSRepository.DeleteTeacherById(noticeId);
            return result;
        }

        public async Task<Library> GetBookById(string bookId)
        {
            var getbook = await _aSRepository.GetBookById(bookId);
            return getbook;
        }

        public async Task<Notice> GetNoticeById(string noticeId)
        {
            var getnotice = await _aSRepository.GetNoticeById(noticeId);
            return getnotice;
        }

        public async Task<Student> GetStudentById(string studentId)
        {
            var getstudent = await _aSRepository.GetStudentById(studentId);
            return getstudent;
        }

        public async Task<Teacher> GetTeacherById(string teacherId)
        {
            var getteacher = await _aSRepository.GetTeacherById(teacherId);
            return getteacher;
        }

        public async Task<Library> NewBook(Library library)
        {
            var resultAdd = await _aSRepository.NewBook(library);
            return resultAdd;
        }

        public async Task<Library> UpdateBook(string bookId, Library library)
        {
            var update = await _aSRepository.UpdateBook(bookId, library);
            return update;
        }

        public async Task<Notice> UpdateNotice(string noticeId, Notice notice)
        {
            var update = await _aSRepository.UpdateNotice(noticeId, notice);
            return update;
        }

        public async Task<Student> UpdateStudent(string studentId, Student student)
        {
            var update = await _aSRepository.UpdateStudent(studentId, student);
            return update;
        }

        public async Task<Teacher> UpdateTeacher(string teacherId, Teacher teacher)
        {
            var update = await _aSRepository.UpdateTeacher(teacherId, teacher);
            return update;
        }
    }
}