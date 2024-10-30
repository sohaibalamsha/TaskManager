using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TASK_SYS.Areas.Identity.Data;

namespace TASK_SYS.Models
{
    public class Tasks
    {
        [Key]
            public int Id { get; set; }
            public string? Title { get; set; }
            public string? Description { get; set; }
            public DateTime DueDate { get; set; }
            public string? Priority { get; set; }
            public string? Tags { get; set; }
            public TaskStatus Status { get; set; } 
            public string? UserId { get; set; }
            [ForeignKey("UserId")]
            public ApplicationUser? User { get; set; }

    }
    public enum TaskStatus
    {
        Pending,
        InProgess,
        Compeleted
    }
}
