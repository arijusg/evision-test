using System.Threading.Tasks;

namespace Account
{
    public class AccountInfo
    {
        private readonly IAccountService _accountService;
        public AccountInfo(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<AccountAmount> GetAccountAmountAsync(int accountId)
        {
            return await _accountService.GetAccountAmountAsync(accountId);
        }
    }

}
