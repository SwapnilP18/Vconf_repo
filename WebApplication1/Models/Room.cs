using Finbuckle.MultiTenant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConferenceApp.Models
{
    [MultiTenant]
    public class Room
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public int NumberOfParticipants { get; set; }
        public string AccessCode { get; set; }
        public DateTime LastSessionAt { get; set; }
        public string LastSessionBy { get; set; }
        public string ServerID { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
        public Guid RoomSettingID { get; set; }
        public RoomSetting RoomSetting { get; set; }
    }
}
