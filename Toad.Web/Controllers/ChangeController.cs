using AutoMapper;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Toad.Data;
using Toad.Service;
using Toad.Web.Models;

namespace Toad.Web.Controllers
{
    public class ChangeController : Controller
    {
        private readonly IChangeService _changeService;
        private readonly IUserService _userService;

        public ChangeController(IChangeService changeService, IUserService userService)
        {
            _changeService = changeService;
            _userService = userService;

        }
        // GET: Change
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Ask()
        {
            return View();
        }

        [Authorize]
        public JsonResult SubmitChange(ChangeModel model)
        {
            var change = Mapper.Map<ChangeTable>(model);
            var userId = User.Identity.GetUserId();
            var result = _changeService.SaveChange(change,userId);
            return Json(result);
        }

        [HttpGet]
        public JsonResult GetCategories()
        {
            var result = _changeService.GetCategories();
            return Json(result,JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddTag(TagModel tagModel)
        {
            var tagTable = Mapper.Map<TagTable>(tagModel);
            var result = _changeService.AddTag(tagTable);
            return Json(result,JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetChanges()
        {
            var response = _changeService.GetChanges().ToList();
            var result = new List<ChangeModel>();
            foreach(var change in response)
            {
                var changeModel = Mapper.Map<ChangeModel>(change);
                changeModel.Proposals = _changeService.GetNumCommentbyChangeId(changeModel.Id);
                changeModel.DisplayDateTime = _changeService.TimeAgo(changeModel.TimeStamp);
                result.Add(changeModel);
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        

        [AllowAnonymous]
        public ActionResult Read(string searchTitle)
        {
            string url = Request.Url.AbsolutePath;
            string search = url.Split('/').Last();
            var change = _changeService.GetChange(search);
            var tags = _changeService.GetChangeTags(change.Id);
            var comments = _changeService.GetCommentbyChangeId(change.Id);
            
            var commentList = new List<CommentModel>();
            foreach (var comment in comments)
            {

                var user = _changeService.GetCommentUser(comment.Id);

                var commentModel = Mapper.Map<CommentModel>(comment);

                var userModel = Mapper.Map<UserModel>(user);

                commentModel.User = userModel;

                commentModel.SeeMore = commentModel.Content.Length > 150 ? true : false;

                if(commentModel.Content.Length > 150)
                {
                    commentModel.Content = commentModel.Content.Substring(0, 150);
                }
                else
                {
                    commentModel.Content = commentModel.Content;
                }

                commentModel.TotalVotes = comment.TotalVotes;

                commentList.Add(commentModel);
            }
            commentList = commentList.OrderByDescending(x=>x.TotalVotes).ToList();
            var tagIds = new List<int>();
            foreach (var tag in tags)
            {
                tagIds.Add(tag.Id);
            }

            var author = _userService.GetAuthorByChangeId(change.Id);
            var relatedQuestions = _changeService.GetRelatedQuestionsByTagIds(tagIds);
            var viewCounter=_changeService.IncreaseView(change.Id);
            var changePrecursor = _changeService.GetChangePrecursors(change.Id);
            var changeConstraints = _changeService.GetListOfConstraints(change.Id);
            var noOfFollowers = _changeService.GetNumberOfFollowers(change.Id);
            var noOfUserFollowers = _userService.GetNumberOfFollowers(author.Id);
            
            relatedQuestions.Remove(change);
            ViewData["author"]  = author;
            ViewData["change"] = change;
            ViewData["tags"] = tags;
            ViewData["relatedQuestions"] = relatedQuestions;
            ViewData["comments"] = commentList;
            ViewData["views"] = viewCounter;
            ViewData["time"] = change.TimeStamp.ToString("s") + "Z";
            ViewData["changePrecursor"] = changePrecursor;
            ViewData["changeConstraints"] = changeConstraints;
            ViewData["followers"] = noOfFollowers;
            ViewData["UserFollowers"] = noOfUserFollowers;
            return View(commentList);
        }
        [Authorize]
        public PartialViewResult LeaveReply(int changeId)
        {
            ViewData["id"] = changeId;
            return PartialView("_LeaveReply");
        }
        public JsonResult PostComment(CommentModel model)
        {
            var userId = User.Identity.GetUserId();
            string ip = Request.UserHostAddress;
            model.TimeStamp = DateTime.UtcNow;
            model.IPAddress = ip;
            var commentTable = Mapper.Map<CommentTable>(model);
            var result = _changeService.PostComment(commentTable, userId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public string GetFullComment(int commentId)
        {
            var comment = _changeService.GetFullComment(commentId);
            return comment;
        }
        public JsonResult CastVote(VoteModel vModel)
        {
            var vTable = Mapper.Map<VoteTable>(vModel);
            var userId = User.Identity.GetUserId();
            var voteCasted = _changeService.CastVote(vTable,userId);
            return Json(voteCasted);
        }
        public JsonResult NewProposal(ChangeModel cModel)
        {
            var comments = _changeService.GetCommentbyChangeId(cModel.Id);
            var commentList = new List<CommentModel>();
            foreach (var comment in comments)
            {

                var user = _changeService.GetCommentUser(comment.Id);
                var commentModel = Mapper.Map<CommentModel>(comment);
                var userModel = Mapper.Map<UserModel>(user);
                commentModel.User = userModel;
                commentModel.SeeMore = commentModel.Content.Length > 150 ? true : false;
                if (commentModel.Content.Length > 150)
                {
                    commentModel.Content = commentModel.Content.Substring(0, 150);
                }
                else
                {
                    commentModel.Content = commentModel.Content;
                }
                commentModel.TotalVotes = comment.TotalVotes;
                commentList.Add(commentModel);
            }
            commentList = commentList.OrderByDescending(x => x.TimeStamp).ToList();

            return Json(commentList);
        }
        //public JsonResult Trending(ChangeModel cModel)
        //{
        //    var comments = _changeService.GetCommentbyChangeId(cModel.Id);
        //    var commentList = new List<CommentModel>();
        //    foreach (var comment in comments)
        //    {

        //        var user = _changeService.GetCommentUser(comment.Id);
        //        var commentModel = Mapper.Map<CommentModel>(comment);
        //        var userModel = Mapper.Map<UserModel>(user);
        //        commentModel.User = userModel;
        //        commentModel.SeeMore = commentModel.Content.Length > 150 ? true : false;
        //        if (commentModel.Content.Length > 150)
        //        {
        //            commentModel.Content = commentModel.Content.Substring(0, 150);
        //        }
        //        else
        //        {
        //            commentModel.Content = commentModel.Content;
        //        }
        //        commentModel.TotalVotes = comment.TotalVotes;
        //        commentList.Add(commentModel);
        //    }
        //    commentList = commentList.OrderByDescending(x => x.TimeStamp).ToList();

        //    return Json(commentList);
        //}
        public JsonResult AddPrecursor(PrecursorModel pModel)
        {
            var changePrecursorTable = Mapper.Map <ChangePrecursorTable>(pModel);
            changePrecursorTable.TimeStamp = DateTime.UtcNow;
            var userId = User.Identity.GetUserId();
            var result = new BaseResponse();
            result.Message = "Invalid Add";
            if(User.Identity.GetUserId() == null)
            {
                result.Message = "Please Login to Add";
                return Json(result);
            }
            if (pModel.MainChangeId != pModel.ChangeId) { 
             result = _changeService.AddPrecursor(changePrecursorTable, userId);
            }
            return Json(result);
        }
        public JsonResult SearchChange(SearchModel sModel)
        {
            var result = _changeService.SearchText(sModel.SearchText.Trim());
            return Json(result);
        }
        public JsonResult AddConstraint(ConstraintModel cModel)
        {
            var userId = User.Identity.GetUserId();
            cModel.TimeStamp = DateTime.UtcNow;
            var constraintTable = Mapper.Map<ConstraintTable>(cModel);
            var result = _changeService.AddConstraint(constraintTable, userId);
            return Json(result);
        }
        public JsonResult FollowChange(ChangeFollowerTable cTable)
        {
            var userId = User.Identity.GetUserId();
            cTable.TimeStamp = DateTime.UtcNow;
            var result = _changeService.FollowChange(cTable,userId);
            return Json(result);
        }
        public JsonResult AddChildComment(CommentModel model)
        {
            var userId = User.Identity.GetUserId();
            string ip = Request.UserHostAddress;
            model.TimeStamp = DateTime.UtcNow;
            model.IPAddress = ip;
            var id = model.Id;
            model.Id = 0;
            var commentTable = Mapper.Map<CommentTable>(model);
            var result = _changeService.AddChildComment(commentTable, userId,id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [Authorize]
        public ActionResult Write()
        {
            return View();
        }
        public PartialViewResult AnonymousReply(int changeId)
        {
            ViewData["id"] = changeId;
            return PartialView("_anonymousReply");
        }
        public JsonResult FreeComment(FreeCommentModel cModel)
        {
            cModel.DateTime = DateTime.UtcNow;
            cModel.IP = Request.UserHostAddress;
            var cTable = Mapper.Map <FreeComment>(cModel);
            var result = _changeService.PostFreeComment(cTable);
            return Json(result,JsonRequestBehavior.AllowGet);
        }

    }
}