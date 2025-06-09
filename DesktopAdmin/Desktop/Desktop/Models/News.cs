using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Models
{
    public class News
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public DateTime created_at { get; set; }
        public string image { get; set; }
        public string photo { get; set; }
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
