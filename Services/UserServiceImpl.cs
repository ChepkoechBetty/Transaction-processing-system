using System;
using System.Linq;
using System.Threading.Tasks;
using TPS.Models;

namespace TPS.Services
{
    public class UserServiceImpl : IUserService
    {
        private CoreDbContext _coreDbContext;

        public UserServiceImpl(CoreDbContext coreDbContext)
        {
            _coreDbContext = coreDbContext;
            
        }

        public TUserAccount GetAccount(string UserId)
        {
            return _coreDbContext.TUserAccounts.SingleOrDefault(x => x.UserId ==UserId);
        }

        public TUser GetByUsername(string username)
        {
            return _coreDbContext.TUsers.SingleOrDefault(x => x.UserName ==username);

        }
       
    }
}
