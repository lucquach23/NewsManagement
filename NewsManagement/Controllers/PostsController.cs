using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;
using BLL.Interfaces;
using Model;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly NewsManagementDBContext _context;
        private PostsBusinessIF _res;
        public PostsController(NewsManagementDBContext context, PostsBusinessIF r)
        {
            _context = context;
            this._res = r;
        }
        [Route("get_list_posts")]
        [HttpGet]
        public List<Post> get_list_posts()
        {
            return this._res.get_list_posts();
        }
        [Route("add_posts")]
        [HttpPost]
        public Post Add_Category([FromBody] Post p)
        {
            _res.Add_Post(p);
            return p;

        }
        [Route("update_posts")]
        [HttpPost]
        public Post Update_Category([FromBody] Post p)
        {
            _res.Update_Posts(p);
            return p;
        }
        [Route("pagination_Posts/{currPage}/{recodperpage}/{Pagesize}")]
        [HttpGet]
        public List<Post> pagination_Category(int currPage, int recodperpage, int Pagesize)
        {
            return _res.pagination_Category(currPage, recodperpage, Pagesize).ToList();
        }
        [Route("search_posts")]
        [HttpPost]
        public ResponseModel Search([FromBody] Dictionary<string, object> formData)
        {
            var response = new ResponseModel();
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                var idCategory = int.Parse(formData["idCategory"].ToString());
                var metaKey = formData["metaKey"].ToString();
                long total = 0;
                var data = _res.Search_Posts(page, pageSize, out total, idCategory, metaKey);
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























        // GET: api/Posts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Posts>>> GetPosts()
        {
            return await _context.Posts.ToListAsync();
        }

        // GET: api/Posts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Posts>> GetPosts(int id)
        {
            var posts = await _context.Posts.FindAsync(id);

            if (posts == null)
            {
                return NotFound();
            }

            return posts;
        }

        // PUT: api/Posts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPosts(int id, Posts posts)
        {
            if (id != posts.idPosts)
            {
                return BadRequest();
            }

            _context.Entry(posts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Posts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Posts>> PostPosts(Posts posts)
        {
            _context.Posts.Add(posts);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPosts", new { id = posts.idPosts }, posts);
        }

        // DELETE: api/Posts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Posts>> DeletePosts(int id)
        {
            var posts = await _context.Posts.FindAsync(id);
            if (posts == null)
            {
                return NotFound();
            }

            _context.Posts.Remove(posts);
            await _context.SaveChangesAsync();

            return posts;
        }

        private bool PostsExists(int id)
        {
            return _context.Posts.Any(e => e.idPosts == id);
        }
    }
}
