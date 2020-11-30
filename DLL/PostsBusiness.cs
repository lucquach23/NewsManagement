using BLL.Interfaces;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class PostsBusiness:PostsBusinessIF
    {
        private PostsRepositoryIF _res;
        public PostsBusiness(PostsRepositoryIF r)
        {
            this._res = r;
        }
        public List<Post> get_list_posts()
        {
            return this._res.get_list_posts();
        }
       public bool Add_Post(Post p)
        {
            return _res.Add_Post(p);
        }
        public bool Update_Posts(Post p)
        {
            return _res.Update_Posts(p);
        }
        public List<Post> pagination_Category(int currPage, int recodperpage, int Pagesize)
        {
            return _res.pagination_Category(currPage, recodperpage, Pagesize);
        }
       public List<Post> Search_Posts(int pageIndex, int pageSize, out long total, int idCategory, string metaKey)
        {
            return _res.Search_Posts(pageIndex, pageSize, out total, idCategory, metaKey);
        }

    }
}
