using System.ComponentModel.DataAnnotations;

namespace Todo_web_application.Models.Entities
{
    public class TaskMaster
    {
        public Guid Id { get; set; }
        [Required]
        public string? Task { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        [Display(Name = "Time Taken")]
        public string? TimeTacken { get; set; }
        [Required]
        public string? Status { get; set; }
        public DateTime? AddDate { get; set; }
    }
}
