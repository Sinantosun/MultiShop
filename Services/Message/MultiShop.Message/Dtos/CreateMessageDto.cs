﻿namespace MultiShop.Message.Dtos
{
    public class CreateMessageDto
    {
        public string SenderId { get; set; }
        public string ReviverId { get; set; }
        public string Subject { get; set; }
        public string MessageDetail { get; set; }
        public bool IsRead { get; set; }
        public DateTime MesssageDate { get; set; }
    }
}