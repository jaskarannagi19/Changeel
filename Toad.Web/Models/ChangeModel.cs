using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Toad.Web.Models
{
    public class ChangeModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool isPool { get; set; }
        public string Details { get; set; }
        public string SearchTitle { get; set; }
        public string question_poll { get; set; }
        public string question_tags { get; set; }
        public TagModel Tags { get; set; }
        public CategoryModel Categories { get; set; }
        public int ViewCounter { get; set; }
        public int Proposals { get; set; }
        public DateTime TimeStamp { get; set; }
        public string DisplayDateTime { get; set; }
    }

    public class TagModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }

    public class CategoryModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}