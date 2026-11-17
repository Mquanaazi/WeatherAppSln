using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Models
{
    public class SysInfo
    {
        public int type { get; set; }
        public int id { get; set; }
        public string country { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
    }
}
