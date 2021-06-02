using innobedded.Restful.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace innobedded.Restful.Domain.Interfaces
{
 public   interface IUserRepository
    {
        // IEnumerable<User> GetAllUser();

        //    Task<IList<User>> GetAllAsync();
        Task<IList<User>> GetAllAsync();
        Task<User> GetUserbyIdAsync(int id);

        Task SaveAsync();

        IList<User> GetAll();

        User GetUserbyId(int id);
        
        void Insert(User user);
        void Delete(User user);
        void Update(User user);

        bool IsExsist(int id);
        void Save();

    }
}
