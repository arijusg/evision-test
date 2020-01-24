using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Account
{

    public interface IAccountService
    {
        Task<AccountAmount> GetAccountAmountAsync(int accountId);
    }
}
