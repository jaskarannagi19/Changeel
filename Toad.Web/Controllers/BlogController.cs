using AutoMapper;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Toad.Data;
using Toad.Service;
using Toad.Web.Models;

namespace Toad.Web.Controllers
{
    public class BlogController : Controller
    {
        private readonly IChangeService _changeService;
        private readonly IUserService _userService;

        public BlogController(IChangeService changeService, IUserService userService)
        {
            _changeService = changeService;
            _userService = userService;

        }
        [Authorize]
        // GET: Blog
        public ActionResult Write()
        {
            return View();
        }
        [Authorize]
        public JsonResult WriteBlog(BlogModel bModel)
        {
            bModel.TimeStamp = DateTime.UtcNow;
            var bTable = Mapper.Map<BlogTable>(bModel);
            string userId = User.Identity.GetUserId();

            var result = _changeService.WriteBlog(bTable, userId);
            return Json(result);
        }

        public JsonResult GetBlogs(int pageNumber)
        {
            var result = _changeService.GetListOfBlogs(pageNumber);
            return Json(result);
        }
        public JsonResult ReadBlog(int blogId)
        {
            var result = _changeService.GetBlogById(blogId);
            return Json(result);
        }
        public ActionResult Read(int id)
        {
            var blog = _changeService.GetBlogById(id);
            var author = _userService.GetUserById(blog.UserId);
            int followers = _userService.GetNumberOfFollowers(author.Id);
            var comments = _changeService.GetBlogComments(blog.Id);
            ViewData["author"] = author;
            ViewData["UserFollowers"] = followers;
            ViewData["comments"] = comments;
            ViewBag.FbTitle = blog.Title;
            ViewBag.Description = blog.SmallDescription;
            ViewBag.Image = blog.BaseImage;
            return View(blog);
        }
        public PartialViewResult AnonymousReply(int blogId)
        {
            ViewData["id"] = blogId;
            return PartialView("_anonymousReply");
        }
        public JsonResult FreeComment(FreeCommentModel cModel)
        {
            cModel.DateTime = DateTime.UtcNow;
            cModel.IP = Request.UserHostAddress;
            var cTable = Mapper.Map<FreeComment>(cModel);
            var result = _changeService.PostFreeComment(cTable);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}