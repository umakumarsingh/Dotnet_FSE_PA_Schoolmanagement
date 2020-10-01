using MongoDB.Bson;
using MongoDB.Driver;
using Schoolmanagement.DataLayer;
using Schoolmanagement.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Schoolmanagement.BusinessLayer.Services.Repository
{
    public class AdminSchoolRepository : IAdminSchoolRepository
    {
        /// <summary>
        /// Creating field and object or dbcontext and all collection, injecting IMongoDBContext
        /// in constructor and getting a Collection from MongoDb
        /// </summary>
        private readonly IMongoDBContext _mongoContext;
        private IMongoCollection<Notice> _dbNCollection;
        private IMongoCollection<Student> _dbSCollection;
        private IMongoCollection<Teacher> _dbTCollection;
        private IMongoCollection<Library> _dbLCollection;
        private IMongoCollection<BookBorrow> _dbBCollection;
        public AdminSchoolRepository(IMongoDBContext context)
        {
            _mongoContext = context;
            _dbNCollection = _mongoContext.GetCollection<Notice>(typeof(Notice).Name);
            _dbSCollection = _mongoContext.GetCollection<Student>(typeof(Student).Name);
            _dbTCollection = _mongoContext.GetCollection<Teacher>(typeof(Teacher).Name);
            _dbLCollection = _mongoContext.GetCollection<Library>(typeof(Library).Name);
            _dbBCollection = _mongoContext.GetCollection<BookBorrow>(typeof(BookBorrow).Name);
        }
        public async Task<Notice> AddNotice(Notice notice)
        {
            try
            {
                if (notice == null)
                {
                    throw new ArgumentNullException(typeof(Notice).Name + "Object is Null");
                }
                _dbNCollection = _mongoContext.GetCollection<Notice>(typeof(Notice).Name);
                await _dbNCollection.InsertOneAsync(notice);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return notice;
        }

        public async Task<Student> AddStudent(Student student)
        {
            try
            {
                if (student == null)
                {
                    throw new ArgumentNullException(typeof(Student).Name + "Object is Null");
                }
                _dbSCollection = _mongoContext.GetCollection<Student>(typeof(Student).Name);
                await _dbSCollection.InsertOneAsync(student);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return student;
        }

        public async Task<Teacher> AddTeacher(Teacher teacher)
        {
            try
            {
                if (teacher == null)
                {
                    throw new ArgumentNullException(typeof(Teacher).Name + "Object is Null");
                }
                _dbTCollection = _mongoContext.GetCollection<Teacher>(typeof(Teacher).Name);
                await _dbTCollection.InsertOneAsync(teacher);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return teacher;
        }

        public async Task<bool> DeleteBookById(string bookId)
        {
            try
            {
                var objectId = new ObjectId(bookId);
                FilterDefinition<Library> filter = Builders<Library>.Filter.Eq("BookId", objectId);
                var result = await _dbLCollection.DeleteOneAsync(filter);
                return result.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<bool> DeleteNoticeById(string noticeId)
        {
            try
            {
                var objectId = new ObjectId(noticeId);
                FilterDefinition<Notice> filter = Builders<Notice>.Filter.Eq("NoticeId", objectId);
                var result = await _dbNCollection.DeleteOneAsync(filter);
                return result.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<bool> DeleteStudentById(string studentId)
        {
            try
            {
                var objectId = new ObjectId(studentId);
                FilterDefinition<Student> filter = Builders<Student>.Filter.Eq("StudentId", objectId);
                var result = await _dbSCollection.DeleteOneAsync(filter);
                return result.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<bool> DeleteTeacherById(string teacherId)
        {
            try
            {
                var objectId = new ObjectId(teacherId);
                FilterDefinition<Teacher> filter = Builders<Teacher>.Filter.Eq("TeacherId", objectId);
                var result = await _dbTCollection.DeleteOneAsync(filter);
                return result.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<Library> GetBookById(string bookId)
        {
            try
            {
                var objectId = new ObjectId(bookId);
                FilterDefinition<Library> filter = Builders<Library>.Filter.Eq("bookId", objectId);
                _dbLCollection = _mongoContext.GetCollection<Library>(typeof(Library).Name);
                return await _dbLCollection.FindAsync(filter).Result.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<Notice> GetNoticeById(string noticeId)
        {
            try
            {
                var objectId = new ObjectId(noticeId);
                FilterDefinition<Notice> filter = Builders<Notice>.Filter.Eq("NoticeId", objectId);
                _dbNCollection = _mongoContext.GetCollection<Notice>(typeof(Notice).Name);
                return await _dbNCollection.FindAsync(filter).Result.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<Student> GetStudentById(string studentId)
        {
            try
            {
                var objectId = new ObjectId(studentId);
                FilterDefinition<Student> filter = Builders<Student>.Filter.Eq("StudentId", objectId);
                _dbSCollection = _mongoContext.GetCollection<Student>(typeof(Student).Name);
                return await _dbSCollection.FindAsync(filter).Result.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<Teacher> GetTeacherById(string teacherId)
        {
            try
            {
                var objectId = new ObjectId(teacherId);
                FilterDefinition<Teacher> filter = Builders<Teacher>.Filter.Eq("TeacherId", objectId);
                _dbTCollection = _mongoContext.GetCollection<Teacher>(typeof(Teacher).Name);
                return await _dbTCollection.FindAsync(filter).Result.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<Library> NewBook(Library library)
        {
            try
            {
                if (library == null)
                {
                    throw new ArgumentNullException(typeof(Library).Name + "Object is Null");
                }
                _dbLCollection = _mongoContext.GetCollection<Library>(typeof(Library).Name);
                await _dbLCollection.InsertOneAsync(library);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return library;
        }

        public async Task<Library> UpdateBook(string bookId, Library library)
        {
            if (library == null && bookId == null)
            {
                throw new ArgumentNullException(typeof(Library).Name + "Object or may be bookId is Null");
            }
            var update = await _dbLCollection.FindOneAndUpdateAsync(Builders<Library>.
                Filter.Eq("BookId", library.BookId), Builders<Library>.
                Update.Set("BookName", library.BookName).Set("Publication", library.Publication)
                .Set("Writer", library.Writer).Set("Stock", library.Stock));
            return update;
        }

        public async Task<Notice> UpdateNotice(string noticeId, Notice notice)
        {
            if (notice == null && noticeId == null)
            {
                throw new ArgumentNullException(typeof(Notice).Name + "Object or may be noticeId is Null");
            }
            var update = await _dbNCollection.FindOneAndUpdateAsync(Builders<Notice>.
                Filter.Eq("NoticeId", notice.NoticeId), Builders<Notice>.
                Update.Set("Name", notice.Name).Set("NoticeDate", notice.NoticeDate)
                .Set("classList", notice.classList).Set("Event", notice.Event)
                .Set("ChiefGuest", notice.ChiefGuest).Set("Remarks", notice.Remarks));
            return update;
        }

        public async Task<Student> UpdateStudent(string studentId, Student student)
        {
            if (student == null && studentId == null)
            {
                throw new ArgumentNullException(typeof(Student).Name + "Object or may be studentId is Null");
            }
            var update = await _dbSCollection.FindOneAndUpdateAsync(Builders<Student>.
                Filter.Eq("StudentId", student.StudentId), Builders<Student>.
                Update.Set("Name", student.Name).Set("DOB", student.DOB)
                .Set("Phone", student.Phone).Set("FatherName", student.FatherName)
                .Set("classList", student.classList).Set("Section", student.Section));
            return update;
        }

        public async Task<Teacher> UpdateTeacher(string teacherId, Teacher teacher)
        {
            if (teacher == null && teacherId == null)
            {
                throw new ArgumentNullException(typeof(Teacher).Name + "Object or may be teacherId is Null");
            }
            var update = await _dbTCollection.FindOneAndUpdateAsync(Builders<Teacher>.
                Filter.Eq("TeacherId", teacher.TeacherId), Builders<Teacher>.
                Update.Set("Name", teacher.Name).Set("Address", teacher.Address)
                .Set("Email", teacher.Email).Set("PhoneNumber", teacher.PhoneNumber)
                .Set("Subject", teacher.Subject).Set("Experience", teacher.Experience)
                .Set("Remark", teacher.Remark));
            return update;
        }
    }
}