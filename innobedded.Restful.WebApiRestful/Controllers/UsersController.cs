using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using innobedded.Restful.Data.Entity;
using innobedded.Restful.Data.context;
using innobedded.Restful.Domain;

namespace innobedded.Restful.WebApiRestful.Controllers
{
    public class UsersController : ApiController
    {
        private UnitOfWork _unitofwork;

        public UsersController()
        {
            _unitofwork = new UnitOfWork();
        }

        // GET: api/Users
        public IList<User> GetUsers()
        {
            //return db.Users;
            return _unitofwork.UserRepository.GetAll();
        }

        // GET: api/Users/5

        [ResponseType(typeof(User))]
        
        public IHttpActionResult GetUser(int id)
        {
            User user = _unitofwork.UserRepository.GetUserbyId(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUser(int id, User user)
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
                _unitofwork.UserRepository.Save();
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

        // POST: api/Users
        [ResponseType(typeof(User))]
        public IHttpActionResult PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _unitofwork.UserRepository.Insert(user);
            _unitofwork.UserRepository.Save();

            return CreatedAtRoute("DefaultApi", new { id = user.ID }, user);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult DeleteUser(int id)
        {
            User user = _unitofwork.UserRepository.GetUserbyId(id);
            if (user == null)
            {
                return NotFound();
            }

            _unitofwork.UserRepository.Delete(user);
            _unitofwork.UserRepository.Save();

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