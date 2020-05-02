using Business.BaseModel;
using Business.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Helper
{
    public class ExplorationRoverHelper
    {
        public static int DifferenceDegreeBetweenDirections = 90;
        public static Dictionary<CardinalDirectionEnum, CardinalDirectionEnum> DirectionOpposites = new Dictionary<CardinalDirectionEnum, CardinalDirectionEnum>()
        {
            { CardinalDirectionEnum.East, CardinalDirectionEnum.West },
            { CardinalDirectionEnum.West, CardinalDirectionEnum.East },
            { CardinalDirectionEnum.North, CardinalDirectionEnum.South },
            { CardinalDirectionEnum.South, CardinalDirectionEnum.North },
        };
        public static Location SetLocation(RoverRequest request, int R, int L, int M)
        {
            char[] rotations = request.Rotation.ToCharArray();
            Location location = new Location();
            location.X = request.Location.X;
            location.Y = request.Location.Y;
            location.CardinalDirection = request.Location.CardinalDirection;

            foreach (var item in rotations)
            {
                if (item == 'M')
                {
                    location = Move(location, M);
                }
                else if (item == 'R')
                {
                    location = ChangeDirection(location, R);
                }
                else if (item == 'L')
                {
                    location = ChangeDirection(location, L);
                }
            }
            return location;
        }
        public static Location Move(Location location, int M)
        {

            switch (location.CardinalDirection)
            {
                case CardinalDirectionEnum.East:
                    location.X = location.X + M;
                    return location;
                case CardinalDirectionEnum.West:
                    location.X = location.X - M;
                    return location;
                case CardinalDirectionEnum.North:
                    location.Y = location.Y + M;
                    return location;
                case CardinalDirectionEnum.South:
                    location.Y = location.Y - M;
                    return location;
                default:
                    return location;
            }
        }
        public static Location ChangeDirection(Location location, int degree)
        {
            int numberRotation = degree / DifferenceDegreeBetweenDirections;
            var lastEnum = Enum.GetValues(typeof(CardinalDirectionEnum)).Cast<CardinalDirectionEnum>().Last();

            if (numberRotation < 0)
            {
                location.CardinalDirection = (CardinalDirectionEnum)location.CardinalDirection - numberRotation;
                if (location.CardinalDirection > lastEnum)
                {
                    location.CardinalDirection = (int)location.CardinalDirection - lastEnum;
                }
                return CalculateLocation(location, location.CardinalDirection);
            }
            else
            {
                location.CardinalDirection = (CardinalDirectionEnum)location.CardinalDirection + numberRotation;
                if (location.CardinalDirection > lastEnum)
                {
                    location.CardinalDirection = (int)location.CardinalDirection - lastEnum;
                }
                return location;
            }
        }
        public static Location CalculateLocation(Location location, CardinalDirectionEnum cardionalDirection)
        {
            foreach (var item in DirectionOpposites.Keys)
            {
                if (item == cardionalDirection)
                {
                    location.CardinalDirection = DirectionOpposites[item];
                    return location;
                }
            }
            return location;
        }
        public static int[] GetMaximumLocations(string line)
        {
            string maximumLocation = line.Trim();
            try
            {
                return Array.ConvertAll(maximumLocation.Split(' '), int.Parse);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public static string[] GetCoordinates(string line)
        {
            string cordinates = line.Trim();
            try
            {
                return Array.ConvertAll(cordinates.Split(' '), item => item.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
