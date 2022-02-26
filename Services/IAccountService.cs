using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPS.Models;

namespace TPS.Services
{
    public interface IAccountService
    {
        TUserAccount TransferMoney(string accountId,decimal amount);
        TUserAccount GetAccount(string accountId);
        TAtm GetATM(string AtmName);
        TUserAccount WithdrawMoney(string accountId, string AtmId, decimal amount);
        TUserAccount UpdateAccountBalance(string accountId, decimal amount);
        TAtm UpdateAtmBalance(string atmId, decimal amount);
    }
}
