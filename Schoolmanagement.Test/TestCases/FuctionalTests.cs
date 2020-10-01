using Moq;
using Schoolmanagement.BusinessLayer.Interfaces;
using Schoolmanagement.BusinessLayer.Services;
using Schoolmanagement.BusinessLayer.Services.Repository;
using Schoolmanagement.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Schoolmanagement.Test.TestCases
{
    public class FuctionalTests
    {
        /// <summary>
        /// Creating Referance Variable of Service Interface and Mocking Repository Interface and class
        /// </summary>
        private readonly ISchoolServices _SchoolServices;
        private readonly AdminSchoolServices _ASServices;
        public readonly Mock<ISchoolRepository> service = new Mock<ISchoolRepository>();
        public readonly Mock<IAdminSchoolRepository> Adminservice = new Mock<IAdminSchoolRepository>();
        private readonly Notice _notice;
        private readonly Student _student;
        private readonly Library _library;
        private readonly Teacher _teacher;
        private readonly BookBorrow _bookBorrow;
        public FuctionalTests()
        {
            //Creating New mock Object with value.
            _SchoolServices = new SchoolServices(service.Object);
            _ASServices = new AdminSchoolServices(Adminservice.Object);
            _notice = new Notice
            {
                NoticeId = "5f1025b2587fb74450a61c78",
                Name = "26 January",
                NoticeDate = new DateTime(2021, 1, 26),
                classList = ClassList.FIVE,
                Event = "Republic Day",
                ChiefGuest = "Donald Trump",
                Remarks = "Happy republic day! Wishing you India, you have a great future and enjoy your everlasting independence. Today we are free because of the hardships faced by our freedom fighters. Let us salute them."
            };
            _student = new Student
            {
                StudentId = "5f71d29f0341602be6be445f",
                Name = "Uma Kumar",
                DOB = new DateTime(1990, 03, 01),
                Phone = 9631438113,
                FatherName = "Gopal PD Singh",
                classList = ClassList.TEN,
                Section = "A"
            };
            _library = new Library
            {
                BookId = "5f0ec59dce04c32fb4d3160a",
                BookName = "Deploying And Devloping .Net core",
                Publication = "Microsoft-Press",
                Writer = "Tim Cook",
                Stock = 10
            };
            _teacher = new Teacher
            {
                TeacherId = "5f0ec59dce04c32fb4d3160a",
                Name = "Santosh Kumar",
                Address = "South Block 9/11, New Delhi-09",
                Email = "santosh@iiht.com",
                PhoneNumber = 9635244510,
                Subject = "Hindi, Sience, SST",
                Experience = 6,
                Remark = ""
            };
            _bookBorrow = new BookBorrow
            {
                //BorrowId = "5f0ec59dce04c32fb4d3160a",
                FromDate = DateTime.Now,
                Todate = DateTime.Now
            };
        }
        /// <summary>
        /// Creating test output text file that store the result in boolean result
        /// </summary>
        static FuctionalTests()
        {
            if (!File.Exists("../../../../output_revised.txt"))
                try
                {
                    File.Create("../../../../output_revised.txt").Dispose();
                }
                catch (Exception)
                {

                }
            else
            {
                File.Delete("../../../../output_revised.txt");
                File.Create("../../../../output_revised.txt").Dispose();
            }
        }
        /// <summary>
        /// Get all Notice
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_GetAllNotice()
        {
            //Arrange
            var res = false;
            //Action
            service.Setup(repos => repos.AllNotice());
            var result = await _SchoolServices.AllNotice();
            //Assertion
            if (result != null)
            {
                res = true;
            }
            //Assert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_GetAllNotice=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Find Notic by Name and get passed if notice not found
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_FindNotice()
        {
            //Arrange
            var res = false;
            //Action
            service.Setup(repos => repos.FindNotice(_notice.Name));
            var result = await _SchoolServices.FindNotice(_notice.Name);
            //Assertion
            if (result != null)
            {
                res = true;
            }
            //Assert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_FindNotice=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Add valid Notice in Db Collection Method Test
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_Add_valid_Notice()
        {
            //Arrange
            bool res = false;
            //Act
            Adminservice.Setup(repo => repo.AddNotice(_notice)).ReturnsAsync(_notice);
            var result = await _ASServices.AddNotice(_notice);
            if (result != null)
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_Validate_Add_valid_Notice=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Get Notice by notice Id Test
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> TestFor_GetNoticeById()
        {
            //Arrange
            var res = false;
            Adminservice.Setup(repo => repo.AddNotice(_notice)).ReturnsAsync(_notice);
            var result = await _ASServices.AddNotice(_notice);
            //Action

            Adminservice.Setup(repos => repos.GetNoticeById(result.NoticeId)).ReturnsAsync(_notice);
            var resultById = _ASServices.GetNoticeById(result.NoticeId);
            //Assertion
            if (resultById != null)
            {
                res = true;
            }
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "TestFor_GetNoticeById=" + res + "\n");
            return res;
        }
        /// <summary>
        /// TestFor_DeleteNotice is used for to test passed NoticeId is deleted or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> TestFor_DeleteNotice()
        {
            //Arrange
            var res = false;
            Adminservice.Setup(repo => repo.AddNotice(_notice)).ReturnsAsync(_notice);
            var result = await _ASServices.AddNotice(_notice);
            //Action
            Adminservice.Setup(repos => repos.DeleteNoticeById(result.NoticeId)).ReturnsAsync(true);
            var resultDelete = await _ASServices.DeleteNoticeById(result.NoticeId);
            //Assertion
            if (resultDelete == true)
            {
                res = true;
            }
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "TestFor_DeleteNotice=" + res + "\n");
            return res;
        }
        /// <summary>
        /// TestFor_UpdateNotice is used to upadte Notice or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> TestFor_UpdateNotice()
        {
            //Arrange
            var res = false;
            var _noticeUpdate = new Notice()
            {
                NoticeId = "5f1025b2587fb74450a61c78",
                Name = "26 January",
                NoticeDate = new DateTime(2021, 1, 26),
                classList = ClassList.FIVE,
                Event = "Republic Day",
                ChiefGuest = "Donald Trump",
                Remarks = "Happy republic day! Wishing you India, you have a great future and enjoy your everlasting independence. Today we are free because of the hardships faced by our freedom fighters. Let us salute them."
            };
            Adminservice.Setup(repo => repo.AddNotice(_notice)).ReturnsAsync(_notice);
            var result = await _ASServices.AddNotice(_notice);
            //Action
            Adminservice.Setup(repos => repos.UpdateNotice(result.NoticeId, _noticeUpdate)).ReturnsAsync(_notice);
            var resultUpdate = await _ASServices.UpdateNotice(result.NoticeId, _noticeUpdate);
            //Assertion
            if (resultUpdate == _notice)
            {
                res = true;
            }
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "TestFor_UpdateNotice=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Add valid Student in Db Collection Method Test
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_Add_valid_Student()
        {
            //Arrange
            bool res = false;
            //Act
            Adminservice.Setup(repo => repo.AddStudent(_student)).ReturnsAsync(_student);
            var result = await _ASServices.AddStudent(_student);
            if (result != null)
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_Validate_Add_valid_Student=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Get Student by Student Id Test
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> TestFor_GetStudenteById()
        {
            //Arrange
            var res = false;
            Adminservice.Setup(repo => repo.AddStudent(_student)).ReturnsAsync(_student);
            var result = await _ASServices.AddStudent(_student);
            //Action

            Adminservice.Setup(repos => repos.GetStudentById(result.StudentId)).ReturnsAsync(_student);
            var resultById = _ASServices.GetNoticeById(result.StudentId);
            //Assertion
            if (resultById != null)
            {
                res = true;
            }
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "TestFor_GetStudenteById=" + res + "\n");
            return res;
        }
        /// <summary>
        /// TestFor_DeleteStudent is used for to test passed StudentId is deleted or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> TestFor_DeleteStudent()
        {
            //Arrange
            var res = false;
            Adminservice.Setup(repo => repo.AddStudent(_student)).ReturnsAsync(_student);
            var result = await _ASServices.AddStudent(_student);
            //Action
            Adminservice.Setup(repos => repos.DeleteStudentById(result.StudentId)).ReturnsAsync(true);
            var resultDelete = await _ASServices.DeleteStudentById(result.StudentId);
            //Assertion
            if (resultDelete == true)
            {
                res = true;
            }
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "TestFor_DeleteStudent=" + res + "\n");
            return res;
        }
        /// <summary>
        /// TestFor_UpdateStudent is used to upadte Student or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> TestFor_UpdateStudent()
        {
            //Arrange
            var res = false;
            var _studentUpdate = new Student()
            {
                StudentId = "5f71d29f0341602be6be445f",
                Name = "Uma Kumar",
                DOB = new DateTime(1990, 03, 01),
                Phone = 9631438113,
                FatherName = "Gopal PD Singh",
                classList = ClassList.TEN,
                Section = "A"
            };
            Adminservice.Setup(repo => repo.AddStudent(_student)).ReturnsAsync(_student);
            var result = await _ASServices.AddStudent(_student);
            //Action
            Adminservice.Setup(repos => repos.UpdateStudent(result.StudentId, _studentUpdate)).ReturnsAsync(_student);
            var resultUpdate = await _ASServices.UpdateStudent(result.StudentId, _studentUpdate);
            //Assertion
            if (resultUpdate == _student)
            {
                res = true;
            }
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "TestFor_UpdateStudent=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Get all student and verify its return student list or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_GetAllStudent()
        {
            //Arrange
            var res = false;
            //Action
            service.Setup(repos => repos.AllStudent());
            var result = await _SchoolServices.AllStudent();
            //Assertion
            if (result != null)
            {
                res = true;
            }
            //Assert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_GetAllStudent=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Find Student by Name and get passed if notice not found
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_FindStudent()
        {
            //Arrange
            var res = false;
            //Action
            service.Setup(repos => repos.FindStudent(_student.Name));
            var result = await _SchoolServices.FindStudent(_student.Name);
            //Assertion
            if (result != null)
            {
                res = true;
            }
            //Assert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_FindStudent=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Add valid Book in Db Collection Method Test
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_Add_valid_Book()
        {
            //Arrange
            bool res = false;
            //Act
            Adminservice.Setup(repo => repo.NewBook(_library)).ReturnsAsync(_library);
            var result = await _ASServices.NewBook(_library);
            if (result != null)
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_Validate_Add_valid_Book=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Get Book by BookId Id Test
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> TestFor_GetBookById()
        {
            //Arrange
            var res = false;
            Adminservice.Setup(repo => repo.NewBook(_library)).ReturnsAsync(_library);
            var result = await _ASServices.NewBook(_library);
            //Action

            Adminservice.Setup(repos => repos.GetBookById(result.BookId)).ReturnsAsync(_library);
            var resultById = _ASServices.GetBookById(result.BookId);
            //Assertion
            if (resultById != null)
            {
                res = true;
            }
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "TestFor_GetBookById=" + res + "\n");
            return res;
        }
        /// <summary>
        /// TestFor_DeleteBook is used for to test passed BookId is deleted or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> TestFor_DeleteBook()
        {
            //Arrange
            var res = false;
            Adminservice.Setup(repo => repo.NewBook(_library)).ReturnsAsync(_library);
            var result = await _ASServices.NewBook(_library);
            //Action
            Adminservice.Setup(repos => repos.DeleteBookById(result.BookId)).ReturnsAsync(true);
            var resultDelete = await _ASServices.DeleteBookById(result.BookId);
            //Assertion
            if (resultDelete == true)
            {
                res = true;
            }
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "TestFor_DeleteBook=" + res + "\n");
            return res;
        }
        /// <summary>
        /// TestFor_UpdateBook is used to upadte Book or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> TestFor_UpdateBook()
        {
            //Arrange
            var res = false;
            var _bookUpdate = new Library()
            {
                BookId = "5f0ec59dce04c32fb4d3160a",
                BookName = "Deploying And Devloping .Net core",
                Publication = "Microsoft-Press",
                Writer = "Tim Cook",
                Stock = 10
            };
            Adminservice.Setup(repo => repo.NewBook(_library)).ReturnsAsync(_library);
            var result = await _ASServices.NewBook(_library);
            //Action
            Adminservice.Setup(repos => repos.UpdateBook(result.BookId, _bookUpdate)).ReturnsAsync(_library);
            var resultUpdate = await _ASServices.UpdateBook(result.BookId, _bookUpdate);
            //Assertion
            if (resultUpdate == _library)
            {
                res = true;
            }
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "TestFor_UpdateBook=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Add valid Teacher in Db Collection Method Test
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_Add_valid_Teacher()
        {
            //Arrange
            bool res = false;
            //Act
            Adminservice.Setup(repo => repo.AddTeacher(_teacher)).ReturnsAsync(_teacher);
            var result = await _ASServices.AddTeacher(_teacher);
            if (result != null)
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_Validate_Add_valid_Teacher=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Get Teacher by Teacher Id Test
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> TestFor_GetTeacherById()
        {
            //Arrange
            var res = false;
            Adminservice.Setup(repo => repo.AddTeacher(_teacher)).ReturnsAsync(_teacher);
            var result = await _ASServices.AddTeacher(_teacher);
            //Action

            Adminservice.Setup(repos => repos.GetTeacherById(result.TeacherId)).ReturnsAsync(_teacher);
            var resultById = _ASServices.GetTeacherById(result.TeacherId);
            //Assertion
            if (resultById != null)
            {
                res = true;
            }
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "TestFor_GetTeacherById=" + res + "\n");
            return res;
        }
        /// <summary>
        /// TestFor_DeleteTeacher is used for to test passed Teacher is deleted or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> TestFor_DeleteTeacher()
        {
            //Arrange
            var res = false;
            Adminservice.Setup(repo => repo.AddTeacher(_teacher)).ReturnsAsync(_teacher);
            var result = await _ASServices.AddTeacher(_teacher);
            //Action
            Adminservice.Setup(repos => repos.DeleteTeacherById(result.TeacherId)).ReturnsAsync(true);
            var resultDelete = await _ASServices.DeleteTeacherById(result.TeacherId);
            //Assertion
            if (resultDelete == true)
            {
                res = true;
            }
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "TestFor_DeleteTeacher=" + res + "\n");
            return res;
        }
        /// <summary>
        /// TestFor_UpdateTeacher is used to upadte Teachers or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> TestFor_UpdateTeacher()
        {
            //Arrange
            var res = false;
            var _teacherUpdate = new Teacher()
            {
                TeacherId = "5f0ec59dce04c32fb4d3160a",
                Name = "Santosh Kumar",
                Address = "South Block 9/11, New Delhi-09",
                Email = "santosh@iiht.com",
                PhoneNumber = 9635244510,
                Subject = "Hindi, Sience, SST",
                Experience = 6,
                Remark = ""
            };
            Adminservice.Setup(repo => repo.AddTeacher(_teacher)).ReturnsAsync(_teacher);
            var result = await _ASServices.AddTeacher(_teacher);
            //Action
            Adminservice.Setup(repos => repos.UpdateTeacher(result.TeacherId, _teacherUpdate)).ReturnsAsync(_teacher);
            var resultUpdate = await _ASServices.UpdateTeacher(result.TeacherId, _teacherUpdate);
            //Assertion
            if (resultUpdate == _teacher)
            {
                res = true;
            }
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "TestFor_UpdateTeacher=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Get all book list and verify BookList services funtion
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_GetBookList()
        {
            //Arrange
            var res = false;
            //Action
            service.Setup(repos => repos.BookList());
            var result = await _SchoolServices.BookList();
            //Assertion
            if (result != null)
            {
                res = true;
            }
            //Assert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_GetBookList=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Get all teachers list and verify services AllTeacher method
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_GetAllTeacher()
        {
            //Arrange
            var res = false;
            //Action
            service.Setup(repos => repos.AllTeacher());
            var result = await _SchoolServices.AllTeacher();
            //Assertion
            if (result != null)
            {
                res = true;
            }
            //Assert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_GetAllTeacher=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Place a book borrow order and test its True return
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_BorrowBook()
        {
            //Arrange
            var res = false;
            //Action
            service.Setup(repos => repos.BorrowBook(_library.BookId, _bookBorrow)).ReturnsAsync(_bookBorrow);
            var result = await _SchoolServices.BorrowBook(_library.BookId, _bookBorrow);
            //Assertion
            if (result != null)
            {
                res = true;
            }
            //Assert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_BorrowBook=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Get Book Borrow Infrormation and test BorrowInfo
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_BorrowInfo()
        {
            //Arrange
            var res = false;
            //Action
            service.Setup(repos => repos.BorrowInfo(_bookBorrow.BorrowId)).ReturnsAsync(_bookBorrow);
            var result = await _SchoolServices.BorrowInfo(_bookBorrow.BorrowId);
            //Assertion
            if (result != null)
            {
                res = true;
            }
            //Assert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_BorrowInfo=" + res + "\n");
            return res;
        }
    }
}