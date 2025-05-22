using System.ComponentModel.DataAnnotations;
using TeamTask.Domain.Models;

namespace TeamTask.Aplication.DTOs
{
    public class ReturnTaskDtos
    {
        public Guid Id { get; set; }

        public string? Titulo { get; set; }

        public string? Descripcion { get; set; }

        public DateTime? DueDate { get; set; }

        public bool? IsCompleted { get; set; }

        public Guid? TaskListId { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

    }
    public class RequestInsertTaskDtos
    {
        [Required]
        public string Titulo { get; set; } = null!;

        public string? Descripcion { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        public Guid TaskListId { get; set; }

    }
    public class RequestUpdateTaskDtos
    {
        public string? Titulo { get; set; } = null!;

        public string? Descripcion { get; set; }

        public bool? IsCompleted { get; set; }

        public DateTime? DueDate { get; set; }

    }
}
