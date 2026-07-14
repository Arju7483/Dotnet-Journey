using System;
using System.Collections.Generic;
using System.Text;

namespace Builder_Pattern
{
    public class Car
    {
        public string Type { get; set; }
        public string Engine { get; set; }
        public int Wheels { get; set; }
        public bool HasSunroof { get; set; }
        public bool HasGPS { get; set; }
        public string Color { get; set; }
        public override string ToString()
        {
            return $"Car[Type={Type}, Engine={Engine}, Wheels={Wheels}, " +
                   $"Sunroof={HasSunroof}, GPS={HasGPS}, Color={Color}]";
        }
    }
}
