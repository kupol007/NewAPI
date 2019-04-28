using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using NewAPI.Commands;
using NewAPI.Services;
using NewAPI.Services.Interfaces;
using NewAPI.Models;



namespace NewAPI.Consumers
{
    public class AppendUserConsumer : IConsumer<AppendUserCommand>
    {
        private readonly IUserInfoService _userInfoService;

        public AppendUserConsumer(IUserInfoService userInfoService)
        {
            _userInfoService = userInfoService;
        }

        public async Task Consume(ConsumeContext<AppendUserCommand> context)
        {
            await _userInfoService.AppendUser(context.Message.User);
        }
    }
}
