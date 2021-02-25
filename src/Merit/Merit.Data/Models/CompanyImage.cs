using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merit.Data.Models
{
    public class CompanyImage
    {
        public Guid CompanyImageId { get; set; }
        public string ImageTitle { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageType { get; set; }
        public CompanyUser CompanyUser { get; set; }
        public int CompanyUserId { get; set; }

    }
}
