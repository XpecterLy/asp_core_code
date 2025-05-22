using System.ComponentModel.DataAnnotations;
using TeamTask.Domain.Enums;
using TeamTask.Domain.Models;

namespace TeamTask.Aplication.DTOs
{
    public class RequestTaskListDtos
    {
        [Required]
        [MinLength(4, ErrorMessage = "The name list must be at least 4 characters.")]
        public string Name { get; set; }
    }
    public class RequestUpdateTaskListDtos
    {
        public string? Name { get; set; }

        public TaskListStatusEnum? Status { get; set; }
    }
    public class ResponseTaskListDtos
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }
        public TaskListStatusEnum Status { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
