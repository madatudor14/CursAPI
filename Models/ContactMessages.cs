using System.ComponentModel.DataAnnotations;

namespace LibraryProject.Models
{
    public class ContactMessages
    {
        public int Id { get; set; }                                                                                                                               
        // Email field
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        // Name field
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        public string Subject { get; set; }

        // Message field
        [Required(ErrorMessage = "Message is required.")]
        [StringLength(1000, ErrorMessage = "Message cannot exceed 1000 characters.")]
        public string Message { get; set; }

        public DateTime CreatedAt { get; set; }
    }

}
