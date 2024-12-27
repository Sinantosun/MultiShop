namespace MultiShop.RapidApiWebUI.Models
{
    public class ExchangeViewModel
    {
        public Data data { get; set; }


        public class Data
        {
            public string from_symbol { get; set; }
            public string to_symbol { get; set; }
            public float exchange_rate { get; set; }
            public string last_update_utc { get; set; }
        }

    }
}
