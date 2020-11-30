using System;
using System.Collections.Generic;
using System.Text;
using BLL.Interfaces;
using DAL.Interfaces;
using Model;

namespace BLL
{
    public partial class CategoryBusiness : CategoryBusinessIF
    {
        private CategoryRepositoryIF _res;
        public CategoryBusiness(CategoryRepositoryIF cos)
        {
            _res = cos;
        }
        public List<Category> get_list_category()
        {
            return _res.get_list_category();
        }
        public bool Add_Category(Category ctg)
        {
            return _res.Add_Category(ctg);
        }
        public bool Update_Category(Category ctg)
        {
            return _res.Update_Category(ctg);
        }
        public List<Category> pagination_Category(int currPage, int recodperpage, int Pagesize)
        {
            return _res.pagination_Category(currPage, recodperpage, Pagesize);
        }
        public List<Category> Search(int pageIndex, int pageSize, out long total, int idCategory, int showMenu)
        {
            return _res.Search(pageIndex, pageSize,out total, idCategory, showMenu);
        }
    }
}
