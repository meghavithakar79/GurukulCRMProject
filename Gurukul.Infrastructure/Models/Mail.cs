using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gurukul.Infrastructure.Models
{
    public class Mail
    {
        public int Id { get; set; }
        public string SenderEmail { get; set; }
        public string RecipientEmail { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        [NotMapped]
        public List<Contact> contacts { get; set; }
    }
}
