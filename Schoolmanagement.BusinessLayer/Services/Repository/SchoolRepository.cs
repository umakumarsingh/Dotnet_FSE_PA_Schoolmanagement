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
    public class SchoolRepository : ISchoolRepository
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
        public SchoolRepository(IMongoDBContext context)
        {
            _mongoContext = context;
            _dbNCollection = _mongoContext.GetCollection<Notice>(typeof(Notice).Name);
            _dbSCollection = _mongoContext.GetCollection<Student>(typeof(Student).Name);
            _dbTCollection = _mongoContext.GetCollection<Teacher>(typeof(Teacher).Name);
            _dbLCollection = _mongoContext.GetCollection<Library>(typeof(Library).Name);
            _dbBCollection = _mongoContext.GetCollection<BookBorrow>(typeof(BookBorrow).Name);
        }
        public async Task<IEnumerable<Notice>> AllNotice()
        {
            try
            {
                var list = _mongoContext.GetCollection<Notice>("Notice")
                .Find(Builders<Notice>.Filter.Empty, null)
                .SortByDescending(e => e.NoticeId);
                return await list.ToListAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<IEnumerable<Student>> AllStudent()
        {
            try
            {
                var list = _mongoContext.GetCollection<Student>("Student")
                .Find(Builders<Student>.Filter.Empty, null)
                .SortByDescending(e => e.StudentId);
                return await list.ToListAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<IEnumerable<Teacher>> AllTeacher()
        {
            try
            {
                var list = _mongoContext.GetCollection<Teacher>("Teacher")
                .Find(Builders<Teacher>.Filter.Empty, null)
                .SortByDescending(e => e.TeacherId);
                return await list.ToListAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<IEnumerable<Library>> BookList()
        {
            try
            {
                var list = _mongoContext.GetCollection<Library>("Library")
                .Find(Builders<Library>.Filter.Empty, null)
                .SortByDescending(e => e.BookId);
                return await list.ToListAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<BookBorrow> BorrowBook(string BookId, BookBorrow bookBorrow)
        {
            try
            {
                if (BookId == null && bookBorrow == null)
                {
                    throw new ArgumentNullException(typeof(BookBorrow).Name + "Object and Id is Null");
                }
                _dbBCollection = _mongoContext.GetCollection<BookBorrow>(typeof(BookBorrow).Name);
                await _dbBCollection.InsertOneAsync(bookBorrow);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return bookBorrow;
        }

        public async Task<BookBorrow> BorrowInfo(string BorrowId)
        {
            try
            {
                var objectId = new ObjectId(BorrowId);
                FilterDefinition<BookBorrow> filter = Builders<BookBorrow>.Filter.Eq("BorrowId", objectId);
                _dbBCollection = _mongoContext.GetCollection<BookBorrow>(typeof(BookBorrow).Name);
                return await _dbBCollection.FindAsync(filter).Result.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<IEnumerable<Notice>> FindNotice(string name)
        {
            try
            {
                var filterBuilder = new FilterDefinitionBuilder<Notice>();
                var findName = filterBuilder.Eq(s => s.Name, name);
                var findevent = filterBuilder.Eq(s => s.Event, name.ToString());
                _dbNCollection = _mongoContext.GetCollection<Notice>(typeof(Notice).Name);
                var result = await _dbNCollection.FindAsync(findName | findevent).Result.ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<IEnumerable<Student>> FindStudent(string name)
        {
            try
            {
                var filterBuilder = new FilterDefinitionBuilder<Student>();
                var findName = filterBuilder.Eq(s => s.Name, name);
                _dbSCollection = _mongoContext.GetCollection<Student>(typeof(Student).Name);
                var result = await _dbSCollection.FindAsync(findName).Result.ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
