using laba2.Accounts;
using laba2.Accounts.States;
using System.Globalization;

namespace laba3.DB.Services.Base
{
    public interface IAccountService
    {
        public void CreateAccount(string UserName, int Rating, AccountType type);
        public void DeleteAccountByUserName(string UserName);

        public void UpdatePlayerName(string PrevName, string NewName);
        public List<BaseAccount> ReadAccounts();
        public List<BaseAccount> ReadAccountByUserName(string UserName);
    }
}
