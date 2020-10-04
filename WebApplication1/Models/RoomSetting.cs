using Finbuckle.MultiTenant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConferenceApp.Models
{
    [MultiTenant]
    public class RoomSetting
    {
        public Guid ID { get; set; }
        public Guid RoomFeatureID { get; set; }
        public string Value { get; set; }
        public Guid RoomID { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
        public Room Room { get; set; }
        public RoomFeature RoomFeature { get; set; }

    }
}
