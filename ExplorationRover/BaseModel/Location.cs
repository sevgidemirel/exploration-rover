using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BaseModel
{
    public class Location
    {
        public PlanetEnum Planet { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int MaximumX { get; set; }
        public int MaximumY { get; set; }
        public int MinimumX { get; set; }
        public virtual int MinimumY { get; set; }
        public CardinalDirectionEnum CardinalDirection { get; set; }
    }

    public enum CardinalDirectionEnum
    {
        Undefined,
        North,
        East,
        South,
        West,
    }

    public enum PlanetEnum
    {
        Undefined,
        Mars,
        Jupiter,
        Moon
    }
}
