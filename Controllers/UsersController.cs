using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewAPI.BusinessLogic;
using NewAPI.Models;

namespace NewAPI.Controllers
{

    [Route("api/users")]
    // [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly GetUsersInfoRequestHandler _getUsersInfoRequestHandler;
        private readonly AppendUsersRequestHandler _appendUsersRequestHandler;
        public UsersController(GetUsersInfoRequestHandler getUsersInfoRequestHandler, AppendUsersRequestHandler appendUsersRequestHandler)
        {
            this._getUsersInfoRequestHandler = getUsersInfoRequestHandler;
            this._appendUsersRequestHandler = appendUsersRequestHandler;
        }

        // GET api/values
        /*[HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] {"value1", "value2"};
        }*/

        [HttpGet("{id}")]
        public Task<User> GetUserInfo(Guid id)
        {
            return _getUsersInfoRequestHandler.Handle(id);
        }


        // POST api/values
        /*
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }*/

        // PUT api/values/5
        /*
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }*/

        // DELETE api/values/5
        /*
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/

        [HttpPost("append")]
        public void AppendUser([FromBody] User user)
        {
            Guid guid = Guid.NewGuid();
            user.Id = guid;
            _appendUsersRequestHandler.Handle(user);
        }
    }
    }