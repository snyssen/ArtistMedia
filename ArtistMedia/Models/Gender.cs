using System;
using System.Collections.Generic;
using System.Text;

namespace ArtistMedia.Models
{
   public class Gender
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Parent { get; set; }
        public int Child_order { get; set; }
        public string description { get; set; }
        public Guid Gid { get; set; }
    }
}
