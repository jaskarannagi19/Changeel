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
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        // GET: User
        [Authorize]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var userInfo = _userService.GetProfileInfo(userId);
            int [] quesAns= _userService.GetNumOfQuesAndAns(userId);
            ViewData["questions"] = quesAns[0];
            @ViewData["answers"] =  quesAns[1];
            return View(userInfo);
        }

        public ActionResult Profile()
        {
            return View();
        }
        public JsonResult SaveUserDetails(UserModel model)
        {
            var userDetails = Mapper.Map<UserTable>(model);
            userDetails.AspNetUserId = User.Identity.GetUserId();
           
            var result = _userService.SaveUserDetails(userDetails);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult UserQuestions()
        {
            var userId = User.Identity.GetUserId();

            var userChanges = _userService.GetChangesByUser(userId);
            return PartialView(userChanges);
        }
        public JsonResult FollowUser(UserFollowers ufTable)
        {
            ufTable.TimeStamp = DateTime.Now;
            var userId = User.Identity.GetUserId();
            var result = _userService.FollowUser(ufTable, userId);
            return Json(result);
        }
        public JsonResult HeartBeat()
        {
            string result = "session expired";
            if (User.Identity.GetUserId() != null)
            {
                result = "true";
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }
    }
}