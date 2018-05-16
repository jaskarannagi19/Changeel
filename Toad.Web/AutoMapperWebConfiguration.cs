using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toad.Data;
using Toad.Web.Models;

namespace Toad.Web
{
    public static class AutoMapperWebConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile(new ChangeProfile());
            });

        }
    }

    public class ChangeProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<ChangeModel, ChangeTable>();
            CreateMap<ChangeTable, ChangeModel>();
            //.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            //.ForMember(dest => dest.Title,opt=>opt.MapFrom(src => src.Title));
            CreateMap<TagModel, TagTable>();
            CreateMap<UserModel, UserTable>();
            CreateMap<UserTable, UserModel>();
            CreateMap<CommentModel, CommentTable>();
            CreateMap<CommentTable, CommentModel>();
            CreateMap<VoteModel, VoteTable>();
            CreateMap<PrecursorModel, ChangePrecursorTable>();
            CreateMap<ConstraintModel,ConstraintTable>();
            CreateMap<BlogModel, BlogTable>();
            CreateMap<FreeCommentModel, FreeComment>();
        }
    }
}