using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiShop.Comment.Context;
using MultiShop.Comment.Dtos;
using MultiShop.Comment.Entites;

namespace MultiShop.Comment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CommentsController : ControllerBase
    {
        private readonly CommentContext _context;
     
        public CommentsController(CommentContext context)
        {
            _context = context;
        }
        [HttpGet("GetMostCommenetProductId")]
        public IActionResult GetMostCommenetProductId()
        {
            var mostCommentProduct = _context.UserComments.GroupBy(t => t.ProductId).Select(g => new
            {
                ProductId = g.Key,
                CommentCount = g.Count()
            }).OrderByDescending(t => t.CommentCount).FirstOrDefault();


            return Ok(mostCommentProduct.ProductId);
        }
        [HttpGet("GetActiveCommentCount")]
        public IActionResult GetActiveCommentCount()
        {
            int value = _context.UserComments.Where(t => t.Status == true).Count();
            return Ok(value);
        }
        [HttpGet("GetTotalCommentCount")]
        public IActionResult GetTotalCommentCount()
        {
            int value = _context.UserComments.Count();
            return Ok(value);
        }
        [HttpGet("GetPasiveCommentCount")]
        public IActionResult GetPasiveCommentCount()
        {
            int value = _context.UserComments.Where(t => t.Status == false).Count();
            return Ok(value);
        }
        [HttpGet("GetCommentListByProductId")]
        public async Task<IActionResult> GetCommentListByProductId(string productId)
        {

            var values = await _context.UserComments.Where(t => t.ProductId == productId).ToListAsync();
            var productreviewcount = _context.UserComments.Where(t => t.ProductId == productId).Count();
            ResultProductReviewByProductIdDto result = new ResultProductReviewByProductIdDto()
            {
                ProductId = productId,
                ProductReviewCount = productreviewcount,
                UserComments = values.Select(t => new UserComents
                {
                    CommentDetail = t.CommentDetail,
                    CreatedDate = DateTime.Now,
                    Email = t.Email,
                    ImageUrl = t.ImageUrl,
                    NameSurname = t.NameSurname,
                    ProductId = t.ProductId,
                    Rating = t.Rating,
                    UserCommentId = t.UserCommentId,
                    Status = t.Status
                }).ToList()
            };
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var values = await _context.UserComments.ToListAsync();

            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _context.UserComments.FindAsync(id);
            return Ok(value);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var value = await _context.UserComments.FindAsync(id);
            _context.UserComments.Remove(value);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateUserCommentDto userComment)
        {
            await _context.UserComments.AddAsync(new UserComment
            {
                Email = userComment.Email,
                Status = userComment.Status,
                CreatedDate = DateTime.Now,
                ImageUrl = userComment.ImageUrl,
                NameSurname = userComment.NameSurname,
                ProductId = userComment.ProductId,
                Rating = userComment.Rating,
                CommentDetail = userComment.CommentDetail,

            });
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateUserCommentDto userComment)
        {
            var value = await _context.UserComments.FindAsync(userComment.UserCommentId);
            value.Rating = userComment.Rating;
            value.CreatedDate = DateTime.Now;
            value.ProductId = userComment.ProductId;
            value.NameSurname = userComment.NameSurname;
            value.Email = userComment.Email;
            value.Status = userComment.Status;
            value.CommentDetail = userComment.CommentDetail;
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
