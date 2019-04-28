using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using NewAPI.Models;

namespace NewAPI.Services.Interfaces

{
    public interface IUserInfoService
    {
        Task<User> GetById(Guid id);
        void AppendUser(User user);
    }
}