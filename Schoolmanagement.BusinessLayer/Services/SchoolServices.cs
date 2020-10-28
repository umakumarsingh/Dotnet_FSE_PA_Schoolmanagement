using Schoolmanagement.BusinessLayer.Interfaces;
using Schoolmanagement.BusinessLayer.Services.Repository;
using Schoolmanagement.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Schoolmanagement.BusinessLayer.Services
{
    public class SchoolServices : ISchoolServices
    {
        /// <summary>
        /// creating a referance object of ISchoolRepository
        /// </summary>
        private readonly ISchoolRepository _sRepository;
        /// <summary>
        /// injecting ISchoolRepository in consructor to access all methods
        /// </summary>
        /// <param name="schoolRepository"></param>
        public SchoolServices(ISchoolRepository schoolRepository)
        {
            _sRepository = schoolRepository;
        }
        /// <summary>
        /// Get All notice from Db Collection
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Notice>> AllNotice()
        {
            //Do Code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get All student from Db Collection
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Student>> AllStudent()
        {
            //Do Code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get All Teachers from Db Collection
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Teacher>> AllTeacher()
        {
            //Do Code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get All Book from Library Db Collection
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Library>> BookList()
        {
            //Do Code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Place book borrow in Db Collection
        /// </summary>
        /// <param name="BookId"></param>
        /// <param name="bookBorrow"></param>
        /// <returns></returns>
        public async Task<BookBorrow> BorrowBook(string BookId, BookBorrow bookBorrow)
        {
            //Do Code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get borrow book info
        /// </summary>
        /// <param name="BorrowId"></param>
        /// <returns></returns>
        public async Task<BookBorrow> BorrowInfo(string BorrowId)
        {
            //Do Code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Find a notice by notice Name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Notice>> FindNotice(string name)
        {
            //Do Code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Find student by student name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Student>> FindStudent(string name)
        {
            //Do Code Here
            throw new NotImplementedException();
        }
    }
}
