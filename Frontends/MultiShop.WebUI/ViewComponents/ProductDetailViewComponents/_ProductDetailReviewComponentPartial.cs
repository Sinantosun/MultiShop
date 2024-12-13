using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.CommentDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailReviewComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ProductDetailReviewComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            //var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync($"https://localhost:7075/api/Comments/GetCommentListByProductId?productId={id}");
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //    var result = JsonConvert.DeserializeObject<ResultProductReviewByProductIdDto>(jsonData);


            //    return View(result);

            //}
            ResultProductReviewByProductIdDto result = new ResultProductReviewByProductIdDto
            {
                UserComments = new List<UserComents>
                {
                    new UserComents
                    {
                        NameSurname="sinan",
                        CommentDetail="test",
                        CreatedDate= DateTime.Now,
                        Email="test@gmail.com",
                        Status=true,
                        ImageUrl="test",
                        ProductId=id,
                        Rating=3,
                        UserCommentId=2,
                    }
                },
                ProductId = id,
                ProductReviewCount = 50,
            };




            return View(result);
        }
    }
}
