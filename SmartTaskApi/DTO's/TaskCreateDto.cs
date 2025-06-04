using System.ComponentModel.DataAnnotations;

namespace SmartTaskApi.DTO_s
{
    public class TaskCreateDto
    {

        [Required]
        [StringLength(100, ErrorMessage = "Title must be between 1 and 100 characters.")]
        public string Title { get; set; }

        [StringLength(500, ErrorMessage = "Description cannot be longer than 500 characters.")]
        public string? Description { get; set; }

    }
}
