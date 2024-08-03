using System.ComponentModel.DataAnnotations;

namespace BookStore.Models.Domain
{
    public class Genres

    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
