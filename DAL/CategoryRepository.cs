using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Helper;
using DAL.Interfaces;
using Model;

namespace DAL
{
    public class CategoryRepository: CategoryRepositoryIF
    {
        private IDatabaseHelper _dbHelper;
        public CategoryRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public List<Category> get_list_category()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "get_list_category");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<Category>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public bool Add_Category(Category ctg)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "add_category",
                "@parentIdCategory",ctg.parentIdCategory,
                "@rankCategory",ctg.rankCategory,
                "@titleCategory",ctg.titleCategory,
                "@showMenu",ctg.showMenu,
                "@orderDisplay",ctg.orderDisplay,
                "@showPage",ctg.showPage,
                "@orderShowPage",ctg.orderShowPage,
                "@showFooter",ctg.showFooter,
                "@orderShowFooter",ctg.orderShowFooter,
                "@icon",ctg.icon
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
        public bool Update_Category(Category ctg)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "update_category",
                    "@idCategory",ctg.idCategory,
                "@parentIdCategory", ctg.parentIdCategory,
                "@rankCategory", ctg.rankCategory,
                "@titleCategory", ctg.titleCategory,
                "@showMenu", ctg.showMenu,
                "@orderDisplay", ctg.orderDisplay,
                "@showPage", ctg.showPage,
                "@orderShowPage", ctg.orderShowPage,
                "@showFooter", ctg.showFooter,
                "@orderShowFooter", ctg.orderShowFooter,
                "@icon", ctg.icon
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
        public List<Category> pagination_Category(int currPage ,int recodperpage ,int Pagesize)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "paginationCategory",
                    "@currPage",currPage,
                    "@recodperpage",recodperpage,
                    "@Pagesize",Pagesize);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<Category>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public List<Category> Search(int pageIndex, int pageSize, out long total, int idCategory, int showMenu)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "Search_category",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@idCategory", idCategory,
                    "@showMenu", showMenu);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<Category>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
