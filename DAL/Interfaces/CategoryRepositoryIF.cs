using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public partial interface CategoryRepositoryIF
    {
        List<Category> get_list_category();
        bool Add_Category(Category ctg);
        bool Update_Category(Category ctg);
        List<Category> pagination_Category(int currPage, int recodperpage, int Pagesize);
        List<Category> Search(int pageIndex, int pageSize, out long total, int idCategory, int showMenu);
    }
}
