﻿namespace SmartTaskApi.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public bool IsComplete { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
