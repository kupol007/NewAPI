using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;


namespace NewAPI
{
    public class GetUsersInfoRequestHandler
    {
        private readonly IUserlnfoService _userInfoService;
        public GetUsersInfoRequestHandler(IUserlnfoService userInfoService)
        {
            _userInfoService = userInfoService;
        }
        public Task<User> Handle(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Некорректный идентификатор пользователя", nameof(id));
            }
            return _userInfoService.GetById(id);
        }
    }
}