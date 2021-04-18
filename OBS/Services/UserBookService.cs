using Microsoft.EntityFrameworkCore;
using OBS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OBS.Services
{
    public class UserBookService : IUserBookService
    {
        private readonly BooksContext context;
        UserBookService(BooksContext _context) {
            context = _context;
        }
        public async Task<List<UserBook>> GetAll()
        {
            List<UserBook> UserB = await Task.Run(() => context.UserBooks.Include(UB => UB.Book).ToList());
            //context.SaveChanges();
            return UserB;
        }

        public async Task<UserBook> GetDetails(int id, string id2)
        {
           return await context.UserBooks.Include(U => U.Book).FirstOrDefaultAsync(UB => UB.BookId == id && UB.UserId == id2);
        }

        public async void Insert(UserBook userbook)
        {
            await context.UserBooks.AddAsync(userbook);
            await context.SaveChangesAsync();

        }
    }
}
