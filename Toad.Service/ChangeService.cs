using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toad.Data;
using Toad.Data.Database;

namespace Toad.Service
{
    public class ChangeService : IChangeService
    {
        private readonly ChangeContext _context;

        public ChangeService(ChangeContext context)
        {
            _context = context;
        }
        public BaseResponse SaveChange(ChangeTable model, string userId)
        {
            var response = new BaseResponse();

            model.TimeStamp = DateTime.UtcNow;

            model.SearchTitle = model.Title.Replace(" ", "_");

            model.ViewCounter = 0;

            _context.Change.Add(model);

            var userChange = new UserChangeTable();

            int userInternalId = _context.UserTable.Where(x => x.AspNetUserId == userId).Single().Id;

            userChange.UserId = userInternalId;

            try {
                _context.SaveChanges();                  //TODO jugaad here use single save changes and make aspnetuserid as universal remove userinternalid == more optimised

                userChange.ChangeId = model.Id;

                _context.UserChangesTable.Add(userChange);

                _context.SaveChanges();

                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public List<KeyValuePair<int, string>> GetCategories()
        {
            var response = new List<KeyValuePair<int, string>>();
            var categories = _context.Categories.ToList();
            foreach (var category in categories)
            {
                response.Add(new KeyValuePair<int, string>(category.Id, category.Title));
            }
            return response;
        }

        public BaseResponse AddTag(TagTable tagModel)
        {
            var response = new BaseResponse();
            _context.Tags.Add(tagModel);

            try
            {
                _context.SaveChanges();
                response.Success = true;
                response.Message = "New Tag Saved";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
        public IQueryable<ChangeTable> GetChanges()
        {
            var response = _context.Change.OrderBy(x => x.TimeStamp).Take(10);
            return response;
        }

        public ChangeTable GetChange(string searchTitle)
        {
            var response = _context.Change.Where(x => x.SearchTitle == searchTitle).FirstOrDefault();
            return response;
        }

        public List<TagTable> GetChangeTags(int changeId)
        {
            var tagIds = _context.ChangeTagIds.Where(x => x.ChangeId == changeId).ToList();
            var tags = _context.Tags;
            var response = new List<TagTable>();
            foreach (var tagId in tagIds)
            {
                var tag = tags.Where(x => x.Id == tagId.TagsId).SingleOrDefault();
                response.Add(tag);
            }
            return response;
        }

        public List<ChangeTable> GetRelatedQuestionsByTagIds(List<int> tagIds)
        {
            var changeIds = _context.ChangeTagIds.Where(x => tagIds.Contains(x.TagsId)).Select(x => x.ChangeId).Distinct().OrderBy(r => Guid.NewGuid()).Take(5).ToList();
            var changes = _context.Change.Where(x => changeIds.Contains(x.Id)).ToList();
            return changes;
        }


        public BaseResponse AddChildComment(CommentTable commentTable, string userId,int proposalId)
        {
            var response = new BaseResponse();
            try
            {
                var comment = _context.CommentTable.Add(commentTable);

                _context.SaveChanges();

                var internalUserId = _context.UserTable.Where(x => x.AspNetUserId == userId).Single().Id;

                var userComment = new UserCommentTable();

                userComment.UserId = internalUserId;

                userComment.CommentId = comment.Id;

                _context.UserCommentTable.Add(userComment);

                var childComment = new Data.ChildComment();
                childComment.ProposalId = proposalId;
                childComment.ChildCommentId = comment.Id;
                _context.ChildComment.Add(childComment);

                _context.SaveChanges();

                response.Message = "OK";

                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
        public BaseResponse PostComment(CommentTable commentTable, string userId)
        {
            var response = new BaseResponse();
            try
            {
                var comment=_context.CommentTable.Add(commentTable);

                _context.SaveChanges();

                var internalUserId = _context.UserTable.Where(x => x.AspNetUserId == userId).Single().Id;

                var userComment = new UserCommentTable();

                userComment.UserId = internalUserId;

                userComment.CommentId = comment.Id;

                _context.UserCommentTable.Add(userComment);

                _context.SaveChanges();

                response.Message = "OK";

                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
        public string TimeAgo(DateTime dateTime)
        {
            string result = string.Empty;
            var timeSpan = DateTime.Now.Subtract(dateTime);

            if (timeSpan <= TimeSpan.FromSeconds(60))
            {
                result = string.Format("{0} seconds ago", timeSpan.Seconds);
            }
            else if (timeSpan <= TimeSpan.FromMinutes(60))
            {
                result = timeSpan.Minutes > 1 ?
                    String.Format("about {0} minutes ago", timeSpan.Minutes) :
                    "about a minute ago";
            }
            else if (timeSpan <= TimeSpan.FromHours(24))
            {
                result = timeSpan.Hours > 1 ?
                    String.Format("about {0} hours ago", timeSpan.Hours) :
                    "about an hour ago";
            }
            else if (timeSpan <= TimeSpan.FromDays(30))
            {
                result = timeSpan.Days > 1 ?
                    String.Format("about {0} days ago", timeSpan.Days) :
                    "yesterday";
            }
            else if (timeSpan <= TimeSpan.FromDays(365))
            {
                result = timeSpan.Days > 30 ?
                    String.Format("about {0} months ago", timeSpan.Days / 30) :
                    "about a month ago";
            }
            else
            {
                result = timeSpan.Days > 365 ?
                    String.Format("about {0} years ago", timeSpan.Days / 365) :
                    "about a year ago";
            }

            return result;
        }
        public List<CommentTable> GetCommentbyChangeId(int id)
        {
            var response = _context.CommentTable.Where(x => x.ChangeID == id).OrderBy(y=>y.TotalVotes).ToList();
            return response;
        }

        public int GetNumCommentbyChangeId(int id)
        {
            var response = _context.CommentTable.Where(x=>x.ChangeID==id).Count();
            return response;
        }

        public List<Data.ChildComment> GetChildComment(int proposalId)
        {
            var response = _context.ChildComment.Where(x => x.ProposalId== proposalId).ToList();
            return response;
        }
        public int IncreaseView(int changeId)
        {
            var change = _context.Change.Where(x => x.Id == changeId).FirstOrDefault();
            change.ViewCounter = change.ViewCounter + 1;
            _context.SaveChanges();
            return change.ViewCounter;
        }

        public UserTable GetCommentUser(int commentId)
        {
            var userId = _context.UserCommentTable.Where(x => x.CommentId == commentId).Single().UserId;
            UserTable user = _context.UserTable.Where(x => x.Id == userId).Single();
            return user;

        }
        public string GetFullComment(int commentId)
        {
            string comment = _context.CommentTable.Where(x => x.Id == commentId).Single().Content.Substring(150);
            return comment;
        }
        public BaseResponse CastVote(VoteTable vModel,string UserId)
        {
            var result = new BaseResponse();
            try
            {
                var internalUserId = _context.UserTable.Where(x => x.AspNetUserId == UserId).Single().Id;
                vModel.UserId = internalUserId;
                var comment = _context.CommentTable.Where(x => x.Id == vModel.CommentId).Single();
                bool userVoteCheck = _context.VoteTable.Any(x => x.UserId == internalUserId && x.CommentId == vModel.CommentId);
                if (userVoteCheck == false) {
                    comment.TotalVotes = comment.TotalVotes + 1;
                    _context.VoteTable.Add(vModel);
                    _context.SaveChanges();
                    result.Message = "OK";
                    result.Success = true;
                }
                else
                {
                    var checkVoteStatusBeforeChange = _context.VoteTable.Where(x => x.UserId == internalUserId && x.CommentId == vModel.CommentId).Single();
                    if (checkVoteStatusBeforeChange.VoteStatus != vModel.VoteStatus)
                    {
                       if(vModel.VoteStatus == true) { comment.TotalVotes = comment.TotalVotes + 1; } else { comment.TotalVotes = comment.TotalVotes - 1; }
                        
                        checkVoteStatusBeforeChange.VoteStatus = vModel.VoteStatus;
                        _context.SaveChanges();
                        result.Message = "Ok vote changed";
                        result.Success = true;
                    }
                }
                
            }
            catch(Exception ex)
            {
                result.Success = false;
                result.Message = ex.InnerException.ToString();
            }
            return result;
        }

        public BaseResponse AddPrecursor(ChangePrecursorTable changePrecursorTable, string userId)
        {
            var result = new BaseResponse();
            try
            {
                changePrecursorTable.UserId = _context.UserTable.Where(x => x.AspNetUserId == userId).Single().Id;
                _context.ChangePrecursorTable.Add(changePrecursorTable);
                _context.SaveChanges();
                result.Success = true;
                result.Message = "Ok";
            }
            catch(Exception ex)
            {
                result.Success = false;
                result.Message = "Lun le lo";
            }
            return result;
        }
        public List<ChangeTable> SearchText(string searchText)
        {
            var result = _context.Change.Where(x => x.Title.ToLower().Contains(searchText.ToLower())).ToList();
            return result;
        }
        public List<ChangeTable> GetChangePrecursors(int changeId)
        {
            var listOfChanges = _context.ChangePrecursorTable.Where(x => x.MainChangeId == changeId).Select(x=>x.ChangeId).ToList();
            var changes = _context.Change.Where(x => listOfChanges.Contains(x.Id)).ToList();
            return changes;
        }
        public BaseResponse AddConstraint(ConstraintTable cTable, string userId)
        {
            var result = new BaseResponse();
            try
            {
                cTable.UserId = _context.UserTable.Where(x => x.AspNetUserId == userId).Single().Id;
                _context.ChangeConstraintTable.Add(cTable);
                _context.SaveChanges();
                result.Message = "Ok";
                result.Success = true;
            }
            catch(Exception ex)
            {
                result.Message = ex.Message;
                result.Success = false;
            }
            return result;
        }
        public List<ConstraintTable> GetListOfConstraints(int changeId)
        {
            var result = _context.ChangeConstraintTable.Where(x => x.ChangeId == changeId).ToList();
            return result;
        }
        public BaseResponse FollowChange(ChangeFollowerTable cfTable, string userId)
        {
            var result = new BaseResponse();
            try
            {
                var internalUserId = _context.UserTable.Where(x => x.AspNetUserId == userId).Single().Id;
                cfTable.UserId = internalUserId;
                _context.ChangeFollowerTable.Add(cfTable);
                _context.SaveChanges();
                result.Message = "Now you follow this change";
                result.Success = true;
            }
            catch(Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }
            return result;
        }
        public int GetNumberOfFollowers(int changeId)
        {
            var result = _context.ChangeFollowerTable.Where(x => x.ChangeId == changeId).Count();
            return result;
        }
        public BaseResponse WriteBlog(BlogTable bTable, string userId)
        {
            var result = new BaseResponse();
            try
            {
                var internalUserId = _context.UserTable.Where(x => x.AspNetUserId == userId).Single().Id;
                bTable.UserId = internalUserId;
                _context.BlogTable.Add(bTable);
                _context.SaveChanges();
                result.Message = "Ok";
                result.Success = true;
            }
            catch(Exception ex)
            {
                result.Message = ex.Message;
                result.Success = false;
            }
            return result;
        }
        public List<BlogTable> GetListOfBlogs(int pageNo)
        {
            var result = _context.BlogTable.OrderByDescending(x => x.TimeStamp).Skip(pageNo * 10).Take(10).ToList();
            return result;
        }
        public BlogTable GetBlogById(int blogId)
        {
            var result = _context.BlogTable.Where(x => x.Id == blogId).Single();
            return result;
        }
        public BaseResponse PostFreeComment(Data.FreeComment cTable)
        {
            var result = new BaseResponse();
            try
            {
                _context.FreeComment.Add(cTable);
                _context.SaveChanges();
                result.Message = "Ok";
                result.Success = false;
            }
            catch(Exception ex)
            {
                result.Message = ex.Message;
                result.Success = false;
            }
            return result;
        }
        public List<Data.FreeComment> GetBlogComments(int id)
        {
            var result = _context.FreeComment.Where(x => x.BlogId == id).ToList();
            return result;
        }
    }
}