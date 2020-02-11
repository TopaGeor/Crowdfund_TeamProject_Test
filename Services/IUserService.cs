using System;
using System.Collections.Generic;
using System.Text;
using Crowdfund.Core.Model;
using Crowdfund.Core.Model.Options;


namespace Crowdfund.Core.Services
{
    interface IUserService
    {
        bool CreateUser(AddUserOptions options);

        bool UpdateUser(int id,UpdateUserOptions options);

        ICollection<User> SearchByUser(SearchUserOptions options);
    }
}
