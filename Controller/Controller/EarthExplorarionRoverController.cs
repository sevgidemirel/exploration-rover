using Controller.BaseController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Controller
{
    public class EarthExplorarionRoverController : ExplorationRoverController
    {
        protected override int M
        {
            get
            {
                return 2;
            }
        }

        protected override int L
        {
            get
            {
                return 180;
            }
        }
    }
}
