using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OBS.Models;

namespace OBS.Services
{
    public interface IUserBookService
    {
        public Task<List<UserBook>> GetAll();
        public Task<UserBook> GetDetails(int id, string id2);
        public void Insert(UserBook userbook);
        //public void Update(int id, UserBook userbook);
        //public void Delete(int id);
    }
}
