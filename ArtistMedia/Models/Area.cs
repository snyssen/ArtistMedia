﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ArtistMedia.Models
{
   public  class Area
    {
        public int Id { get; set; }
        public Guid Gid { get; set; }
        public string Name { get; set; }
        
        public int? Begin_date_year { get; set; }
        public int? Begin_date_month { get; set; }
        public int? Begin_date_day { get; set; }
        public int? End_date_year { get; set; }
        public int? End_date_month { get; set; }
        public int? End_date_day { get; set; }
        public int? Type { get; set; }

        public string Comment { get; set; }
        public int? Edits_pending { get; set; }
        public DateTime Last_updated { get; set; }
        public bool? Ended { get; set; }
    }
}
