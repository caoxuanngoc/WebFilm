using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFilm.Models.XULY
{
    public class CategoryTT
    {
        Phim2Entities db= null;
        public CategoryTT()
        {
            db = new Phim2Entities();
        }
        public List<Category> ListAll()
        {
            return db.Categories.ToList();
        }
        public Category ViewDetail(long id)
        {
            return db.Categories.Find(id);
        }
    }
}