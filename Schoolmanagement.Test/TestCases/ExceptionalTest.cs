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
    public class ExceptionalTest
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
        public ExceptionalTest()
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
        static ExceptionalTest()
        {
            if (!File.Exists("../../../../output_exception_revised.txt"))
                try
                {
                    File.Create("../../../../output_exception_revised.txt").Dispose();
                }
                catch (Exception)
                {

                }
            else
            {
                File.Delete("../../../../output_exception_revised.txt");
                File.Create("../../../../output_exception_revised.txt").Dispose();
            }
        }
        /// <summary>
        /// Using this test method try to validate Notice is invalid if notice object is null
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_Invlid_Add_Notice()
        {
            //Arrange
            bool res = false;
            var notice = new Notice
            {
                NoticeId = "5f1025b2587fb74450a61c78",
                Name = "26 January",
                NoticeDate = new DateTime(2021, 1, 26),
                classList = ClassList.FIVE,
                Event = "Republic Day",
                ChiefGuest = "Donald Trump",
                Remarks = "Happy republic day! Wishing you India, you have a great future and enjoy your everlasting independence. Today we are free because of the hardships faced by our freedom fighters. Let us salute them."
            };
            notice = null;
            //Act
            Adminservice.Setup(repo => repo.AddNotice(notice)).ReturnsAsync(notice = null);
            var result = await _ASServices.AddNotice(notice);
            if (result == null)
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_exception_revised.txt", "Testfor_Validate_Invlid_Add_Notice=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Using this test method try to validate Notice is invalid if Notice object is null
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_InvlidBookBorrow()
        {
            //Arrange
            bool res = false;
            var bookBorrow = new BookBorrow
            {
                BorrowId = "",
                FromDate = DateTime.Now,
                Todate = DateTime.Now
            };
            bookBorrow = null;
            //Act
            service.Setup(repo => repo.BorrowBook(_library.BookId, bookBorrow)).ReturnsAsync(bookBorrow = null);
            var result = await _SchoolServices.BorrowBook(_library.BookId, bookBorrow);
            if (result == null)
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_exception_revised.txt", "Testfor_Validate_InvlidBookBorrow=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Using this test method try to validate Student is invalid if student object is null
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_Invlid_Add_Student()
        {
            //Arrange
            bool res = false;
            var student = new Student
            {
                StudentId = "5f71d29f0341602be6be445f",
                Name = "Uma Kumar",
                DOB = new DateTime(1990, 03, 01),
                Phone = 9631438113,
                FatherName = "Gopal PD Singh",
                classList = ClassList.TEN,
                Section = "A"
            };
            student = null;
            //Act
            Adminservice.Setup(repo => repo.AddStudent(student)).ReturnsAsync(student = null);
            var result = await _ASServices.AddStudent(student);
            if (result == null)
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_exception_revised.txt", "Testfor_Validate_Invlid_Add_Student=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Using this test method try to validate Student is invalid if student object is null
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_Invlid_Add_Teacher()
        {
            //Arrange
            bool res = false;
            var teacher = new Teacher
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
            teacher = null;
            //Act
            Adminservice.Setup(repo => repo.AddTeacher(teacher)).ReturnsAsync(teacher = null);
            var result = await _ASServices.AddTeacher(teacher);
            if (result == null)
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_exception_revised.txt", "Testfor_Validate_Invlid_Add_Teacher=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Using this test method try to validate Student is invalid if student object is null
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_Invlid_Add_Book()
        {
            //Arrange
            bool res = false;
            var library = new Library
            {
                BookId = "5f0ec59dce04c32fb4d3160a",
                BookName = "Deploying And Devloping .Net core",
                Publication = "Microsoft-Press",
                Writer = "Tim Cook",
                Stock = 10
            };
            library = null;
            //Act
            Adminservice.Setup(repo => repo.NewBook(library)).ReturnsAsync(library = null);
            var result = await _ASServices.NewBook(library);
            if (result == null)
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_exception_revised.txt", "Testfor_Validate_Invlid_Add_Book=" + res + "\n");
            return res;
        }
    }
}
