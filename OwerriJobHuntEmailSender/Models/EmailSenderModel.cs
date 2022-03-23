using System.ComponentModel.DataAnnotations;

namespace OwerriJobHuntEmailSender.Models
{
    public class EmailSenderModel
    {
        [Required]
        public string SendingTo { get; set; }

        [Required]
        public string TemplateBody { get; set; }


        [Required]
        public string Subject { get; set; }
    }
}
