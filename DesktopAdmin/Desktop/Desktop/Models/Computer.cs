using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Models
{
    public class Computer
    {
        public int id { get; set; }
        public string name { get; set; }
        public string uuid { get; set; }
        public int user { get; set; }
        public bool is_block { get; set; }
        public bool is_sound { get; set; }
        public bool is_work { get; set; }
        public int class_obj { get; set; }
        public string class_name { get; set; }
        public string image { get; set; }
        public string photo { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public byte[] Photo
        {
            get
            {
                if (photo == null) return null;
                return Convert.FromBase64String(photo);
            }
        }
    }
}
