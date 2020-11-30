using DAL.Helper;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class PostsRepository:PostsRepositoryIF
    {
        private IDatabaseHelper _dbHelper;
        public PostsRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public List<Post> get_list_posts()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "get_list_posts");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<Post>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public bool Add_Post(Post p)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "add_posts",
                 "@idCategory",p.idCategory,
                 "@briefDescription",p.briefDescription,
                 "@Description",p.Description,
                 "@metaKey",p.metaKey,
                 "@metaDescription",p.metaDescription,
                 "@orderFooter",p.orderFooter,
                 "@image",p.image,
                 "@datePost", p.datePost
                );
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Update_Posts(Post p)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "update_posts",
                    "@idPosts",p.idPosts,
                   "@idCategory", p.idCategory,
                 "@briefDescription", p.briefDescription,
                 "@Description", p.Description,
                 "@metaKey", p.metaKey,
                 "@metaDescription", p.metaDescription,
                 "@orderFooter", p.orderFooter,
                 "@image", p.image,
                 "@datePost", p.datePost
                );
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Post> pagination_Category(int currPage, int recodperpage, int Pagesize)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "paginationPosts",
                    "@currPage", currPage,
                    "@recodperpage", recodperpage,
                    "@Pagesize", Pagesize);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<Post>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public List<Post> Search_Posts(int pageIndex, int pageSize, out long total, int idCategory, string metaKey)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "Search_posts",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@idCategory", idCategory,
                    "@metaKey", metaKey);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<Post>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    
}
}
