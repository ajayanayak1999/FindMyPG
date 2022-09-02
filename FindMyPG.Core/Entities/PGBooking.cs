using FindMyPG.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindMyPG.Core.Entities
{
    public class PGBooking :BaseEntity
    {
        [ForeignKey("User")]
        public long SeekerID { get; set; } //1-1
        public int PGInfoId { get; set; }//1-many
        public int PGRoomId { get; set; }//1-many
        public int PGPackageId { get; set; }//1-many
        public int Price { get; set; }
        public DateTime BookDate { get; set; }
        public DateTime BookingFrom { get; set; }
        public DateTime BookingTo { get; set; }
        public virtual User User { get; set; }
        public virtual PGInfo PGInfo { get; set; }
        public virtual PGRoom PGRoom { get; set; }
        public  virtual PGPackage PGPackage { get; set; }

    }
}
