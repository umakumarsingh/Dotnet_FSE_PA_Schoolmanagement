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

        public async Task<IEnumerable<Notice>> AllNotice()
        {
            var result = await _sRepository.AllNotice();
            return result;
        }

        public async Task<IEnumerable<Student>> AllStudent()
        {
            var result = await _sRepository.AllStudent();
            return result;
        }

        public async Task<IEnumerable<Teacher>> AllTeacher()
        {
            var result = await _sRepository.AllTeacher();
            return result;
        }

        public async Task<IEnumerable<Library>> BookList()
        {
            var result = await _sRepository.BookList();
            return result;
        }

        public async Task<BookBorrow> BorrowBook(string BookId, BookBorrow bookBorrow)
        {
            var result = await _sRepository.BorrowBook(BookId, bookBorrow);
            return result;
        }

        public async Task<BookBorrow> BorrowInfo(string BorrowId)
        {
            var bookinfo = await _sRepository.BorrowInfo(BorrowId);
            return bookinfo;
        }

        public async Task<IEnumerable<Notice>> FindNotice(string name)
        {
            var findresult = await _sRepository.FindNotice(name);
            return findresult;
        }

        public async Task<IEnumerable<Student>> FindStudent(string name)
        {
            var findstudent = await _sRepository.FindStudent(name);
            return findstudent;
        }
    }
}
