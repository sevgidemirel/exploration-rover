using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.BaseModel;

namespace Business.Model
{
    public class RoverRequest
    {
        public string Rotation;
        public Location Location;
    }

    public class RoverResponse
    {
        public Location Location;
    }
}
