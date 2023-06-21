using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Gurukul.Infrastructure.Models
{
    public class Magazine
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string MagazineType { get; set; }
        public string Author { get; set; }
        public string PublisherName { get; set; }
        [DataType(DataType.Date)]
        public DateTime PublicationDate { get; set; }
        public bool IsDelete { get; set; }
        public ICollection<Contact> Contacts { get; set; }
    }
}
