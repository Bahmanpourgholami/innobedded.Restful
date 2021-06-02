using innobedded.Restful.Data.context;
using innobedded.Restful.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace innobedded.Restful.Domain
{
    public class UnitOfWork : IDisposable
    {
     private   RestfulDbContext _maincontext;

        public UnitOfWork()
        {
            _maincontext = new RestfulDbContext();
        }

        private UserRepository userRepository;

        public UserRepository UserRepository {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new UserRepository(_maincontext);
                }

                return userRepository;
            }
                
                
                }
        public void Dispose()
        {
            _maincontext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
