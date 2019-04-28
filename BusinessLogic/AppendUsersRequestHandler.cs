using System;
using System.Threading.Tasks;
using MassTransit;
using NewAPI.Models;
using NewAPI.Commands;
using NewAPI.Services.Interfaces;


namespace NewAPI.BusinessLogic
{
    public class AppendUsersRequestHandler
    {
       private readonly IBus _bus;

        public AppendUsersRequestHandler(IBus bus)
        {
            _bus = bus;
        }

        public Task<User> Handle(User user)
        {
            Guid guid = Guid.NewGuid();
            user.Id = guid;

            // было так: 
            _userInfoService.AppendUser(user);
            /*_bus.Send(new AppendUserCommand()
            {
                User = user
            });*/

            return Task.FromResult<User>(user);
        }
    }
}