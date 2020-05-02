using BaseModel = Business.BaseModel;
using Model = Business.Model;
using Common.Constans;
using Utilities.Helper;

namespace Controller.BaseController
{
    public class ExplorationRoverController
    {
        protected virtual int R { get { return 90; } }
        protected virtual int L { get { return -90; } }
        protected virtual int M { get { return 1; } }


        public virtual Model.RoverRequest InitializeExplorationRover(Model.RoverRequest roverRequest)
        {
            roverRequest.Location.MinimumX = LocationConstans.MinimumX;
            roverRequest.Location.MinimumY = LocationConstans.MinimumY;
            return roverRequest;
        }
        public virtual Model.RoverResponse GetLatestLocation(Model.RoverRequest roverRequest)
        {
            if (roverRequest == null || roverRequest.Location == null)
            {
                throw new System.ArgumentException("Request can not be null");
            }
            Model.RoverResponse response = new Model.RoverResponse();
            response.Location = new BaseModel.Location();
            response.Location.X = roverRequest.Location.X + roverRequest.Location.MinimumX;
            response.Location.Y = roverRequest.Location.Y + roverRequest.Location.MinimumY;
            response.Location = ExplorationRoverHelper.SetLocation(roverRequest,R,L,M);
            return response;
        }
    }
}
