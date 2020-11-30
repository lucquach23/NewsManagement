using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public partial interface PostsRepositoryIF
    {
        List<Post> get_list_posts();
        bool Add_Post(Post p);
        bool Update_Posts(Post p);
        List<Post> pagination_Category(int currPage, int recodperpage, int Pagesize);
        List<Post> Search_Posts(int pageIndex, int pageSize, out long total, int idCategory, string metaKey);
    }
}
