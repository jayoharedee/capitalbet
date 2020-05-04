using com.capital.bet.data.Models.Accounts;
using com.capital.bet.data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace com.capital.bet.data.Repository
{
    public class UserAccountRepository : Repository<UserAccount>, IUserAccountRepository
    {
        public UserAccountRepository(ApplicationDbContext context) : base(context) { }
    }
}
