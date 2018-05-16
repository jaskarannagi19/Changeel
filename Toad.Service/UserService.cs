using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toad.Data;

namespace Toad.Service
{
    public class UserService: IUserService
    {
        public readonly ChangeContext _context;
        public UserService(ChangeContext context)
        {
            _context = context;
        }
        public BaseResponse SaveUserDetails(UserTable userDetails)
        {
            var result = new BaseResponse();
            userDetails.TimeStamp = DateTime.UtcNow;
            try
            {
                _context.UserTable.Add(userDetails);
                _context.SaveChanges();
                result.Success = true;
                result.Message = "OK";
            }
            catch(Exception ex)
            {
                result.Success = false;
                result.Message = ex.InnerException.ToString();
            }
            return result;
        }

        public UserTable GetAuthorByChangeId(int Id)
        {
            var userId = _context.UserChangesTable.Where(x => x.ChangeId == Id).SingleOrDefault().UserId;
            var user = _context.UserTable.Where(x => x.Id == userId).SingleOrDefault();
            return user;
        }
        public UserTable GetProfileInfo(string userId)
        {
            var user = _context.UserTable.Where(x => x.AspNetUserId == userId).SingleOrDefault();
            return user;
        }

        public int[] GetNumOfQuesAndAns(string userId)
        {
            var userid = _context.UserTable.Where(x => x.AspNetUserId == userId).Single().Id;
            int numQues = _context.UserChangesTable.Where(x => x.UserId == userid).Count();
            int numAns = _context.UserCommentTable.Where(x => x.UserId == userid).Count();
            int[] total = { numQues , numAns };
            return total;
        }

        public List<ChangeTable> GetChangesByUser(string userId)
        {
            var result = new List<ChangeTable>();
            var userid = _context.UserTable.Where(x => x.AspNetUserId== userId).SingleOrDefault().Id;
            var changesList = _context.UserChangesTable.Where(x => x.UserId == userid).ToList();
            foreach (var change in changesList)
            {
                var chang = _context.Change.Where(x => x.Id == change.ChangeId).Single();
                result.Add(chang);
            }
            return result;
        }
        public BaseResponse FollowUser(UserFollowers ufTable, string userId)
        {
            var result = new BaseResponse();
            try
            {
                var internalUserId = _context.UserTable.Where(x => x.AspNetUserId == userId).Single().Id;
                ufTable.FollowingUserId= internalUserId;
                _context.UserFollowerTable.Add(ufTable);
                _context.SaveChanges();
                result.Message = "Now you follow this user";
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }
            return result;
        }
        public int GetNumberOfFollowers(int userId)
        {
            var result = _context.UserFollowerTable.Where(x => x.MainUserId == userId).Count();
            return result;
        }
        public UserTable GetUserById(int userId)
        {
            var result = _context.UserTable.Where(x => x.Id == userId).Single();
            return result;
        }
    }
}
