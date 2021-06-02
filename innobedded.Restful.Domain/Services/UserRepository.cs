using innobedded.Restful.Data.Entity;
using innobedded.Restful.Domain.Interfaces;
using innobedded.Restful.Data.context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace innobedded.Restful.Domain.Services
{
    public class UserRepository : IUserRepository
    {
        private RestfulDbContext _restfulDbContext;
        private DbSet<User> _userentity;


        public UserRepository(RestfulDbContext restfulDbContext)
        {
            _restfulDbContext = restfulDbContext;
            _userentity = _restfulDbContext.Set<User>();
        }


        public IList<User> GetAll()
        {
            return _userentity.ToList();
        }

 
        public User GetUserbyId(int id)
        {
            return _userentity.Find(id);
        }

        public void Insert(User user)
        {
            try
            {
                _userentity.Add(user);
            }
            catch 
            {

                
            }
        }

        public void Update(User user)
        {
            _userentity.Attach(user);
            _restfulDbContext.Entry(user).State = EntityState.Modified;
        }
        public void Delete(User user)
        {
            try
            {
                if (_restfulDbContext.Entry(user).State == EntityState.Detached)
                {
                    _userentity.Attach(user);
                }
                _userentity.Remove(user);

            }
            catch
            {

                
            }
        }

        public void Save()
        {
            _restfulDbContext.SaveChanges();
        }

        public bool IsExsist(int id)
        {
            return _userentity.Count(p => p.ID == id) > 0;
        }
    ///
    ///Async Functions
    //////
    public async Task<IList<User>> GetAllAsync()
        {
            return await _userentity.ToListAsync();
    }

        public async Task<User> GetUserbyIdAsync(int id)
        {
            return await _userentity.FindAsync(id);
        }

        public async Task SaveAsync()
        {
            await _restfulDbContext.SaveChangesAsync();
        }
    }
}
