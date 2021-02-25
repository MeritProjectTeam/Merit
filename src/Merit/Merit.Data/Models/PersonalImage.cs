using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merit.Data.Models
{
    public class PersonalImage
    {
        public Guid PersonalImageId { get; set; }
        public string ImageTitle { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageType { get; set; }
       
        public int PersonalUserId { get; set; }
        public PersonalUser PersonalUser { get; set; }

    }
}
