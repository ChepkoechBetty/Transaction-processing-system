using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPS.Models;

namespace TPS.Services
{
    public interface IUserService
    {
        TUser GetByUsername(string username);
        TUserAccount GetAccount(string UserId);
    }
}
