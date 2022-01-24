using System;
using System.Collections;
using System.Collections.Generic;

namespace Gitless_api.Models
{
    public class Comments
    {
        public string Id { get; set; }
        public string ProductId { get; set; }
        public string PosterId { get; set; }
        public string CommenterId { get; set; }
        public string Comment { get; set; }
        public string Date { get; set; }
    }
}