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
        /// <summary>
        /// Add New Notice in Db Collection
        /// </summary>
        /// <param name="notice"></param>
        /// <returns></returns>
        public async Task<Notice> AddNotice(Notice notice)
        {
            var resultnotice = await _aSRepository.AddNotice(notice);
            return resultnotice;
        }
        /// <summary>
        /// Add new student in Db Collection
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public async Task<Student> AddStudent(Student student)
        {
            var resultstudent = await _aSRepository.AddStudent(student);
            return resultstudent;
        }
        /// <summary>
        /// Add theacher in Db Collection
        /// </summary>
        /// <param name="teacher"></param>
        /// <returns></returns>
        public async Task<Teacher> AddTeacher(Teacher teacher)
        {
            var resultteacher = await _aSRepository.AddTeacher(teacher);
            return resultteacher;
        }
        /// <summary>
        /// Delete Book by id from Collection
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteBookById(string bookId)
        {
            var result = await _aSRepository.DeleteBookById(bookId);
            return result;
        }
        /// <summary>
        /// Delete notice by notice Id
        /// </summary>
        /// <param name="noticeId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteNoticeById(string noticeId)
        {
            var result = await _aSRepository.DeleteNoticeById(noticeId);
            return result;
        }
        /// <summary>
        /// Delete student by Id from Db Collection
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteStudentById(string studentId)
        {
            var result = await _aSRepository.DeleteStudentById(studentId);
            return result;
        }
        /// <summary>
        /// Delete teacher by by Id from Db Collection
        /// </summary>
        /// <param name="noticeId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteTeacherById(string noticeId)
        {
            var result = await _aSRepository.DeleteTeacherById(noticeId);
            return result;
        }
        /// <summary>
        /// Get book by Book Id from Db collection
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public async Task<Library> GetBookById(string bookId)
        {
            var getbook = await _aSRepository.GetBookById(bookId);
            return getbook;
        }
        /// <summary>
        /// Get Notice By Id from Db Collection
        /// </summary>
        /// <param name="noticeId"></param>
        /// <returns></returns>
        public async Task<Notice> GetNoticeById(string noticeId)
        {
            var getnotice = await _aSRepository.GetNoticeById(noticeId);
            return getnotice;
        }
        /// <summary>
        /// Get student by Id from Db Collecction
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public async Task<Student> GetStudentById(string studentId)
        {
            var getstudent = await _aSRepository.GetStudentById(studentId);
            return getstudent;
        }
        /// <summary>
        /// Get Teachers by Id from Db Collection
        /// </summary>
        /// <param name="teacherId"></param>
        /// <returns></returns>
        public async Task<Teacher> GetTeacherById(string teacherId)
        {
            var getteacher = await _aSRepository.GetTeacherById(teacherId);
            return getteacher;
        }
        /// <summary>
        /// Add new book in Library Collection
        /// </summary>
        /// <param name="library"></param>
        /// <returns></returns>
        public async Task<Library> NewBook(Library library)
        {
            var resultAdd = await _aSRepository.NewBook(library);
            return resultAdd;
        }
        /// <summary>
        /// Update Book in Db Collection by Id and Library Object
        /// </summary>
        /// <param name="bookId"></param>
        /// <param name="library"></param>
        /// <returns></returns>
        public async Task<Library> UpdateBook(string bookId, Library library)
        {
            var update = await _aSRepository.UpdateBook(bookId, library);
            return update;
        }
        /// <summary>
        /// Update Notice in Db Collection by Id and Notice Object
        /// </summary>
        /// <param name="noticeId"></param>
        /// <param name="notice"></param>
        /// <returns></returns>
        public async Task<Notice> UpdateNotice(string noticeId, Notice notice)
        {
            var update = await _aSRepository.UpdateNotice(noticeId, notice);
            return update;
        }
        /// <summary>
        /// Update Student in Db Collection by Id and Student Object
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="student"></param>
        /// <returns></returns>
        public async Task<Student> UpdateStudent(string studentId, Student student)
        {
            var update = await _aSRepository.UpdateStudent(studentId, student);
            return update;
        }
        /// <summary>
        /// Update Teacher in Db Collection by Id and Teacher Object
        /// </summary>
        /// <param name="teacherId"></param>
        /// <param name="teacher"></param>
        /// <returns></returns>
        public async Task<Teacher> UpdateTeacher(string teacherId, Teacher teacher)
        {
            var update = await _aSRepository.UpdateTeacher(teacherId, teacher);
            return update;
        }
    }
}