using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toad.Data;

namespace Toad.Service
{
    public interface IUserService
    {
        BaseResponse SaveUserDetails(UserTable userDetails);
        UserTable GetAuthorByChangeId(int Id);
        UserTable GetProfileInfo(string userId);
        int[] GetNumOfQuesAndAns(string userId);
        List<ChangeTable> GetChangesByUser(string userId);
        BaseResponse FollowUser(UserFollowers ufTable, string userId);
        int GetNumberOfFollowers(int userId);
        UserTable GetUserById(int userId);
    }
}
