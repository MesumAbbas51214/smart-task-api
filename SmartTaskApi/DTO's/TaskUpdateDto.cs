using System.ComponentModel.DataAnnotations;

namespace SmartTaskApi.DTO_s
{
    public class TaskUpdateDto
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        public bool IsComplete { get; set; }

    }
}
