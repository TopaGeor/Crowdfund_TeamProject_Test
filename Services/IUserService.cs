using Crowdfund.Core.Model;
using Crowdfund.Core.Model.Options;
using System.Collections.Generic;

namespace Crowdfund.Core.Services
{
    interface IUserService
    {
        bool CreateUser(AddUserOptions options);

        bool UpdateUser(int id,UpdateUserOptions options);

        ICollection<User> SearchByUser(SearchUserOptions options);
    }
}
