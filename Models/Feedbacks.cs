using System;

namespace Gitless_api.Models
{
    public class Feedbacks
    {
        public string Id { get; set; }
        public int Star { get; set; }
        public string UserId { get; set; }
        public string Feedback { get; set; }
        public string Date { get; set; }
    }
}