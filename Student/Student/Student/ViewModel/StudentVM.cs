using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student.ViewModel
{
    public class StudentVM
    {
        public Id _id { get; set; }
        public string student_id { get; set; }
        public List<ClassDetail> class_details { get; set; }
        public ClassDetail classdetails { get; set; }
    }

    public class Id
    {
        [JsonProperty("$oid")]
        public string Oid { get; set; }
    }

    public class ClassDetail
    {
        public string subject_code { get; set; }
        public string subject_desc { get; set; }
        public string week_start_date { get; set; }
        public string week_end_date { get; set; }
        public string exact_class_date { get; set; }
        public string day_of_week { get; set; }
        public string room_number { get; set; }
        public string room { get; set; }
        public string gps_coordinates { get; set; }
        public string start_time { get; set; }
        public string end_time { get; set; }
        public string campus_code { get; set; }
        public bool hasStandardRoomDescription { get; set; }
        public int duration { get; set; }
        public string duration_code { get; set; }
        public bool isHoliday { get; set; }
    }

   
}
