using System.ComponentModel.DataAnnotations;

namespace Hacker_News_API_2.Models
{
    [Serializable]
    public class News
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string PostedBy { get; set; }

        [Required]
        public int? CommentsCount { get; set; }

        [Required]
        public DateTimeOffset Time { get; set; }
        
        [Required]
        public string Uri { get; set; }

        [Required]
        public int? Score { get; set; }
    }
}
