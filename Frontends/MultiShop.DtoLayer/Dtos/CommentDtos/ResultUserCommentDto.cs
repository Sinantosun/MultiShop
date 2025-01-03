﻿namespace MultiShop.DtoLayer.Dtos.CommentDtos
{
    public class ResultUserCommentDto
    {
        public int UserCommentId { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string? ImageUrl { get; set; }
        public int Rating { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CommentDetail { get; set; }

        public bool Status { get; set; }

        public string ProductId { get; set; }
        public string ProductName { get; set; }
    }

}
