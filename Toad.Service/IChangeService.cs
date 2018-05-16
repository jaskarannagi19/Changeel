using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toad.Data;

namespace Toad.Service
{
    public interface IChangeService
    {
        BaseResponse SaveChange(ChangeTable model,string userId);
        List<KeyValuePair<int, string>> GetCategories();
        BaseResponse AddTag(TagTable tagModel);
        IQueryable<ChangeTable> GetChanges();
        ChangeTable GetChange(string searchTitle);
        List<TagTable> GetChangeTags(int changeId);
        List<ChangeTable> GetRelatedQuestionsByTagIds(List<int> tagIds);
        BaseResponse PostComment(CommentTable commentTable, string userId);
        List<CommentTable> GetCommentbyChangeId(int id);
        int IncreaseView(int changeId);
        UserTable GetCommentUser(int commentId);
        string GetFullComment(int commentId);
        BaseResponse CastVote(VoteTable vModel,string userId);
        BaseResponse AddPrecursor(ChangePrecursorTable changePrecursorTable, string userId);
        List<ChangeTable> SearchText(string searchText);
        List<ChangeTable> GetChangePrecursors(int changeId);
        BaseResponse AddConstraint(ConstraintTable cTable,string userId);
        List<ConstraintTable> GetListOfConstraints(int changeId);
        BaseResponse FollowChange(ChangeFollowerTable cTable, string userId);
        int GetNumberOfFollowers(int changeId);
        BaseResponse AddChildComment(CommentTable commentTable, string userId, int proposalId);
        List<Data.ChildComment> GetChildComment(int proposalId);
        BaseResponse WriteBlog(BlogTable bTable,string userId);
        List<BlogTable> GetListOfBlogs(int pageNo);
        BlogTable GetBlogById(int blogId);
        int GetNumCommentbyChangeId(int id);
        string TimeAgo(DateTime dateTime);
        BaseResponse PostFreeComment(FreeComment cTable);
        List<FreeComment> GetBlogComments(int id);
    }
}
