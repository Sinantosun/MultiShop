namespace MultiShop.RapidApiWebUI.Models
{
    public class ECommerceModel
    {

        public Data data { get; set; }


        public class Data
        {
            public Product[] products { get; set; }

        }

        public class Product
        {
            public string product_id { get; set; }
            public string product_title { get; set; }
            public string product_description { get; set; }
            public string[] product_photos { get; set; }

            public float product_rating { get; set; }
            public string product_page_url { get; set; }
            public string product_offers_page_url { get; set; }
            public string product_specs_page_url { get; set; }
            public string product_reviews_page_url { get; set; }
            public int product_num_reviews { get; set; }
            public string product_num_offers { get; set; }
            public string[] typical_price_range { get; set; }

        }



    }
}
