using System;
using System.Threading.Tasks;

namespace NewAPI
{
    public interface IUserlnfoService
    {
        Task<User> GetById(Guid id);
    }
}