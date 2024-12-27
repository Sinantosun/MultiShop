namespace MultiShop.RapidApiWebUI.Models
{
    public class ResultWeatherModel
    {
        public Current_Observation current_observation { get; set; }

        public class Current_Observation
        {
            public Condition condition { get; set; }
        }

        public class Condition
        {
            public int temperature { get; set; }
            public string text { get; set; }
            public int code { get; set; }
        }


    }
}
