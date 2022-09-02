﻿using FindMyPG.Core.Entities.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindMyPG.Core.Entities
{
    public  class PGRoom :BaseEntity
    {
        public int PGInfoId  { get; set; }
        public int RoomType { get; set; }//Ac/Non-AC
        public int Capacity { get; set; }
        public int Occupied { get; set; }
        public int Floor { get; set; }
        public virtual PGInfo PGInfo { get; set; }
        public int Price { get; set; }
        public virtual ICollection<PGBooking> PGBookings { get; set; }

    }
}
