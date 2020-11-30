using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private CategoryBusinessIF _ctg;
        
       
        public CategoryController(CategoryBusinessIF res)
        {
            _ctg = res;
           
        }
        
        [Route("list_category")]
        [HttpGet]
        public List<Category> get_list_category()
        {
            return _ctg.get_list_category().ToList();
        }
        [Route("add_category")]
        [HttpPost]
        public Category Add_Category([FromBody] Category ctg)
        {
            _ctg.Add_Category(ctg);
            return ctg;

        }
        [Route("update_category")]
        [HttpPost]
        public Category Update_Category([FromBody] Category ctg)
        {
            _ctg.Update_Category(ctg);
            return ctg;
        }
        [Route("pagination_Category/{currPage}/{recodperpage}/{Pagesize}")]
        [HttpGet]
        public List<Category> pagination_Category(int currPage, int recodperpage, int Pagesize)
        {
            return _ctg.pagination_Category(currPage, recodperpage, Pagesize).ToList();
        }
        [Route("search")]
        [HttpPost]
        public ResponseModel Search([FromBody] Dictionary<string, object> formData)
        {
            var response = new ResponseModel();
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                var idCategory = int.Parse(formData["idCategory"].ToString());
                var showMenu = int.Parse(formData["showMenu"].ToString());
                long total = 0;
                var data = _ctg.Search(page, pageSize, out total, idCategory, showMenu);
                response.TotalItems = total;
                response.Data = data;
                response.Page = page;
                response.PageSize = pageSize;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return response;
        }
    }
}
