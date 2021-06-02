using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using innobedded.Restful.Data.Entity;
using innobedded.Restful.Data.context;
using innobedded.Restful.Domain;

namespace innobedded.Restful.WebApiRestful.Controllers
{
    public class UsersAsyncController : ApiController
    {
        //private RestfulDbContext db = new RestfulDbContext();

        private UnitOfWork _unitofwork;

        public UsersAsyncController()
        {
            _unitofwork = new UnitOfWork();
        }
        // GET: api/UsersAsync
        public async Task<IList<User>> GetUsers()
        {
            //return db.Users;
            return  await _unitofwork.UserRepository.GetAllAsync();
        }


        // GET: api/UsersAsync/5
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> GetUser(int id)
        {
            User user = await _unitofwork.UserRepository.GetUserbyIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/UsersAsync/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUser(int id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.ID)
            {
                return BadRequest();
            }

            _unitofwork.UserRepository.Update(user);

            try
            {
                await _unitofwork.UserRepository.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/UsersAsync
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _unitofwork.UserRepository.Insert(user);
            await _unitofwork.UserRepository.SaveAsync();

            return CreatedAtRoute("DefaultApi", new { id = user.ID }, user);
        }

        // DELETE: api/UsersAsync/5
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> DeleteUser(int id)
        {
            User user = await _unitofwork.UserRepository.GetUserbyIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            
            _unitofwork.UserRepository.Delete(user);
            await _unitofwork.UserRepository.SaveAsync();

            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitofwork.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(int id)
        {
            return _unitofwork.UserRepository.IsExsist(id);
        }
    }
}