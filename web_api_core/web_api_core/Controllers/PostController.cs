using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_api_core.Repository;

namespace web_api_core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        IPostRepository postRepository;
        public PostController(PostRepository postRepository)
        {
            this.postRepository = postRepository;
        }
        //public PostController(IPostRepository _postRepository)
        //{
        //    postRepository = _postRepository;
        //}
        [HttpGet]
        [Route("GetCategories")]
        public async Task<IActionResult> GetCategories()
        {
            try
            {
                var categories = await postRepository.GetCategories();
                if (categories == null)
                {
                    return NotFound();
                }
                return Ok(categories);
            }
            catch (Exception)
            {
                return BadRequest();

            }
        }
    }
}
