using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_api_core.Models;
using web_api_core.ViewModel;

namespace web_api_core.Repository
{
    interface IPostRepository
    {
        Task<List<Category>> GetCategories();//Get all the Categories of the blosg post
        Task<PostViewModel> GetPost(int? PostId);//Will get all the Posts
        Task<List<PostViewModel>> GetPosts();//Will get Post based oj the ID
        Task<int> AddPosts(Post post);//Will Add post 
        Task<int> DeletePosts(int? postid);//Will delete Post 
        Task UpdatePost(Post post);//Will update Post 
    }
}
