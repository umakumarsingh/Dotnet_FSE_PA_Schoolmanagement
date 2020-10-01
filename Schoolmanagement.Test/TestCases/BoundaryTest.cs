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
    public class BoundaryTest
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
        public BoundaryTest()
        {
            //Creating New mock Object with value.
            _SchoolServices = new SchoolServices(service.Object);
            _ASServices = new AdminSchoolServices(Adminservice.Object);
            _notice = new Notice
            {
                NoticeId = "",
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
                BookId = "",
                BookName = "Deploying And Devloping .Net core",
                Publication = "Microsoft-Press",
                Writer = "Tim Cook",
                Stock = 10
            };
            _teacher = new Teacher
            {
                TeacherId = "",
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
                BorrowId = "",
                FromDate = DateTime.Now,
                Todate = DateTime.Now
            };
        }
        /// <summary>
        /// Creating test output text file that store the result in boolean result
        /// </summary>
        static BoundaryTest()
        {
            if (!File.Exists("../../../../output_boundary_revised.txt"))
                try
                {
                    File.Create("../../../../output_boundary_revised.txt").Dispose();
                }
                catch (Exception)
                {

                }
            else
            {
                File.Delete("../../../../output_boundary_revised.txt");
                File.Create("../../../../output_boundary_revised.txt").Dispose();
            }
        }
        /// <summary>
        /// Testfor_ValidateNoticeId used for test the valid Nitice Id
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_ValidateBorrowBookId()
        {
            //Arrange
            bool res = false;
            //Act
            service.Setup(repos => repos.BorrowBook(_library.BookId, _bookBorrow)).ReturnsAsync(_bookBorrow);
            var result = await _SchoolServices.BorrowBook(_library.BookId, _bookBorrow);
            if (result.BorrowId == _bookBorrow.BorrowId)
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_boundary_revised.txt", "Testfor_ValidateBorrowBookId=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Test to validate From date return not null
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_FromDate_Notnull()
        {
            //Arrange
            bool res = false;
            //Act
            service.Setup(repos => repos.BorrowBook(_library.BookId, _bookBorrow)).ReturnsAsync(_bookBorrow);
            var result = await _SchoolServices.BorrowBook(_library.BookId, _bookBorrow);
            if (result.FromDate != null)
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_boundary_revised.txt", "Testfor_Validate_FromDate_Notnull=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Test to validate To date return not null
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_ToDate_Notnull()
        {
            //Arrange
            bool res = false;
            //Act
            service.Setup(repos => repos.BorrowBook(_library.BookId, _bookBorrow)).ReturnsAsync(_bookBorrow);
            var result = await _SchoolServices.BorrowBook(_library.BookId, _bookBorrow);
            if (result.Todate != null)
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_boundary_revised.txt", "Testfor_Validate_ToDate_Notnull=" + res + "\n");
            return res;
        }
    }
}
