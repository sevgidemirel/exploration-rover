using Business.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Converter
{
    public class CardinalDirectionConverter
    {
        public static string EnumToFrontEndValue(CardinalDirectionEnum cardinalDirection)
        {
            if (cardinalDirection == CardinalDirectionEnum.Undefined)
            {
                return null;
            }

            switch (cardinalDirection)
            {
                case CardinalDirectionEnum.West:
                    return "W";
                case CardinalDirectionEnum.East:
                    return "E";
                case CardinalDirectionEnum.South:
                    return "S";
                case CardinalDirectionEnum.North:
                    return "N";
                default:
                    return null;
            }
        }

        public static CardinalDirectionEnum FrontEndValueToEnum(string cardinalDirection)
        {
            if (String.IsNullOrEmpty(cardinalDirection))
            {
                return CardinalDirectionEnum.Undefined;
            }

            switch (cardinalDirection)
            {
                case "W":
                    return CardinalDirectionEnum.West;
                case "E":
                    return CardinalDirectionEnum.East;
                case "S":
                    return CardinalDirectionEnum.South;
                case "N":
                    return CardinalDirectionEnum.North;
                default:
                    return CardinalDirectionEnum.Undefined;
            }
        }
    }
}
