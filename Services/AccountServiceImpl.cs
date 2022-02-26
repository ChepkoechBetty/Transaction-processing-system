using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TPS.Models;

namespace TPS.Services
{
    public class AccountServiceImpl : IAccountService
    {
        private CoreDbContext _coreDbContext;
        public AccountServiceImpl(CoreDbContext coreDbContext)
        {
            _coreDbContext = coreDbContext;
        }
        public TUserAccount GetAccount(string userid)
        {
            return _coreDbContext.TUserAccounts.SingleOrDefault(x => x.Id == userid);
        }

        public TAtm GetATM(string AtmName)
        {
            return _coreDbContext.TAtms.SingleOrDefault(x => x.AtmName == AtmName);
        }
        public TUserAccount TransferMoney(string accountId,decimal amount)
        {
            
            return UpdateAccountBalance(accountId,amount);
        }

        public TUserAccount UpdateAccountBalance(string accountId, decimal amount)
        {
            TUserAccount useraccount = _coreDbContext.TUserAccounts.SingleOrDefault(x => x.Id == accountId);
            useraccount.AccBalance = useraccount.AccBalance - amount;
            _coreDbContext.Update(useraccount);
            _coreDbContext.SaveChanges();
            return useraccount;
        }

        public TAtm UpdateAtmBalance(string atmId, decimal amount)
        {
            TAtm atm = _coreDbContext.TAtms.SingleOrDefault(x => x.Id == atmId);
            atm.AtmBalance = atm.AtmBalance - amount;
            _coreDbContext.Update(atm);
            _coreDbContext.SaveChanges();
            return atm;
        }

        public TUserAccount WithdrawMoney(string accountId, string AtmId, decimal amount)
        {
            TAtm atm = _coreDbContext.TAtms.SingleOrDefault(x => x.Id == AtmId);
            atm.AtmBalance = atm.AtmBalance - amount;
            return UpdateAccountBalance(accountId, amount);
        }
        
    }
}
