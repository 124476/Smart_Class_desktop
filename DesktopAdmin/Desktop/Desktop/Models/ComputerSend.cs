using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Models
{
    public class ComputerSend
    {
        public int id { get; set; }
        public string name { get; set; }
        public string uuid { get; set; }
        public int user { get; set; }
        public bool is_block { get; set; }
        public bool is_sound { get; set; }
        public bool is_work { get; set; }
        public int class_obj { get; set; }
    }
}
