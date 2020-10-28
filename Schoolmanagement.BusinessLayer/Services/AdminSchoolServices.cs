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
            //Do Code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Add new student in Db Collection
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public async Task<Student> AddStudent(Student student)
        {
            //Do Code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Add theacher in Db Collection
        /// </summary>
        /// <param name="teacher"></param>
        /// <returns></returns>
        public async Task<Teacher> AddTeacher(Teacher teacher)
        {
            //Do Code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Delete Book by id from Collection
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteBookById(string bookId)
        {
            //Do Code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Delete notice by notice Id
        /// </summary>
        /// <param name="noticeId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteNoticeById(string noticeId)
        {
            //Do Code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Delete student by Id from Db Collection
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteStudentById(string studentId)
        {
            //Do Code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Delete teacher by by Id from Db Collection
        /// </summary>
        /// <param name="noticeId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteTeacherById(string noticeId)
        {
            //Do Code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get book by Book Id from Db collection
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public async Task<Library> GetBookById(string bookId)
        {
            //Do Code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get Notice By Id from Db Collection
        /// </summary>
        /// <param name="noticeId"></param>
        /// <returns></returns>
        public async Task<Notice> GetNoticeById(string noticeId)
        {
            //Do Code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get student by Id from Db Collecction
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public async Task<Student> GetStudentById(string studentId)
        {
            //Do Code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get Teachers by Id from Db Collection
        /// </summary>
        /// <param name="teacherId"></param>
        /// <returns></returns>
        public async Task<Teacher> GetTeacherById(string teacherId)
        {
            //Do Code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Add new book in Library Collection
        /// </summary>
        /// <param name="library"></param>
        /// <returns></returns>
        public async Task<Library> NewBook(Library library)
        {
            //Do Code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Update Book in Db Collection by Id and Library Object
        /// </summary>
        /// <param name="bookId"></param>
        /// <param name="library"></param>
        /// <returns></returns>
        public async Task<Library> UpdateBook(string bookId, Library library)
        {
            //Do Code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Update Notice in Db Collection by Id and Notice Object
        /// </summary>
        /// <param name="noticeId"></param>
        /// <param name="notice"></param>
        /// <returns></returns>
        public async Task<Notice> UpdateNotice(string noticeId, Notice notice)
        {
            //Do Code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Update Student in Db Collection by Id and Student Object
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="student"></param>
        /// <returns></returns>
        public async Task<Student> UpdateStudent(string studentId, Student student)
        {
            //Do Code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Update Teacher in Db Collection by Id and Teacher Object
        /// </summary>
        /// <param name="teacherId"></param>
        /// <param name="teacher"></param>
        /// <returns></returns>
        public async Task<Teacher> UpdateTeacher(string teacherId, Teacher teacher)
        {
            //Do Code Here
            throw new NotImplementedException();
        }
    }
}