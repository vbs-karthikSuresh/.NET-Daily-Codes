using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_api_core.Models;
using web_api_core.ViewModel;

namespace web_api_core.Repository
{
    public class PostRepository: IPostRepository
    {
            AdventureWorks2017Context db;//Context Class 
            public PostRepository(AdventureWorks2017Context db)//Constructor dependency injection
            {
                this.db = db;
            }
            public async Task<int> AddPosts(Post post)
            {
                if (db != null)
                {
                    await db.Post.AddAsync(post);
                    await db.SaveChangesAsync();
                    return post.PostId;
                }
                return 0;
            }

            public async Task<int> DeletePosts(int? PostId)
            {
                int result = 0;

                if (db != null)
                {
                    var post = await db.Post.FindAsync(PostId);
                    if (post != null)
                    {
                        db.Post.Remove(post);//Deleting the post 
                        result = await db.SaveChangesAsync();//saving changes 

                    }
                    return result;
                }
                return -1;
            }

            public async Task<List<Category>> GetCategories()
            {
                return await db.Category.ToListAsync();

            }

            public async Task<PostViewModel> GetPost(int? PostId)
            {

                if (db != null)
                {
                    return await (from p in db.Post
                                  from c in db.Category
                                  where p.PostId == PostId && p.CategoryId == c.Id
                                  select new PostViewModel
                                  {
                                      PostId = p.PostId,
                                      Title = p.Title,
                                      Description = p.Description,
                                      CategoryId = p.CategoryId,
                                      CategoryName = c.Name,
                                      CreatedDate = p.CreatedDate
                                  }).SingleOrDefaultAsync();
                }
                return null;
            }

            public async Task<List<PostViewModel>> GetPosts()
            {
                // return await db.Post.ToListAsync();
                if (db != null)
                {
                    return await (from p in db.Post
                                  from c in db.Category
                                  where p.CategoryId == c.Id
                                  select new PostViewModel
                                  {
                                      PostId = p.PostId,
                                      Title = p.Title,
                                      Description = p.Description,
                                      CategoryId = p.CategoryId,
                                      CategoryName = c.Name,
                                      CreatedDate = p.CreatedDate
                                  }).ToListAsync();
                }
                return null;
            }

            public async Task UpdatePost(Post post)
            {
                if (db != null)
                {
                    db.Post.Update(post);

                    await db.SaveChangesAsync();
                }
            }
    }
}

